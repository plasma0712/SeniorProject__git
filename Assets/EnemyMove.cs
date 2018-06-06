using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int Speed=10;
    public int CurHp;
    public int MaxHp;

    // Update is called once per frame
    void Update ()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);

        if(CurHp<=0)
        {
            Destroy(this.gameObject);
        }
	}

    public void MinusHp(int num)
    {
        CurHp -= num;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag =="LeftRotation")
        {
            //Debug.Log("왼쪽");
            this.gameObject.transform.Rotate(0, 0, 90);
        }
        else if(other.transform.tag == "RightRotation")
        {
            //Debug.Log("오른쪽");
            this.gameObject.transform.Rotate(0, 0, -90);
        }
        else if(other.transform.tag == "Exit")
        {
            //Debug.Log("끝남");
            Destroy(this.gameObject);
        }
        else
        {
            return;
        }
        Debug.Log("3D트리거");

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

}
