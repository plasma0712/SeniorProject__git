using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XMLCharInfoCharacteristicPoint : Singleton<XMLCharInfoCharacteristicPoint>
{
    List<XMLCharInfoCharacteristicPointData> CharacteristicPoints;

    string filePath = "./Assets/Resources/CharacteristicPointList.xml";

    private void Awake()
    {
        //CreateXml();
        LoadXml();
    }

    public void CreateXml()
    {
        CharacteristicPoints = new List<XMLCharInfoCharacteristicPointData>();

        for (int i = 0; i < 1; i++)
        {
            XMLCharInfoCharacteristicPointData CharacteristicPoint = new XMLCharInfoCharacteristicPointData
            {
                iPoint = (int)CharacteristicUIData.Instance.CharacteristicPoint,
            };
            CharacteristicPoints.Add(CharacteristicPoint);
        }

        XmlDocument Document = new XmlDocument();
        XmlElement CharacteristicPointListElement = Document.CreateElement("CharacteristicPointList");
        Document.AppendChild(CharacteristicPointListElement);

        foreach (XMLCharInfoCharacteristicPointData CharacteristicPoint in CharacteristicPoints)
        {
            XmlElement CharacteristicPointElement = Document.CreateElement("CharacteristicPoint");
            CharacteristicPointElement.SetAttribute("iPoint", CharacteristicPoint.iPoint.ToString());

            CharacteristicPointListElement.AppendChild(CharacteristicPointElement);
        }
        Document.Save(filePath);

        LoadXml();
    }

    public void LoadXml()
    {
        CharacteristicPoints = new List<XMLCharInfoCharacteristicPointData>();
        XmlDocument Document = new XmlDocument();
        Document.Load(filePath);
        XmlElement CharacteristicPointListElement = Document["CharacteristicPointList"];

        foreach (XmlElement CharacteristicPointElement in CharacteristicPointListElement.ChildNodes)
        {
            XMLCharInfoCharacteristicPointData CharacteristicPoint = new XMLCharInfoCharacteristicPointData
            {
                iPoint = System.Convert.ToInt32(CharacteristicPointElement.GetAttribute("iPoint")),
            };
            CharacteristicPoints.Add(CharacteristicPoint);
        }
    }

    public int CharacteristicPointLength()
    {
        return CharacteristicPoints.Count;
    }

    public XMLCharInfoCharacteristicPointData GetCharacteristicPointData(int _num)
    {
#pragma warning disable CS0162 // 접근할 수 없는 코드가 있습니다.
        for (int i = 0; i< CharacteristicPointLength(); i++)
#pragma warning restore CS0162 // 접근할 수 없는 코드가 있습니다.
        {
            return CharacteristicPoints[i];
        }
        return null;
    }
}


