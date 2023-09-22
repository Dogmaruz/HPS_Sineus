using TMPro;
using UnityEngine;
using Zenject;

public class UIReworked : MonoBehaviour
{
    [SerializeField] private TMP_Text m_reworkedText;

    [SerializeField] private TMP_Text m_bonusText;

    [SerializeField] private GameObject m_timerCompas;

    private GameManager _gameManager;

    private int _maxCountReworked = 4;

    [Inject]
    public void Construct(IEntityFactory entityFactory, GameManager gameManager)
    {

        _gameManager = gameManager;
    }

    private void Awake()
    {
        _gameManager.OnReworked += UpdateText;
    }

    private void UpdateText(int count)
    {
        if (count <= _maxCountReworked)
        {
            m_reworkedText.text = count.ToString() + "/" + _maxCountReworked;
        }
        else
        {
            if (m_bonusText.gameObject.activeSelf == false)
            {
                m_bonusText.gameObject.SetActive(true);

                m_timerCompas.SetActive(true);
            }

            m_bonusText.text = "+ " + Mathf.Abs(_maxCountReworked - count).ToString();
        }
    }
}
