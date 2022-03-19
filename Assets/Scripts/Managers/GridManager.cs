using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    [SerializeField] private Tile _GrassTile;

    [SerializeField] private int _width;
    [SerializeField] private int _height;

    private Dictionary<Vector2, Tile> d_tiles;

    private void Awake()
    {
        Instance = this;
    }

    public void GenerateGrid()
    {
        d_tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var randomTile = _GrassTile;
                var spawnedTile = Instantiate(randomTile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile: {x}, {y}";

                spawnedTile.Init(x,y);

                d_tiles[new Vector2(x, y)] = spawnedTile;
            }
        }

        GameManager.Instance.UpdateGameState(GameState.SpawnPlayer);
    }

    public Tile GetPlayerSpawnTile()
    {
        return d_tiles.Where(t => t.Key.x < _width && t.Value.b_Walkable).OrderBy(t => Random.value).First().Value;
    }

    public Tile GetEnemySpawnTile()
    {
        return d_tiles.Where(t => t.Key.x < _width && t.Value.b_Walkable).OrderBy(t => Random.value).First().Value;
    }

    //public void GetTile()
    //{
    //    foreach (KeyValuePair<Vector2, Tile> keyValue in d_tiles)
    //    {
    //        Vector2 key = keyValue.Key;
    //    }
    //}


    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (d_tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }

        return null;
    }
}
