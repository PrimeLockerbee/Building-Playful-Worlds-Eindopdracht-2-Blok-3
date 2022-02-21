using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    PlayerTurn,
    EnemyTurn,
    Victory,
    Death,
    Pause
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChange;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.PlayerTurn);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.PlayerTurn:
                HandlePlayerTurn();
                break;
            case GameState.EnemyTurn:
                HandleEnemyTurn();
                break;
            case GameState.Victory:
                break;
            case GameState.Death:
                break;
            case GameState.Pause:
                break;
        }

        OnGameStateChange?.Invoke(newState);
    }

    private void HandlePlayerTurn()
    {

    }

    private void HandleEnemyTurn()
    {

    }
}
