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

    public GameObject Culling;

    MapSettingTutorialText CurrentText;
    int TextCount = 0; // 이것을 토대로 insert로 대입할 예정

    public float TextTime;
    public GameObject NextButton;
    //public GameObject SkipButton;

    #region 튜토리얼에서 사용하는 이미지 관리
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public GameObject Lily;
    public GameObject Ellisia;
    public GameObject Production01;
    public GameObject Production02;
    public GameObject MonsterList;
    public GameObject Cave;
    public Text TutorialMenualText;
    public Text TemporatySave;
    public Text DummyText;
    public Text CharactersName;



    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #endregion


    private void Update()
    {
        ////CurrentTutorialText();
        //if (GoldSoulNumber == 0 && TextNumber == 2)
        //{
        //    LobbyTopUIData.Instance.GetGold(10000);
        //    LobbyTopUIData.Instance.GetSoul(10000);
        //    GoldSoulNumber++;
        //}
        if (SummonSuccess == 1)
        {
            NextTextNumber();//이거 삭제할지 안할지 확인요망
            MonsterList.gameObject.SetActive(false);
            TutorialMenualText.gameObject.SetActive(true);
        }
    }

    private void Awake()
    {
        StartCoroutine("TutorialTextCoroutine");
        NextButton.gameObject.SetActive(false);
        //SkipButton.gameObject.SetActive(true);
    }


    IEnumerator TutorialTextCoroutine()
    {
        /// <summary>
        /// CurrentText에서 text를 미리 캐싱해놓음
        /// </summary>
        TutorialMenualText.text = DummyText.text;
        TemporatySave.text = DummyText.text;
        if (TextNumber == 18) // 씬넘기기
        {
            SceneChange.Instance.MapSettingGameStartTutorial();
        }
        CurrentText = XMLMapSettingTutorial.Instance.GetMapSettingTutorial(TextNumber);
        EventProduct(CurrentText.EventNumber); // 이벤트씬 
        CharactersName.text = CurrentText.Characters; // 현 대화창 이름
        TemporatySave.text = CurrentText.MenualExplanationText;
        yield return new WaitForSeconds(0.1f); // 일부러 지연시킴 TemporatySave가 빠르게 읽지를 못하는경우가 있어서
        while (true)
        {
            TutorialMenualText.text = TutorialMenualText.text.ToString().Insert(TutorialMenualText.text.ToString().Length, TemporatySave.text[TextCount].ToString());
            yield return new WaitForSeconds(TextTime); // 텍스트 나오는 속도
            TextCount++;
            if (TemporatySave.text.ToString().Length <= TutorialMenualText.text.ToString().Length)
            {
                //Debug.Log("여기 지나나?");
                TextCount = 0; // 텍스트 카운트 리셋시켜줌

                NextButton.gameObject.SetActive(true);  // 대화스크립트가 끝나면 여기서 멈춰줌
                StopCoroutine("TutorialTextCoroutine"); // 대화스크립트가 끝나면 여기서 멈춰줌
                break;
            }
            // currentText의 길이값 보다 커지면 break 걸어야할듯?
        }
    }

    //
    //public void TextSkip()
    //{
    //    StopCoroutine("TutorialTextCoroutine");
    //    TutorialMenualText.text = TemporatySave.text;
    //    NextButton.gameObject.SetActive(true);
    //    SkipButton.gameObject.SetActive(false);
    //}
    //


    public void NextText()
    {
        //if (TextNumber == 7)
        //{
        //    SceneChange.Instance.MapSettingGameStartTutorial();
        //}
        NextButton.gameObject.SetActive(false);
        ////SkipButton.gameObject.SetActive(true);
        //
        ////Debug.Log("NextText에 진입 : " + TextNumber);
        //if (TextNumber < 7)
        //{
        //    StartCoroutine("TutorialTextCoroutine");
        //}
        //if (TextNumber == 5) // 맵에 타워 세울 때
        //{
        //    Lily.gameObject.SetActive(false);
        //    Culling.gameObject.SetActive(true);
        //    MonsterList.gameObject.SetActive(true);
        //    TutorialMenualText.gameObject.SetActive(false);
        //}
        //if (TextNumber == 6)
        //{
        //    Lily.gameObject.SetActive(true);
        //}
        if (TextNumber == 15)
        {
            Lily.gameObject.SetActive(false);
            MonsterList.gameObject.SetActive(true);
        }
        else
            NextTextNumber();
        StartCoroutine("TutorialTextCoroutine");

    }

    public void EventProduct(int _TextNumber)
    {
        if (_TextNumber == 0)
        {
            LobbyTopUIData.Instance.GetHeart(3);
            Production01.SetActive(true);
            Production02.SetActive(false);
            Lily.SetActive(true);
            Ellisia.SetActive(false);
        }
        else if (_TextNumber == 3)
        {
            Production01.SetActive(false);
            Production02.SetActive(true);
        }
        else if (_TextNumber == 5)
        {
            Production02.SetActive(false);
        }
        else if (_TextNumber == 12)
        {
            //여기서 사운드 들릴예정
        }
        else if (_TextNumber == 13)
        {
            //맵창 띄움
            Cave.gameObject.SetActive(false);
            Culling.gameObject.SetActive(true);
        }

        else if (_TextNumber == 14)
        {
            //이펙트 표시 상단 UI
            LobbyTopUIData.Instance.GetGold(10000);
            LobbyTopUIData.Instance.GetSoul(10000);
        }
        else if (_TextNumber == 16)
        {
            //릴리 없애줌
        }
        else if (_TextNumber == 17)
        {
            // 특정지역에 손가락애니메이션을 넣어 클릭하도록 유도
            // 맵에 다른영역 선택안되게 하는 투명창 만들예정(LayCast설정을 통해 다른곳에 클릭조차 안됨)
        }
        else if (_TextNumber == 18)
        {
            //맵창그대로 둔상태로 릴리만 띄움
        }
        else if (_TextNumber == 19)
        {
            //현재 씬은 넘어간상황

        }
        else if (_TextNumber == 20)
        {

        }
        else if (_TextNumber == 18)
        {

        }
        else if (_TextNumber == 18)
        {

        }
        else
        {
            return;
        }
    }

    public void NextTextNumber()
    {
        TextNumber++;
    }

    public void BeforeTextNumber()
    {
        TextNumber--;
    }




}
