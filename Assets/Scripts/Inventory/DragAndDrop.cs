using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas c_Canvas;

    private RectTransform rt_RectTransform;
    private CanvasGroup cg_CanvasGroup;

    private void Awake()
    {
        rt_RectTransform = GetComponent<RectTransform>();
        cg_CanvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        cg_CanvasGroup.alpha = .6f;
        cg_CanvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        cg_CanvasGroup.alpha = 1f;
        cg_CanvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rt_RectTransform.anchoredPosition += eventData.delta/ c_Canvas.scaleFactor;
    }
}
