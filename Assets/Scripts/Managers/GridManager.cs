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

    //Generates a grid with random tiles
    //If there is more time available more tiles will be added
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

    //Gets a random Tile anywhere on the grid to spawn the player on
    public Tile GetPlayerSpawnTile()
    {
        return d_tiles.Where(t => t.Key.x < _width && t.Value.b_Walkable).OrderBy(t => Random.value).First().Value;
    }

    //Gets a random Tile anywhere on the grid to spawn the enemies on
    public Tile GetEnemySpawnTile()
    {
        return d_tiles.Where(t => t.Key.x < _width && t.Value.b_Walkable).OrderBy(t => Random.value).First().Value;
    }

    //Gets a random tile at the lower half of the grid to spawn enemies on
    public Tile GetBottomRandomTile()
    {
        return d_tiles.Where(t => t.Key.y < _height / 2 && t.Value.b_Walkable).OrderBy(t => Random.value).First().Value;
    }

    //Gets a random tile at the upper half of the grid to spawn enemies on
    public Tile GetUpperRandomTile()
    {
        return d_tiles.Where(t => t.Key.y > _height/2 && t.Value.b_Walkable).OrderBy(t => Random.value).First().Value;
    }
}
