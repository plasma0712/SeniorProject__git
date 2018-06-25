using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonSetActive : MonoBehaviour
{
    public GameObject _object1;
    public GameObject _object2;

    public void TrueSetActive1()
    {
        _object1.gameObject.SetActive(true);
    }

    public void falseSetActive1()
    {
        _object1.gameObject.SetActive(false);
    }

    public void TrueSetActive2()
    {
        _object2.gameObject.SetActive(true);
    }

    public void falseSetActive2()
    {
        _object2.gameObject.SetActive(false);
    }

}
