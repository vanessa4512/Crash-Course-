using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int m_score;

    [SerializeField]
    private int m_topScore;

    private void Awake() {
        ClearScore();
    }

    public void AddScore(int amount = 1) {
        m_score += amount;

        if (m_topScore < m_score)
        {
            m_topScore = m_score;
        }
    }

    public void ClearScore() {
        m_score = 0;
    }
}
