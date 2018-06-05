using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;


public class XMLMenual : Singleton<XMLMenual>
{
    List<MenualText> Menuals;

    string filePath = "./Assets/Resources/MenualList_InherentNumber.xml";

    private void Awake()
    {
        // CreateXml();
         LoadXml();     // 로드를 통해서 XML정보를 받아온다.
    }

    void CreateXml()                                                                // XML 정보를 만드는 함수인데 현재로써는 만드는 틀을 이용하기 위해서 만들었지만 저장을 하도록 하게 할 예정
    {
        Menuals = new List<MenualText>();

        for(int i = 0;i<30;i++)
        {
            MenualText Menual = new MenualText
            {
                InherentNumber = i,
                MenualExplanationText = i + " : 가나다라"
            };

            Menuals.Add(Menual);
        }

        XmlDocument Document = new XmlDocument();
        XmlElement MenualListElement = Document.CreateElement("MenualList");
        Document.AppendChild(MenualListElement);

        foreach(MenualText Menual in Menuals)
        {
            XmlElement MenualElement = Document.CreateElement("Menual");
            MenualElement.SetAttribute("InherentNumber", Menual.InherentNumber.ToString());
            MenualElement.SetAttribute("MenualExplanationText", Menual.MenualExplanationText.ToString());

            MenualListElement.AppendChild(MenualElement);            
        }
        //Document.Save(Application.dataPath+filePath);
        Document.Save(filePath);
    }


    public void LoadXml()                                                           // XML 저장된 것을 불러오는 함수이다. 
    {
        Menuals = new List<MenualText>();                                           // Menuals 리스트를 새로 정의
        XmlDocument Document = new XmlDocument();                                   // XML도 Document로 새로 정의
        Document.Load(filePath);                                                    // filePath를 불러와 XML현재 위치를 불러와 관리
        XmlElement MenualListElement = Document["MenualList"];                      // MenualList라는 XML파일을 불러옴

        foreach(XmlElement MenualElement in MenualListElement.ChildNodes)           // 배열을 위한 for문
        {
            MenualText Menual = new MenualText
            {
                InherentNumber = System.Convert.ToInt32(MenualElement.GetAttribute("InherentNumber")),
                MenualExplanationText = MenualElement.GetAttribute("MenualExplanationText")                
            };
                //Debug.Log(MenualElement.GetAttribute("MenualExplanationText"));
            Menuals.Add(Menual);
        }
    }

    public int MenualLength() // 길이값을 구하는 함수
    {
        return Menuals.Count;
    }

    public MenualText GetMenual(int _InherentNumber)         // Menual을 얻을 함수
    {
        for(int i =0; i < MenualLength(); i++)               // Menual의 길이만큼만 돌 예정
        {
            if(Menuals[i].InherentNumber == _InherentNumber) // Menuals[i]의 InherentNumber값과 _InherentNumber 값이 같을 경우
            {
                return Menuals[i];                           // Menuals[i]의 값을 부른다.  
            }
        }
        return null;                                         // 같지아니할경우 null
    }

    public void MenualTextNumbering(int _idx)
    {
    //    Menuals[_idx].MenualTextDataSet(CharacteristicUsedPointValue.Instance.CUPV_CharacteristicName);
    }

}

public class MenualText
{
    public int InherentNumber;
    public string MenualExplanationText;
}