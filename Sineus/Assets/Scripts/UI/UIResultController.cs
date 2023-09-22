using TMPro;
using UnityEngine;
using Zenject;

public class UIResultController : MonoBehaviour
{
    [SerializeField] private GameObject m_resultPanel;

    [SerializeField] private TMP_Text m_finalCountText;

    private GameManager _gameManager;

    [Inject]
    public void Construct(IEntityFactory entityFactory, GameManager gameManager)
    {

        _gameManager = gameManager;
    }

    private void Awake()
    {
        _gameManager.OnLevelCompleted += ShowResultPanel;
    }

    private void ShowResultPanel(int count)
    {
        m_resultPanel.SetActive(true);

        m_finalCountText.text = count.ToString();
    }
}
