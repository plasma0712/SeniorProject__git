using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TutorialText : Singleton<TutorialText>
{
    public int SummonSuccess;
    public int TextNumber;
    public int GoldSoulNumber;
    //public GameObject MenuText;
    public Text TutorialMenualText;

    public GameObject Lily;
    public GameObject Culling;
    public GameObject MonsterList;

    public Text TemporatySave;
    public Text DummyText;
    MapSettingTutorialText CurrentText;
    int TextCount = 0; // 이것을 토대로 insert로 대입할 예정

    public float TextTime;
    public GameObject NextButton;
    public GameObject SkipButton;
    private void Update()
    {
        //CurrentTutorialText();
        if(GoldSoulNumber==0&&TextNumber==2)
        {
            LobbyTopUIData.Instance.GetGold(100);
            LobbyTopUIData.Instance.GetSoul(100);
            GoldSoulNumber++;
        }
        if(SummonSuccess==1)
        {
            MonsterList.gameObject.SetActive(false);
            TutorialMenualText.gameObject.SetActive(true);
        }
    }

    private void Awake()
    {
        StartCoroutine("TutorialTextCoroutine");
    }


    public void CurrentTutorialText()
    {
        CurrentText = XMLMapSettingTutorial.Instance.GetMapSettingTutorial(TextNumber);
        //
        TutorialMenualText.text = CurrentText.MenualExplanationText;       
    }


   
    IEnumerator TutorialTextCoroutine()
    {
        /// <summary>
        /// CurrentText에서 text를 미리 캐싱해놓음
        /// </summary>
        TutorialMenualText.text = DummyText.text;
        TemporatySave.text = DummyText.text;
        CurrentText = XMLMapSettingTutorial.Instance.GetMapSettingTutorial(TextNumber);
        TemporatySave.text = CurrentText.MenualExplanationText;
        while (true)
        {
            TutorialMenualText.text = TutorialMenualText.text.ToString().Insert(TutorialMenualText.text.ToString().Length, TemporatySave.text[TextCount].ToString());
            yield return new WaitForSeconds(TextTime);
            TextCount++;
            if(TemporatySave.text.ToString().Length<=TutorialMenualText.text.ToString().Length)
            {
                Debug.Log("여기 지나나?");
                TextCount = 0; // 텍스트 카운트 리셋시켜줌
                StopCoroutine("TutorialTextCoroutine");
                break;
            }
            // currentText의 길이값 보다 커지면 break 걸어야할듯?
        }
    }

    public void TextSkip()
    {
        StopCoroutine("TutorialTextCoroutine");
        TutorialMenualText.text = TemporatySave.text;
        SkipButton.gameObject.SetActive(false);
        NextButton.gameObject.SetActive(true);
    }

    public void NextText()
    {
        NextButton.gameObject.SetActive(false);
        SkipButton.gameObject.SetActive(true);

        TextNumber++;
        Debug.Log("NextText에 진입 : " + TextNumber);
        StartCoroutine("TutorialTextCoroutine");
        if(TextNumber==5) // 맵에 타워 세울 때
        {
            Lily.gameObject.SetActive(false);
            Culling.gameObject.SetActive(true);
            MonsterList.gameObject.SetActive(true);
            TutorialMenualText.gameObject.SetActive(false);
        }
        if(TextNumber==6)
        {
            Lily.gameObject.SetActive(true);
        }
    }
    public void BeforeText()
    {
        TextNumber--;
    }




}
