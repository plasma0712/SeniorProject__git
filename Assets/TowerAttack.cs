using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;

    public float time = 2;
    public bool tag_time = false;

    //public float delay_bullet = 0;
    public BulletController BC;

    public List<GameObject> EnemeyObjectList = new List<GameObject>(); // 이걸 왜 해야하는진 모르겠지만 일단 이용할거임 // 적 생성된 List목록
    //public List<GameObject> ObjectInRangeList = new List<GameObject>(); //타워범위에 들어온 리스트
    EnemyMove ObjectInRange; // 범위에 들어온 오브젝트(적)
    public List<EnemyMove> ObjectInRangeList = new List<EnemyMove>(); //타워범위에 들어온 리스트


    //public void EnemeyList(int Count) // EnemySummon에서 적을 생성 후 호출, List업데이트를 통해 공격 범위로 들어온 오브젝트를 파악
    //{
    //    EnemeyObjectList
    //
    //    for (int k = 0; k <= Count; k++)
    //    {
    //        EnemeyObjectList =
    //    }
    //}

    void EnemeyManagement()
    {

    }

    void Fire()
    {
        StartCoroutine("DelayBullet");
    }


    void CreateBullet()
    {
        BC=bullet.GetComponent<BulletController>();
        BC.Enemy = ObjectInRangeList[0];
        //
        Instantiate(bullet, firePos.position, firePos.rotation);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy" && this.gameObject)
        {
            //ObjectInRange = col.gameObject.tag == "Enemey";
            Fire();
            ObjectInRangeList.Add(ObjectInRange);
            
        }

        //if(col.gameObject.GetComponent<EnemyMove>())
        //{            
        //    ObjectInRangeList.Add(ObjectInRange);
        //    Debug.Log("일단?");
        //}
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.GetComponent<EnemyMove>())
        {
            ObjectInRangeList.Remove(ObjectInRange);
            Debug.Log("일단?");

        }
    }


    IEnumerator DelayBullet()
    {
        CreateBullet();
        //Debug.Log("코루틴으로 총알생성");
        yield return new WaitForSeconds(3.0f);
    }

}
