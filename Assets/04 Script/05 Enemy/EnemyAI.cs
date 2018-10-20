using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    GameObject FinishPoint;

    Rigidbody2D rigidbody2d;
    float fSpeed = 100f;
    bool bAttack = false;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        //StartCoroutine("BasicAI");
    }

    void Move()
    {
        if (bAttack == false)
        {
            if (FinishPoint.transform.position.x - 1 > this.gameObject.transform.position.x)
            {//rigidbody2d.velocity = Vector2.right * fSpeed * Time.fixedDeltaTime; // 오브젝트에 가해지는 속력 속성을 바로 지정.
                rigidbody2d.AddForce(Vector2.right * fSpeed * Time.fixedDeltaTime); // 오브젝트에 힘을 가함. 오브젝트의 질량에 따른 힘이 가해짐.
                                                                                    //rigidbody2d.MovePosition(transform.position + Vector2.right * Time.fixedDeltaTime);

                rigidbody2d.drag = 0.7f; // 공기 저항력
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }

    void Attack()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("OnTriggerEnter2D 에 들어옴");
        if (collision.gameObject.tag == "Enemy")
        {
            bAttack = true;
            Destroy(collision.gameObject);
            StartCoroutine("AttackBoolCheck");
        }
    }

    

    private void Update()
    {
        Move();
    }

    IEnumerator BasicAI()
    {
        while (true)
        {
            Move();
            yield return new WaitForSeconds(20f);
        }
    }

    IEnumerator AttackBoolCheck()
    {
        while(true)
        {
            yield return new WaitForSeconds(2.0f);
            //Debug.Log("AttackBoolCheck 들어옴 과연 반복할까?");
            bAttack = false;
            StopCoroutine("AttackBoolCheck");

        }
    }
}
