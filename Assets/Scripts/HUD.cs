using UnityEngine;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{
    private UIDocument m_uiDocument;

    [SerializeField]
    private ScoreManager m_scoreManager;

    private void OnEnable()
    {
        m_uiDocument = gameObject.GetComponent<UIDocument>();
        VisualElement root       = m_uiDocument.rootVisualElement;

        Label         scoreLabel = root.Q<Label>("scoreValue");
        scoreLabel.dataSource = m_scoreManager;
    }

}

