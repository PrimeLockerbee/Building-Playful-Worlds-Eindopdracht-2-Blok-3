using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    private List<ScriptableUnit> l_units;

    public BasePlayer SelectedPlayer;

    void Awake()
    {
        Instance = this;

        l_units = Resources.LoadAll<ScriptableUnit>("Units").ToList();

    }

    public void SpawnPlayer()
    {
        var playerCount = 1;

        for (int i = 0; i < playerCount; i++)
        {
            var randomPrefab = GetRandomUnit<BasePlayer>(Faction.Player);
            var spawnPlayer = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.Instance.GetPlayerSpawnTile();

            randomSpawnTile.SetUnit(spawnPlayer);
        }

        GameManager.Instance.UpdateGameState(GameState.SpawnEnemy);
    }

    public void SpawnEnemy()
    {
        var enemyCount = 5;

        for (int i = 0; i < enemyCount; i++)
        {
            var randomPrefab = GetRandomUnit<BaseEnemy>(Faction.Enemy);
            var spawnEnemy = Instantiate(randomPrefab);
            var randomSpawnTile = GridManager.Instance.GetEnemySpawnTile();

            randomSpawnTile.SetUnit(spawnEnemy);
        }

        GameManager.Instance.UpdateGameState(GameState.PlayerTurn);
    }

    public void SetSelectedPlayer(BasePlayer player)
    {
        SelectedPlayer = player;
        MenuManager.Instance.ShowSelectedPlayer(player);
    }

    private T GetRandomUnit<T>(Faction faction) where T : BaseUnit
    {
        return (T)l_units.Where(u => u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    }
}
