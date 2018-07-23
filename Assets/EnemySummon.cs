using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummon : Singleton<EnemySummon>
{
    public GameObject My;
    //public Transform Enemey; 문제생기면 GameObject Enemey 삭제후 넣으면 됨
    public GameObject Enemey;

    public int iSecond = 1; // 나중에 난이도에 따라 조절 할 예정
    public int iCountingMonster = 0;

    public List<GameObject> MonsterList = new List<GameObject>();
    public GameObject MonsterObject;
    private void Start()
    {
        StartCoroutine("EnemeySummon");
    }

    IEnumerator EnemeySummon()
    {
        while (true)
        {
            MonsterObject = Instantiate(Enemey, My.transform.position, Quaternion.identity);
            //MonsterAttack.Instance.EnemeyList(iCountingMonster);
            iCountingMonster++;
            MonsterList.Add(MonsterObject);
            yield return new WaitForSeconds(iSecond);
            
            if(iCountingMonster>=10)//10개 까지만 생산
            {
                StopCoroutine("EnemeySummon");
            }
        }
    }
}
