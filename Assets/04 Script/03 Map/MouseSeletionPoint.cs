using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSeletionPoint : Singleton<MouseSeletionPoint>
{
    public GameObject My;

    public int TileNumbering = 0; // 일단 1일 경우에만 소환이 가능하게 하자.

    public void OnMouseEnter()
    {
        if (MonsterSummon.Instance.bBuy == true)
        {
            MonsterSummon.Instance.iTileNumbering = TileNumbering;
            MonsterSummon.Instance.TileIn = true;
            MonsterSummon.Instance.vPoint = My.transform.position;
        }

    }
    public void OnMouseExit()
    {
        if (MonsterSummon.Instance.bBuy == true)
        {
            MonsterSummon.Instance.vPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 5)); ;
        }
    }
}
