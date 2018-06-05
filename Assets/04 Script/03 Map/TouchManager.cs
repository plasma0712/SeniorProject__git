using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class TouchManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform UI_Arrow;
    TileInfo MapTile;
    bool bMonsters;

    MonsterSelectListManager Monsters;

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {

    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
    }

    bool MonsterDrag(Vector2 _pos)
    {
        UI_Arrow.gameObject.SetActive(true);

        UI_Arrow.position = _pos;

        Collider2D tmpui = Physics2D.OverlapPoint(_pos);
        Collider2D tmp = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(_pos));
        


        return true;
    }
}
