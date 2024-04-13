using System;
using UnityEngine;

/// <summary>
/// ゲーム全体のStateを管理します
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState
    {
        Menu,
        InGame,
        GameOver
    }

    private GameState currentState;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeGameState(GameState.Menu);
    }

    public void ChangeGameState(GameState newGameState)
    {
        currentState = newGameState;

        switch (currentState)
        {
            case GameState.Menu:
                MenuManager.Instance.MenuEnabled(true);
                InGameManager.Instance.InGameEnabled(false);
                GameOverManager.Instance.GameOverEnabled(false);
                Debug.Log("ChangeGameState: Menu");
                break;
            case GameState.InGame:
                MenuManager.Instance.MenuEnabled(false);
                InGameManager.Instance.InGameEnabled(true);
                GameOverManager.Instance.GameOverEnabled(false);
                Debug.Log("ChangeGameState: InGame");
                break;
            case GameState.GameOver:
                MenuManager.Instance.MenuEnabled(false);
                InGameManager.Instance.InGameEnabled(false);
                GameOverManager.Instance.GameOverEnabled(true);
                Debug.Log("ChangeGameState: GameOver");
                break;
        }
    }
}
