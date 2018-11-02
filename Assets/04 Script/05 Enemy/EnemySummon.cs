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
    int TutorialTextOneMore = 0;
    public List<GameObject> MonsterList = new List<GameObject>();
    public GameObject MonsterObject;
    private void Start()
    {
        StartCoroutine("EnemeySummon");
    }

    IEnumerator EnemySummons()
    {
        while (true)
        {
            if(TutorialTextOneMore==0)
            {
                TutorialText.Instance.LilyLeft.gameObject.SetActive(false);
                TutorialText.Instance.TutorialMenualText.gameObject.SetActive(false);
                TutorialTextOneMore++;
            }
            MonsterObject = Instantiate(Enemey, My.transform.position, Quaternion.identity);
            //MonsterAttack.Instance.EnemeyList(iCountingMonster);
            iCountingMonster++;
            MonsterList.Add(MonsterObject);
            yield return new WaitForSeconds(iSecond);

            Debug.Log("몬스터생성수... : " + iCountingMonster);
            if(iCountingMonster>=9)//10개 까지만 생산
            {
                StopCoroutine("EnemySummons");

                //if로 감쌀부분 (튜토리얼 SceneNumber로 제어해서 단 한번만 쓸예정)
                if (TutorialTextOneMore == 1)
                {
                    Debug.Log("EnemySummon들어옴");
                    TutorialText.Instance.TextNumber++;
                    StartCoroutine("TutorialTextCoroutine");
                    TutorialText.Instance.LilyLeft.gameObject.SetActive(true);
                    TutorialText.Instance.TutorialMenualText.gameObject.SetActive(true);
                    TutorialTextOneMore++;
                }
            }
        }
    }

    IEnumerator TutorialEnemeySummon()
    {
        while (true)
        {
            MonsterObject = Instantiate(Enemey, My.transform.position, Quaternion.identity);
            //MonsterAttack.Instance.EnemeyList(iCountingMonster);
            iCountingMonster++;
            MonsterList.Add(MonsterObject);
            yield return new WaitForSeconds(iSecond);

            if (iCountingMonster == 1 )//1개 까지만 생산
            {
                StopCoroutine("TutorialEnemeySummon");
                break;
            }
        }
    }



}
