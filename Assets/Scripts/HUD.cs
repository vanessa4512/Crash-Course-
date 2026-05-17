using UnityEngine;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{
    private UIDocument m_uiDocument;

    [SerializeField]
    private ScoreManager m_scoreManager;

    private VisualElement m_gameOverScreen;

    private void OnEnable()
    {
        m_uiDocument = gameObject.GetComponent<UIDocument>();
        VisualElement root       = m_uiDocument.rootVisualElement;

        VisualElement topBar = root.Q<VisualElement>("TopBar");
        topBar.dataSource = m_scoreManager;

        m_gameOverScreen = root.Q<VisualElement>("GameOver");

        GameEvents.Instance.onGameOver += OnGameOver;
    }

    private void OnDisable() {
        GameEvents.Instance.onGameOver -= OnGameOver;
    }

    private void OnGameOver() {
        m_gameOverScreen.RemoveFromClassList("hidden");
    }

}

