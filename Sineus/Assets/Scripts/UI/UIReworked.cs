using TMPro;
using UnityEngine;
using Zenject;

public class UIReworked : MonoBehaviour
{
    [SerializeField] private TMP_Text m_reworkedText;

    [SerializeField] private TMP_Text m_bonusText;

    [SerializeField] private GameObject m_timerCompas;

    private GameManager _gameManager;
    private LevelController _levelController;

    private int _winCount;

    [Inject]
    public void Construct(IEntityFactory entityFactory, GameManager gameManager, LevelController levelController)
    {
        _gameManager = gameManager;
        _levelController = levelController;
    }

    private void Awake()
    {
        _levelController.OnAllTrashCollected += SetTimerCompasVisibility;
        _gameManager.OnReworked += UpdateText;
    }

    private void Start()
    {
        _winCount = _levelController.TrashWinCount;

        UpdateText(0);

        m_bonusText.gameObject.SetActive(false);
        m_timerCompas.SetActive(false);
    }

    private void UpdateText(int count)
    {
        if (count < _winCount)
        {
            m_reworkedText.text = count.ToString() + "/" + _winCount;
        }
        else if (count == _winCount)
        {
            m_reworkedText.text = count.ToString() + "/" + _winCount;
        }
        else if (count > _winCount)
        {
            m_bonusText.text = "+ " + Mathf.Abs(_winCount - count).ToString();

        }
    }

    private void SetTimerCompasVisibility(bool result)
    {
        m_timerCompas.SetActive(result);

        m_bonusText.gameObject.SetActive(result);
    }
}
