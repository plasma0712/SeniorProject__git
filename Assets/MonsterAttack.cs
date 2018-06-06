using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;

    public float time = 0;
    public float tag_time = 0;

    public float delay_bullet = 0;


    public bool Shooting;
    // Use this for initialization
    void Start()
    {
        Shooting = false;
    }

    void Fire()
    {
        CreateBullet();
    }


    void CreateBullet()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            tag_time = 1;

            Debug.Log("충돌처리 완료");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            tag_time = 1;

            Debug.Log("충돌처리 완료");
        }

    }
}
