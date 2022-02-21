using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    [SerializeField] private GameObject go_HighLight;
    [SerializeField] private GameObject go_MousePressed;

    [SerializeField] protected SpriteRenderer sr_Renderer;

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
    }

    private void OnMouseUp()
    {
        go_MousePressed.SetActive(false);
    }
}
