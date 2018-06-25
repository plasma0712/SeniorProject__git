using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XMLMapSettingTutorial : Singleton<XMLMapSettingTutorial>
{
    List<MapSettingTutorialText> MapSettingTutorials;

    string filePath = "./Assets/Resources/MapSettingTutorial.xml";

    private void Awake()
    {
        // CreateXml();
        LoadXml();     // 로드를 통해서 XML정보를 받아온다.
    }

    public void LoadXml()                                                           // XML 저장된 것을 불러오는 함수이다. 
    {
        MapSettingTutorials = new List<MapSettingTutorialText>();                                           // Menuals 리스트를 새로 정의
        XmlDocument Document = new XmlDocument();                                   // XML도 Document로 새로 정의
        Document.Load(filePath);                                                    // filePath를 불러와 XML현재 위치를 불러와 관리
        XmlElement MapSettingTutorialListElement = Document["MapSettingTutorialList"];                      // MenualList라는 XML파일을 불러옴

        foreach (XmlElement MapSettingTutorialElement in MapSettingTutorialListElement.ChildNodes)           // 배열을 위한 for문
        {
            MapSettingTutorialText MapSettingTutorial = new MapSettingTutorialText
            {
                InherentNumber = System.Convert.ToInt32(MapSettingTutorialElement.GetAttribute("InherentNumber")),
                MenualExplanationText = MapSettingTutorialElement.GetAttribute("MenualExplanationText")
            };
            //Debug.Log(MenualElement.GetAttribute("MenualExplanationText"));
            MapSettingTutorials.Add(MapSettingTutorial);
        }
    }

    public int MapSettingTutorialLength() // 길이값을 구하는 함수
    {
        return MapSettingTutorials.Count;
    }

    public MapSettingTutorialText GetMapSettingTutorial(int _InherentNumber)         // Menual을 얻을 함수
    {
        for (int i = 0; i < MapSettingTutorialLength(); i++)               // Menual의 길이만큼만 돌 예정
        {
            if (MapSettingTutorials[i].InherentNumber == _InherentNumber) // Menuals[i]의 InherentNumber값과 _InherentNumber 값이 같을 경우
            {
                return MapSettingTutorials[i];                           // Menuals[i]의 값을 부른다.  
            }
        }
        return null;                                         // 같지아니할경우 null
    }

    public void MenualTextNumbering(int _idx)
    {
        //    Menuals[_idx].MenualTextDataSet(CharacteristicUsedPointValue.Instance.CUPV_CharacteristicName);
    }

}

public class MapSettingTutorialText
{
    public int InherentNumber;
    public string MenualExplanationText;
}