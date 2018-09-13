using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : Singleton<MonsterAttack>
{
    public GameObject bullet;
    public Transform firePos;

    public float time = 2;
    public bool tag_time = false;

    //public float delay_bullet = 0;

    public List<GameObject> ObjectInRangeList = new List<GameObject>();
    GameObject ObjectInRange;

    void Fire()
    {
        StartCoroutine("DelayBullet");
    }


    void CreateBullet()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Fire();
            ObjectInRangeList.Add((GameObject)col);
        }

    }

    void OnTriggerExit(Collider col)
    {
    }

    IEnumerator DelayBullet()
    {
        CreateBullet();
        //Debug.Log("코루틴으로 총알생성");
        yield return new WaitForSeconds(3.0f);
    }

}
