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
        _gameManager.OnReworked += UpdateText;
    }

    private void Start()
    {
        _winCount = _levelController.TrashWinCount;
    }

    private void UpdateText(int count)
    {
        if (count <= _winCount)
        {
            m_reworkedText.text = count.ToString() + "/" + _winCount;
        }
        else
        {
            if (m_bonusText.gameObject.activeSelf == false)
            {
                m_bonusText.gameObject.SetActive(true);

                m_timerCompas.SetActive(true);
            }

            m_bonusText.text = "+ " + Mathf.Abs(_winCount - count).ToString();
        }
    }
}
