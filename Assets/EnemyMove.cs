using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int Speed=10;
    int Hp;
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag =="LeftRotation")
        {
            Debug.Log("왼쪽");
            this.gameObject.transform.Rotate(0, 0, 90);
        }
        else if(other.transform.tag == "RightRotation")
        {
            Debug.Log("오른쪽");
            this.gameObject.transform.Rotate(0, 0, -90);
        }
        else if(other.transform.tag == "Exit")
        {
            Debug.Log("끝남");
            Destroy(this.gameObject);
        }
        else
        {
            return;
        }
    }
}
