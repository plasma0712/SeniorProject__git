using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : Singleton<MonsterAttack>
{
    public GameObject bullet;
    public Transform firePos;

    public float time = 0;
    public bool tag_time = false;

    public float delay_bullet = 0;


    public bool Shooting;
    // Use this for initialization
    void Start()
    {
        Shooting = false;
    }

    void Fire()
    {
        if (tag_time == false)
        {
            CreateBullet();
            tag_time = true;
        }
    }


    void CreateBullet()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Fire();
        }

    }
}
