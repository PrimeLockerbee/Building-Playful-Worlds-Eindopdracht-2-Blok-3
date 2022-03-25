using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : BaseUnit
{
    [SerializeField] SpriteRenderer sr_PlayerRenderer;
    [SerializeField] Sprite s_BaseSprite;
    [SerializeField] Sprite s_SwordEquipSprite;

    [SerializeField] GameObject i_SwordImage;

    private void Start()
    {
        sr_PlayerRenderer = GetComponent<SpriteRenderer>();
        i_SwordImage = GameObject.Find("Sword");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            sr_PlayerRenderer.sprite = s_SwordEquipSprite;
            i_SwordImage.SetActive(false);
        }
        if (Input.GetKey(KeyCode.P))
        {
            sr_PlayerRenderer.sprite = s_BaseSprite;
            i_SwordImage.SetActive(true);
        }
    }
}
