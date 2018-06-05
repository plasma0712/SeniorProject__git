using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XML_TotalManagement : MonoBehaviour                //18.02.01 현잰 DontDestoryOnLoad를 위해서 그냥 만든 함수
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
