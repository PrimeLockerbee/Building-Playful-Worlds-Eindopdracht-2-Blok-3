using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private GameObject go_SelectedPlayerObject;
    [SerializeField] private GameObject go_TileObject;
    [SerializeField] private GameObject go_TileUnitObject;
    [SerializeField] private GameObject go_TileCoordsObject;

    private void Awake()
    {
        Instance = this;
    }

    //When you select a player it shows his info
    public void ShowSelectedPlayer(Player player)
    {
        if (player == null)
        {
            go_SelectedPlayerObject.SetActive(false);
            return;
        }

        go_SelectedPlayerObject.GetComponentInChildren<TextMeshProUGUI>().text = player.UnitName;
        go_SelectedPlayerObject.SetActive(true);
    }

    //Shows the info of the tile, if it has an occupied unit and the tiles coordinates
    public void ShowTileInfo(Tile tile)
    {
        if (tile == null)
        {
            go_TileObject.SetActive(false);
            go_TileUnitObject.SetActive(false);
            go_TileCoordsObject.SetActive(false);
            return;
        }

        go_TileObject.GetComponentInChildren<TextMeshProUGUI>().text = tile.TileName;
        go_TileCoordsObject.GetComponentInChildren<TextMeshProUGUI>().text = tile.v2_Coords.ToString();

        go_TileObject.SetActive(true);
        go_TileCoordsObject.SetActive(true);

        if (tile.OccupiedUnit)
        {
            go_TileUnitObject.GetComponentInChildren<TextMeshProUGUI>().text = tile.OccupiedUnit.UnitName;
            go_TileUnitObject.SetActive(true);
        }
    }
}
