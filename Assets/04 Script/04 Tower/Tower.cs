using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    #region Bullet쪽 관련 변수
    public GameObject bullet;
    public Transform firePos;
    public BulletController BC;
    float time = 2;
    public bool aaa = false;
    public float DelayBulletTime;

    #endregion

    #region 타워사정범위 안에 가장 먼저 들어온 적 판별 하기 위한 List
    public List<EnemyMove> ObjectInRangeList = new List<EnemyMove>();
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            ObjectInRangeList.Add(col.gameObject.GetComponent<EnemyMove>());

            if (aaa == false)
            {
                StartCoroutine("DelayBullet");
                aaa = true;
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        ObjectInRangeList.Remove(col.gameObject.GetComponent<EnemyMove>());
        ListCount();
    }
    #endregion

    IEnumerator DelayBullet()
    {
        while (true)
        {
            if (ObjectInRangeList[0] == null) // 리스트 0이 비면 삭제하는거긴 한데, 이게 포탑이 늘어나면 좀 답없을꺼같긴함.
            {
                for (int k = 0; k < ObjectInRangeList.Count; k++)
                {
                    if (ObjectInRangeList[k] == null)
                    {
                        ObjectInRangeList.Remove(ObjectInRangeList[k]);
                    }
                }
            }
            CreateBullet();
            yield return new WaitForSeconds(DelayBulletTime);
            aaa = false; //이게 핵심 이걸 해줘야 계속된 타워 공격진행
        }
    }

    void CreateBullet()
    {
        BC = bullet.GetComponent<BulletController>();
        BC.Enemy = ObjectInRangeList[0];
        Instantiate(bullet, firePos.position, firePos.rotation);
    }

    void ListCount() // List에 아무것도 없으면 코루틴 끝내기
    {
        int k = 0;
        if (k == ObjectInRangeList.Count)
        {
            StopCoroutine("DelayBullet");
            Debug.Log("여기?");
            aaa = false;
        }
    }

}
