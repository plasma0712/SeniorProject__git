using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int _speed;
    public Vector3 _targetPosition;
    public bool move = false;

    [SerializeField]
    Vector3 targetPostionchange;
	
	void Update ()
    {
     // if(move==true)
     // {
     //     EditorMove();
     //
     //     move = false;
     // }
    }
   
    public void EditorMove()
    {
        targetPostionchange = _targetPosition;

        this.transform.position = targetPostionchange;
    }
     
}
