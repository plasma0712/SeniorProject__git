using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSetActive : MonoBehaviour
{
    public GameObject SetActiveObject;

    public void Switch()
    {
        SetActiveObject.gameObject.SetActive(true);
    }
}
