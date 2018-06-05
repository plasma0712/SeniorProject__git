using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummon : MonoBehaviour
{
    public GameObject My;
    public Transform Enemey;

    int iSecond = 5; // 나중에 난이도에 따라 조절 할 예정

    private void Start()
    {
        //Debug.Log("되냐? 어  씨발아 되냐고 씨발");
        StartCoroutine("EnemeySummon");
    }

    IEnumerator EnemeySummon()
    {
        Instantiate(Enemey, My.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(iSecond);
    }
}
