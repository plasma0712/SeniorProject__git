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
    public MonsterAttack EM;
    public EnemyMove player;
    public int damage;
    public bool TargetLife;

    public bool TargetFinalDestory = false;

    // Use this for initialization
    void Start()
    {
        bullet_Destory = false;
        TargetLife = false;
        animator = BulletCore.gameObject.GetComponentInChildren<Animator>();
        player = GameObject.FindWithTag("Enemy").GetComponent<EnemyMove>();
        EM = GameObject.FindWithTag("Range").GetComponent<MonsterAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TargetFinalDestory == true)
        {
            player.CurHp = 0;
        }

        if (bullet_Destory == false)
        {
            if (player.CurHp > 0)
            {
                Vector2 relativePos = player.transform.position - transform.position;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Enemy")
        {
            //Debug.Log("총알충돌");
            player.MinusHp(damage);
            bullet_Destory = true;
            Destroy(this.gameObject, 1.0f);
            MonsterAttack.Instance.tag_time = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            //  Debug.Log("총알충돌");
            player.MinusHp(damage);
            bullet_Destory = true;
            Destroy(this.gameObject, 1.0f);
            MonsterAttack.Instance.tag_time = false;
        }
    }

}
