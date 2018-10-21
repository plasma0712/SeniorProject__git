using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XMLMonsterListUnLock : Singleton<XMLMonsterListUnLock>
{
    List<XMLMonsterListUnLockData> MonsterListUnLocks;

    string filePath = "./Assets/Resources/MonsterListUnLockList.xml";

    private void Awake()
    {
        //Create();
        LoadXml();
    }

    public void Create()
    {
        MonsterListUnLocks = new List<XMLMonsterListUnLockData>();
        XmlDocument Document = new XmlDocument();
        XmlElement MonsterListUnLockListElement = Document.CreateElement("MonsterListUnLockList");
        Document.AppendChild(MonsterListUnLockListElement);
        Document.Save(filePath);
    }

    public void LoadXml()
    {
        MonsterListUnLocks = new List<XMLMonsterListUnLockData>();
        XmlDocument Document = new XmlDocument();
        Document.Load(filePath);
        XmlElement MonsterListUnLockListElement = Document["MonsterListUnLockList"];

        foreach (XmlElement MonsterListUnLockElement in MonsterListUnLockListElement.ChildNodes)
        {
            XMLMonsterListUnLockData MonsterListUnLock = new XMLMonsterListUnLockData
            {
                InherentNumber = System.Convert.ToInt32(MonsterListUnLockElement.GetAttribute("InherentNumber")),
                UnLock = System.Convert.ToInt32(MonsterListUnLockElement.GetAttribute("UnLock")),
            };
            MonsterListUnLocks.Add(MonsterListUnLock);
        }
    }

    public void AddXmlNode(string InherentNumber,string UnLock)
    {
        MonsterListUnLocks = new List<XMLMonsterListUnLockData>();
        XmlDocument Document = new XmlDocument();
        Document.Load(filePath);
        XmlElement MonsterListUnLockListElement = Document["MonsterListUnLockList"];

        XmlNode node = Document.DocumentElement;
        XmlElement childNode = Document.CreateElement("MonsterListUnLock");

        childNode.SetAttribute("InherentNumber", InherentNumber);
        childNode.SetAttribute("UnLock", UnLock);

        MonsterListUnLockListElement.AppendChild(childNode);
        Document.Save(filePath);

    }

    public int MonsterListUnLockLegth()
    {
        return MonsterListUnLocks.Count;
    }

    public XMLMonsterListUnLockData GetMonsterListUnLockData(int _num)
    {
        for (int i = 0; i < MonsterListUnLockLegth(); i++)
        {
            if(MonsterListUnLocks[i].InherentNumber == _num)
            {
                return MonsterListUnLocks[i];
            }
        }
        return null;
    }
}
