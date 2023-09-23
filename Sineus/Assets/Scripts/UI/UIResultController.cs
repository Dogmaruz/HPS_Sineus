using TMPro;
using UnityEngine;
using Zenject;

public class UIResultController : MonoBehaviour
{
    [SerializeField] private GameObject m_resultPanel;

    [SerializeField] private TMP_Text m_finalCountText;

    private GameManager _gameManager;
    private LevelController _levelController;

    [Inject]
    public void Construct(IEntityFactory entityFactory, GameManager gameManager, LevelController levelController)
    {
        _gameManager = gameManager;
        _levelController = levelController;
    }

    private void Awake()
    {
        _gameManager.OnLevelCompleted += UpdateFinalCountText;
        _levelController.OnFinishLevel += ShowResultPanel;
    }

    private void UpdateFinalCountText(int count)
    {
        m_finalCountText.text = count.ToString();
    }

    private void ShowResultPanel(bool result)
    {
        if (result == true)
        {
            m_resultPanel.SetActive(true);
        }

        if (result == false)
        {
            //TODO LosePanel
        }
    }
}
