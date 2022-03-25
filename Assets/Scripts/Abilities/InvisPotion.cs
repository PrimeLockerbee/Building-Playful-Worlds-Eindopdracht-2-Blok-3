using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisPotion : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr_PlayerRenderer;

    private void Start()
    {
        sr_PlayerRenderer = GameObject.Find("Player").GetComponent<SpriteRenderer>();
    }

    public void InvisActivate()
    {
        Color c_temp = sr_PlayerRenderer.color;
        c_temp.a = 0f;
        sr_PlayerRenderer.color = c_temp;
    }
}
