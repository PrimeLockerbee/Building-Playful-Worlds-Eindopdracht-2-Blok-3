using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy01 : BaseEnemy
{
    public static Enemy01 Instance;

    private void Awake()
    {
        Instance = this;
    }

    //Finds all enemies with the enemy01 script and moves them
    public void MoveEnemy1()
    {
        if (GameManager.Instance.State != GameState.Enemy1Turn) return;

        Enemy01[] list = FindObjectsOfType(typeof(Enemy01)) as Enemy01[];
        foreach(Enemy01 obj in list)
        {
            obj.GetComponent<Enemy01>();
            var nextXTile = GridManager.Instance.GetUpperRandomTile();

            nextXTile.SetEnemy1(obj);
        }

        GameManager.Instance.UpdateGameState(GameState.Enemy2Turn);
    }
}
