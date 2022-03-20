using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public enum GameState
{
    GenerateGrid = 0,
    SpawnPlayer = 1,
    SpawnEnemy = 2,
    PlayerTurn = 3,
    Enemy1Turn = 4,
    Enemy2Turn = 5,
    Victory = 6,
}


[System.Serializable]
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
        UpdateGameState(GameState.GenerateGrid);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.SpawnPlayer:
                UnitManager.Instance.SpawnPlayer();
                break;
            case GameState.SpawnEnemy:
                UnitManager.Instance.SpawnEnemy();
                break;
            case GameState.PlayerTurn:
                break;
            case GameState.Enemy1Turn:
                if (Enemy01.Instance == null)
                {
                    UpdateGameState(GameState.Enemy2Turn);
                }
                Enemy01.Instance.MoveEnemy1();
                break;
            case GameState.Enemy2Turn:
                if (Enemy02.Instance == null)
                {
                    UpdateGameState(GameState.PlayerTurn);
                }
                Enemy02.Instance.MoveEnemy2();
                break;
            case GameState.Victory:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChange?.Invoke(newState);
    }

    private void Save()
    {

    }

    private void Load()
    {

    }
}
