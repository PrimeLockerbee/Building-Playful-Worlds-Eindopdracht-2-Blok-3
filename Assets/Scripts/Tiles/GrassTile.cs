using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTile : Tile
{
    [SerializeField] private Color c_BaseColor;
    [SerializeField] private Color c_OffsetColor;

    public override void Init(int x, int y)
    {
        var isOffset = (x + y) % 2 == 1;

        sr_Renderer.color = isOffset ? c_OffsetColor : c_BaseColor;
    }
}
