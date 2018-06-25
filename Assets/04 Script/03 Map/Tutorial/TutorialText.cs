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

    MapSettingTutorialText CurrentText;

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


    public void CurrentTutorialText()
    {
        CurrentText = XMLMapSettingTutorial.Instance.GetMapSettingTutorial(TextNumber);
        TutorialMenualText.text = CurrentText.MenualExplanationText;
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
