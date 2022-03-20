using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    //Info All units have acces to
    public string UnitName;
    public int MovementRange;
    public Tile OccupiedTile;
    public Faction Faction;
}
