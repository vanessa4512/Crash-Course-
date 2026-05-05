using UnityEngine;

public class GameEvents : MonoBehaviour
{
    private static GameEvents m_instance;

    public static GameEvents Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new GameEvents();
            }
            return m_instance;
        }
    }

}
