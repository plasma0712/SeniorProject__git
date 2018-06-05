using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XMLMonsterSummon : Singleton<XMLMonsterSummon>
{
    List<XMLMonsterSummonData> MonsterSummons;

    //XmlElement MonsterSummonListElement;

    string filePath = "./Assets/Resources/MonsterSummonList.xml";

    private void Awake()
    {
        LoadXml();
    }

    public void Create()
    {
        MonsterSummons = new List<XMLMonsterSummonData>();
        XmlDocument Document = new XmlDocument();
        XmlElement MonsterSummonListElement = Document.CreateElement("MonsterSummonList");
        Document.AppendChild(MonsterSummonListElement);
        Document.Save(filePath);
    }

    public void LoadXml()
    {
        MonsterSummons = new List<XMLMonsterSummonData>();
        XmlDocument Document = new XmlDocument();
        Document.Load(filePath);
        XmlElement MonsterSummonListElement = Document["MonsterSummonList"];

        foreach(XmlElement MonsterSummonElement in MonsterSummonListElement.ChildNodes)
        {
            XMLMonsterSummonData MonsterSummon = new XMLMonsterSummonData
            {
                InherentNumber = System.Convert.ToInt32(MonsterSummonElement.GetAttribute("InherentNumber")),
                fPosX = System.Convert.ToSingle(MonsterSummonElement.GetAttribute("fPosX")),
                fPosY = System.Convert.ToSingle(MonsterSummonElement.GetAttribute("fPosY")),
            };
            MonsterSummons.Add(MonsterSummon);
        }
    }

    public void AddXmlNode(string iCount,string InherentNumber, string fPosX, string fPosY)
    {
        MonsterSummons = new List<XMLMonsterSummonData>();
        XmlDocument Document = new XmlDocument();
        Document.Load(filePath);
        XmlElement MonsterSummonListElement = Document["MonsterSummonList"];

        XmlNode node = Document.DocumentElement;
        XmlElement childNode = Document.CreateElement("MonsterSummon");

        childNode.SetAttribute("iCount", iCount);
        childNode.SetAttribute("InherentNumber", InherentNumber);
        childNode.SetAttribute("fPosX", fPosX);
        childNode.SetAttribute("fPosY", fPosY);

        MonsterSummonListElement.AppendChild(childNode);

        Document.Save(filePath);
    }

    public int MonsterSummonLegth()
    {
        return MonsterSummons.Count;
    }


    public XMLMonsterSummonData GetMonsterSummonData(int _num)
    {
        for(int i =0; i< MonsterSummonLegth(); i++)
        {
            if(MonsterSummons[i].InherentNumber == _num)
            {
                return MonsterSummons[i];
            }
        }
        return null;
    }
}
