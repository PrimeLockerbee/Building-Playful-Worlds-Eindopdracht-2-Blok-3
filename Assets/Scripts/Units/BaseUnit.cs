using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    //Info all the units from any faction can use
    public string UnitName;
    public int MovementRange;
    public Tile OccupiedTile;
    public Faction Faction;
}
