using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Awake()
    {
        GameManager.OnGameStateChange += GameManagerOnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChange -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {

    }

    public void Attack()
    {
        //Unit Manager.Instance.Attack

        GameManager.Instance.UpdateGameState(GameState.EnemyTurn);
    }
}
