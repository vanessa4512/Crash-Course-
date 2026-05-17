using System;
using UnityEngine;

public class GameEvents
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

    public event Action<int> onAddToScore;

    public event Action onPlayerDie;

    public event Action onGameOver;

    public event Action onRetry;

    /// <summary>
    /// Dispatches an event to increment the score value.
    /// </summary>
    /// <param name="amount">Amount to increment by</param>
    public void AddToScore(int amount = 1) {
        onAddToScore?.Invoke(amount);
    }

    /// <summary>
    /// Dispatches an event to increment the player has died.
    /// </summary>
    public void OnPlayerDie() {
        onPlayerDie?.Invoke();
    }

    /// <summary>
    /// Dispatches an event to tell us the game is over.
    /// </summary>
    public void OnGameOver() {
        onGameOver?.Invoke();
    }

    /// <summary>
    /// Dispatches an event to tell us the player wants to restart the game.
    /// </summary>
    public void Retry() {
        onRetry?.Invoke();
    }

    public void OnRetry() {
        onRetry?.Invoke();
    }
}
