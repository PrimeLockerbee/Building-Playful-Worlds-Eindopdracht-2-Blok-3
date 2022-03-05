using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] private GameObject go_SelectedPlayerObject;
    [SerializeField] private GameObject go_TileObject;
    [SerializeField] private GameObject go_TileUnitObject;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowSelectedPlayer(BasePlayer player)
    {
        if (player == null)
        {
            go_SelectedPlayerObject.SetActive(false);
            return;
        }

        go_SelectedPlayerObject.GetComponentInChildren<TextMeshProUGUI>().text = player.UnitName;
        go_SelectedPlayerObject.SetActive(true);
    }

    public void ShowTileInfo(Tile tile)
    {
        if (tile == null)
        {
            go_TileObject.SetActive(false);
            go_TileUnitObject.SetActive(false);
            return;
        }

        go_TileObject.GetComponentInChildren<TextMeshProUGUI>().text = tile.TileName;
        go_TileObject.SetActive(true);

        if (tile.OccupiedUnit)
        {
            go_TileUnitObject.GetComponentInChildren<TextMeshProUGUI>().text = tile.OccupiedUnit.UnitName;
            go_TileUnitObject.SetActive(true);
        }
    }
}
