using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02 : BaseEnemy
{
    public static Enemy02 Instance;

    private void Awake()
    {
        Instance = this;
    }

    //Finds all enemies with the enemy02 script and moves them
    public void MoveEnemy2()
    {
        if (GameManager.Instance.State != GameState.Enemy2Turn) return;

        Enemy02[] list = FindObjectsOfType(typeof(Enemy02)) as Enemy02[];
        foreach (Enemy02 obj in list)
        {
            obj.GetComponent<Enemy02>();
            var nextXTile = GridManager.Instance.GetBottomRandomTile();

            nextXTile.SetEnemy2(obj);
        }

        GameManager.Instance.UpdateGameState(GameState.PlayerTurn);
    }
}
