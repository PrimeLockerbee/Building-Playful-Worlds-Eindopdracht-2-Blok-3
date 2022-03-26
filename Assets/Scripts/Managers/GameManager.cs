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
}


[System.Serializable]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChange;

    [SerializeField] GameObject go_VictoryScreen;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.GenerateGrid);
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy01").Length == 0 && GameObject.FindGameObjectsWithTag("Enemy02").Length == 0)
        {
            go_VictoryScreen.SetActive(true);
        }
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
                if (GameObject.FindGameObjectsWithTag("Enemy01").Length == 0)
                {
                    UpdateGameState(GameState.Enemy2Turn);
                }
                Enemy01.Instance.MoveEnemy1();
                break;
            case GameState.Enemy2Turn:
                if (GameObject.FindGameObjectsWithTag("Enemy02").Length == 0)
                {
                    UpdateGameState(GameState.PlayerTurn);
                }
                Enemy02.Instance.MoveEnemy2();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChange?.Invoke(newState);
    }
}
