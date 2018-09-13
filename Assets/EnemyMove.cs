using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int Speed = 10;
    public int CurHp;
    public int MaxHp;

    public int Count;
    /////////////////////////////////////////////////////////
    // MonsterAttack을 이용할 예정
    MonsterAttack MKList;
    /////////////////////////////////////////////////////////
    // Start 부분에서 몬스터 List 받아오기 필요없으면 /// 부분 통째로 삭제하면됨
    public EnemySummon StartObject;
    /////////////////////////////////////////////////////////

    private void Start()
    {
        StartObject = GameObject.FindWithTag("Start").GetComponent<EnemySummon>();
        MKList = GameObject.Find("Culling").GetComponent<MonsterAttack>();
        Count = EnemySummon.Instance.iCountingMonster;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);

        if (CurHp <= 0)
        {
            Destroy(this.gameObject);
            StartObject.MonsterList.Remove(this.gameObject);
        }
    }

    public void MinusHp(int num)
    {
        CurHp -= num;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "LeftRotation")
        {
            //Debug.Log("왼쪽");
            this.gameObject.transform.Rotate(0, 0, 90);
        }
        else if (other.transform.tag == "RightRotation")
        {
            //Debug.Log("오른쪽");
            this.gameObject.transform.Rotate(0, 0, -90);
        }
        else if (other.transform.tag == "Exit")
        {
            //Debug.Log("끝남");
            Destroy(this.gameObject);
            BulletController.Instance.TargetFinalDestory = true;
        }
        else if(other.gameObject.GetComponent<MonsterAttack>())
        {
            MonsterAttack.Instance.ObjectInRangeList.Add(this.gameObject.GetComponent<EnemyMove>());
        }
        else
        {
            return;
        }
        //Debug.Log("3D트리거");
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if(other.gameObject.tag == "Range")
    //    {
    //        MonsterAttack.Instance.ObjectInRangeList.Remove(this.gameObject);
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LeftRotation")
        {
            //Debug.Log("왼쪽");
            this.gameObject.transform.Rotate(0, 0, 90);
        }
        else if (other.gameObject.tag == "RightRotation")
        {
            //Debug.Log("오른쪽");
            this.gameObject.transform.Rotate(0, 0, -90);
        }
        else if (other.gameObject.tag == "Exit")
        {
            //Debug.Log("끝남");
            Destroy(this.gameObject);
        }
        else
        {
            return;
        }

        Debug.Log("2D트리거");
    }

}
