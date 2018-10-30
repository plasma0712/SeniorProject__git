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
    //public GameObject SkipButton;

    #region 이미지 변경
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // 원래라면 캐릭터자체이름을 확인해서 이미지파일을 변경하도록 했어야하는데, 임의로 현재는 변경을 할 예정.
    // 01. image는 이미지가 바뀔 gameobject
    // 02. sprites는 이미지를 변경하기 위한 sprite 모음
    public Image image;
    public Sprite[] sprites;

    void TutorialImageChange(int ImageNumber, int TextNumbering)
    {
        image.sprite = sprites[ImageNumber];
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #endregion


    private void Update()
    {
        //CurrentTutorialText();
        if (GoldSoulNumber == 0 && TextNumber == 2)
        {
            LobbyTopUIData.Instance.GetGold(10000);
            LobbyTopUIData.Instance.GetSoul(10000);
            GoldSoulNumber++;
        }
        if (SummonSuccess == 1)
        {
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

    #region 안씀
    public void CurrentTutorialText()
    {
        CurrentText = XMLMapSettingTutorial.Instance.GetMapSettingTutorial(TextNumber);
        //
        TutorialMenualText.text = CurrentText.MenualExplanationText;
    }
    #endregion


    IEnumerator TutorialTextCoroutine()
    {
        /// <summary>
        /// CurrentText에서 text를 미리 캐싱해놓음
        /// </summary>
        TutorialMenualText.text = DummyText.text;
        TemporatySave.text = DummyText.text;
        CurrentText = XMLMapSettingTutorial.Instance.GetMapSettingTutorial(TextNumber);
        TemporatySave.text = CurrentText.MenualExplanationText;
        yield return new WaitForSeconds(0.1f); // 일부러 지연시킴 TemporatySave가 빠르게 읽지를 못하는경우가 있어서
        while (true)
        {
            TutorialMenualText.text = TutorialMenualText.text.ToString().Insert(TutorialMenualText.text.ToString().Length, TemporatySave.text[TextCount].ToString());
            yield return new WaitForSeconds(TextTime);
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
        NextTextNumber();
        if (TextNumber == 7)
        {
            SceneChange.Instance.MapSettingGameStartTutorial();
        }
        NextButton.gameObject.SetActive(false);
        //SkipButton.gameObject.SetActive(true);

        //Debug.Log("NextText에 진입 : " + TextNumber);
        if (TextNumber < 7)
        {
            StartCoroutine("TutorialTextCoroutine");
        }
        if (TextNumber == 5) // 맵에 타워 세울 때
        {
            Lily.gameObject.SetActive(false);
            Culling.gameObject.SetActive(true);
            MonsterList.gameObject.SetActive(true);
            TutorialMenualText.gameObject.SetActive(false);
        }
        if (TextNumber == 6)
        {
            Lily.gameObject.SetActive(true);
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
