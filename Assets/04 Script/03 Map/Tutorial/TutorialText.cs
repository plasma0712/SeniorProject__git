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

    private Text TemporatySave;
    MapSettingTutorialText CurrentText;
    int TextCount = 0; // 이것을 토대로 insert로 대입할 예정

    public float TextTime;

    private void Update()
    {
        CurrentTutorialText();
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
        CurrentText = XMLMapSettingTutorial.Instance.GetMapSettingTutorial(TextNumber);
        TemporatySave.text = CurrentText.MenualExplanationText;
        while (true)
        {
            TutorialMenualText.text = TutorialMenualText.text.Insert(TutorialMenualText.text.Length, TemporatySave.text[TextCount]);
            yield return new WaitForSeconds(TextTime);
            TextCount++;
            
        }
    }



    public void NextText()
    {
        TextNumber++;
        if(TextNumber==5)
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
