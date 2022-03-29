using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvisPotion : MonoBehaviour
{
    SpriteRenderer sr_PlayerRenderer;
    Button b_InvisButton;
    bool b_isInvis;

    private void Start()
    {
        sr_PlayerRenderer = GameObject.Find("Player(Clone)").GetComponent<SpriteRenderer>();
        b_InvisButton = GetComponent<Button>();
        b_isInvis = false;
    }

    public void InvisActivate()
    {
        //Activates the invisible effect by changing the alpha of the sprite
        if(b_isInvis == false)
        {
            Color c_temp = sr_PlayerRenderer.color;
            c_temp.a = .5f;
            sr_PlayerRenderer.color = c_temp;

            StartCoroutine(InvisTimer());
            StartCoroutine(LockButton());
        }
    }

    //Activates and deactivates the invisible effect
    IEnumerator InvisTimer()
    {
        b_isInvis = true;

        yield return new WaitForSeconds(5);

        Color c_temp = sr_PlayerRenderer.color;
        c_temp.a = 1f;
        sr_PlayerRenderer.color = c_temp;

        b_isInvis = false;
    }

    //Locks the invisible ability buttons for 15 seconds
    IEnumerator LockButton()
    {
        b_InvisButton.interactable = false;

        yield return new WaitForSeconds(15);

        b_InvisButton.interactable = true;
    }
}
