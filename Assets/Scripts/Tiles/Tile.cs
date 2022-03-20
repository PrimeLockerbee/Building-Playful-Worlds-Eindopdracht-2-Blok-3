using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    [SerializeField] private GameObject go_HighLight;
    [SerializeField] private GameObject go_MousePressed;

    [SerializeField] protected SpriteRenderer sr_Renderer;

    [SerializeField] private bool b_isWalkable;

    public string TileName;

    public Vector2 v2_Coords;

    public BaseUnit OccupiedUnit;
    public bool b_Walkable => b_isWalkable && OccupiedUnit == null;

    public void Awake()
    {
        v2_Coords = new Vector2(transform.position.x, transform.position.y);
    }

    public virtual void Init(int x, int y)
    {

    }

    private void OnMouseEnter()
    {
        go_HighLight.SetActive(true);
        MenuManager.Instance.ShowTileInfo(this);
    }

    private void OnMouseExit()
    {
        go_HighLight.SetActive(false);
        MenuManager.Instance.ShowTileInfo(null);
    }

    private void OnMouseDown()
    {
        go_MousePressed.SetActive(true);

        MovePlayer();

    }

    private void OnMouseUp()
    {
        go_MousePressed.SetActive(false);
    }

    //Moves the Player and allows you to destroy enemies
    void MovePlayer()
    {
        if (GameManager.Instance.State != GameState.PlayerTurn) return;

        if (OccupiedUnit != null)
        {
            if (OccupiedUnit.Faction == Faction.Player)
            {
                UnitManager.Instance.SetSelectedPlayer((Player)OccupiedUnit);
            }
            else
            {
                if (UnitManager.Instance.SelectedPlayer != null)
                {
                    var enemy = (BaseEnemy)OccupiedUnit;
                    Destroy(enemy.gameObject);
                    UnitManager.Instance.SetSelectedPlayer(null);
                }
                GameManager.Instance.UpdateGameState(GameState.Enemy1Turn);
            }
        }
        else
        {
            if (UnitManager.Instance.SelectedPlayer != null && b_isWalkable == true)
            {
                SetUnit(UnitManager.Instance.SelectedPlayer);
                UnitManager.Instance.SetSelectedPlayer(null);
                GameManager.Instance.UpdateGameState(GameState.Enemy1Turn);
            }
        }
    }


    //Sets the Unit to the tile
    public void SetUnit(BaseUnit unit)
    {
        if (unit.OccupiedTile != null)
        {
            unit.OccupiedTile.OccupiedUnit = null;
        }
        unit.transform.position = transform.position;
        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }

    //Variant of SetUnit but sets the first enemy to the tile
    public void SetEnemy1(Enemy01 unit)
    {
        if (unit.OccupiedTile != null)
        {
            unit.OccupiedTile.OccupiedUnit = null;
        }
        unit.transform.position = transform.position;
        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }

    //Variant of SetUnit but sets the second enemy to the tile
    public void SetEnemy2(Enemy02 unit)
    {
        if (unit.OccupiedTile != null)
        {
            unit.OccupiedTile.OccupiedUnit = null;
        }
        unit.transform.position = transform.position;
        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }
}
