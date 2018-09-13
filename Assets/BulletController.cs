using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : Singleton<BulletController>
{
    public float speed = 50f;
    Animator animator;

    //    public GameObject player;
    bool bullet_Destory;
    public GameObject BulletCore;
    public MonsterAttack MonsterAttack_Range;
    public EnemyMove Enemy;
    public int damage;
    public bool TargetLife;

    public bool TargetFinalDestory = false;
    // Use this for initialization
    void Start()
    {
        bullet_Destory = false;
        TargetLife = false;
        animator = BulletCore.gameObject.GetComponentInChildren<Animator>();
        //Enemy = GameObject.FindWithTag("Enemy").GetComponent<EnemyMove>();
        //MonsterAttack_Range = GameObject.FindWithTag("Range").GetComponent<MonsterAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TargetFinalDestory == true)
        {
            Enemy.CurHp = 0;
        }

        if (bullet_Destory == false)
        {
            if (Enemy.CurHp > 0)
            {
                Vector2 relativePos = Enemy.transform.position - transform.position;
                float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
                transform.localRotation = Quaternion.Euler(0, 0, angle - 90);
                transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        if (bullet_Destory == true)
        {
            animator.SetBool("_Hitting", true);
            Destroy(this.gameObject, 1.0f);
            //Debug.Log("총알애니메이션");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy" )
        {
            //  Debug.Log("총알충돌");
            Enemy.MinusHp(damage);
            bullet_Destory = true;
            //Destroy(this.gameObject, 1.0f); Bullet_Destory가 true가 될 때 Update문에서 처리함 중복처리라서 제거
            //MonsterAttack_Range.GetComponent<MonsterAttack>().tag_time = false; // 공격속도를 처리하려고 했는데 그럴필요보다는 enemy에서 코루틴으로 처리해야할듯 이줄 삭제요망
            //MonsterAttack.Instance.tag_time = false;
        }
    }
}
