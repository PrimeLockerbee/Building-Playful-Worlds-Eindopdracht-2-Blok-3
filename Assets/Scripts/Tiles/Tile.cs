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

    public BaseUnit OccupiedUnit;
    public bool b_Walkable => b_isWalkable && OccupiedUnit == null;

    public virtual void Init(int x, int y)
    {

    }

    private void OnMouseEnter()
    {
        go_HighLight.SetActive(true);
    }

    private void OnMouseExit()
    {
        go_HighLight.SetActive(false);
    }

    private void OnMouseDown()
    {
        go_MousePressed.SetActive(true);

        if(GameManager.Instance.State != GameState.PlayerTurn) return;

        if (OccupiedUnit != null)
        {
            if (OccupiedUnit.Faction == Faction.Player)
            {

            }
        }
    }

    private void OnMouseUp()
    {
        go_MousePressed.SetActive(false);


    }

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
}
