using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : BaseUnit
{
    [SerializeField] SpriteRenderer sr_PlayerRenderer;
    [SerializeField] Sprite s_BaseSprite;
    [SerializeField] Sprite s_SwordEquipSprite;

    [SerializeField] GameObject go_SwordImage;

    private void Start()
    {
        sr_PlayerRenderer = GetComponent<SpriteRenderer>();
        go_SwordImage = GameObject.Find("Sword");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            //Equips the weapon
            sr_PlayerRenderer.sprite = s_SwordEquipSprite;
            go_SwordImage.SetActive(false);
        }
        if (Input.GetKey(KeyCode.P))
        {
            //Dequips weapon
            sr_PlayerRenderer.sprite = s_BaseSprite;
            go_SwordImage.SetActive(true);
        }
    }
}
