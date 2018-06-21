using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterNotOverlap : Singleton<MonsterNotOverlap>
{
    private void Awake()
    {
        //gameObject.GetComponent<BoxCollider2D>;
    }
    private void OnMouseEnter()
    {
        //Debug.Log("마우스가 들어왔어염 뿌우~");
        MonsterSummon.Instance.DoingSummon = false;
    }
    private void OnMouseExit()
    {
        // Debug.Log("마우스가 나갔어염 뿌우~");
        MonsterSummon.Instance.DoingSummon = true;
    }
}
