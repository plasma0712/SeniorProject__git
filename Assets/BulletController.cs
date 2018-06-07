using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 30f;
    Animator animator;

    //    public GameObject player;
    bool bullet_Destory;

    public GameObject BulletCore;

    public MonsterAttack EM;

    public EnemyMove player;

    public int damage;

    // Use this for initialization
    void Start()
    {
        //   Destroy(this.gameObject, 2f);    // delete itself
        bullet_Destory = false;
        animator = BulletCore.gameObject.GetComponentInChildren<Animator>();
        player = GameObject.FindWithTag("Enemy").GetComponent<EnemyMove>();
        EM = GameObject.FindWithTag("Range").GetComponent<MonsterAttack>();

    }

    // Update is called once per frame
    void Update()
    {

        if (bullet_Destory == false)
        {
            Vector2 relativePos = player.transform.position - transform.position;
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(0, 0, angle - 90);
            transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
        }

        if (bullet_Destory == true)
        {
            animator.SetBool("_Hitting", true);
            Debug.Log("총알애니메이션");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Enemy")
        {
            Debug.Log("총알충돌");
            player.MinusHp(damage);
            bullet_Destory = true;
            Destroy(this.gameObject, 1.0f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Debug.Log("총알충돌");
            player.MinusHp(damage);
            bullet_Destory = true;
            Destroy(this.gameObject, 1.0f);
        }
    }

}
