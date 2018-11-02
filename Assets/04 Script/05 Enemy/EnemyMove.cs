using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : Singleton<EnemyMove>
{
    public int Speed = 10;
    public int CurHp;
    public int MaxHp;
    Vector3 MovePoint = Vector3.down;

    public int Count;
    /////////////////////////////////////////////////////////
    // MonsterAttack을 이용할 예정
    TowerAttack MKList;
    /////////////////////////////////////////////////////////
    // Start 부분에서 몬스터 List 받아오기 필요없으면 /// 부분 통째로 삭제하면됨
    public EnemySummon StartObject;
    /////////////////////////////////////////////////////////
    public GameObject TutorialSpot;


    private void Start()
    {
        StartObject = GameObject.FindWithTag("Start").GetComponent<EnemySummon>();
        MKList = GameObject.Find("Culling").GetComponent<TowerAttack>();
        Count = EnemySummon.Instance.iCountingMonster;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(MovePoint * Speed * Time.deltaTime);
        //transform.Translate(Vector3.down * Speed * Time.deltaTime);

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
        #region 회전 충돌
        if (other.transform.tag == "Right")
        {
            MovePoint = Vector3.right;
        }
        else if (other.transform.tag == "Up")
        {
            MovePoint = Vector3.up;
        }
        else if (other.transform.tag == "RightDown")
        {
            int Num = Random.Range(0, 1);
            if (Num == 0)
            {
                MovePoint = Vector3.right;
            }
            else
            {
                MovePoint = Vector3.down;
            }
        }
        else if (other.transform.tag == "Down")
        {
            MovePoint = Vector3.down;
        }
        else
        {
            return;
        }
        #endregion
    }


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


    public void TutorialMoveSpeedZero()
    {
        Speed = 0;
    }
    public void TutorialMoveSpeed()
    {
        Speed = 1;
    }
}
