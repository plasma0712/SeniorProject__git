using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XMLCharInfoCharacteristic : Singleton<XMLCharInfoCharacteristic>
{
    List<XMLCharInfoCharacteristicData> Characteristics;
    XMLCharInfoCharacteristicData CurrentData;
    int[] num = new int[30];

    string filePath = "./Assets/Resources/CharacteristicList.xml";

    XmlElement CharacteristicListElement;       // 이거 필수 ㄹㅇ루다...

    private void Awake()
    {
        //CreateXml();
        //SortListXML();
        LoadXml();
        // CurrentDataNum();
    }
    public void CurrentDataNum()
    {
        for (int k = 0; k < 30; k++)
        {
            CurrentData = GetCharacteristic(k);
            num[k] = CurrentData.Bool;
        }
    }

    /* public void CreateXml()
     {
         Characteristics = new List<XMLCharInfoCharacteristicData>();

         for (int i = 0; i < 30; i++)
         {
             XMLCharInfoCharacteristicData Characteristic = new XMLCharInfoCharacteristicData();
             CurrentData = GetCharacteristic(i);
             Characteristic.InherentNumber = i;
             Characteristic.Bool = 0;
             Characteristics.Add(Characteristic);
             /*
                 if (CharacteristicUsedPointValue.Instance.tmp == i)
                 {   
                     Characteristic.InherentNumber = i;
                     Characteristic.Bool = 1;
                 }
                 else if(CharacteristicUsedPointValue.Instance.tmp !=i)
                 {
                     if(CharacteristicUsedPointValue.Instance.abc ==1)
                     {
                         Characteristic.InherentNumber = i;
                         Characteristic.Bool = 1;
                     }
                     if(CharacteristicUsedPointValue.Instance.abc !=1)
                     {
                         Characteristic.InherentNumber = i;
                         Characteristic.Bool = 0;
                     }
                 }
                 else
                 {
                     return;
                 }

         }

         XmlDocument Document = new XmlDocument();
         XmlElement CharacteristicListElement = Document.CreateElement("CharacteristicList");
         Document.AppendChild(CharacteristicListElement);

         foreach (XMLCharInfoCharacteristicData Characteristic in Characteristics)
         {
             XmlElement CharacteristicElement = Document.CreateElement("Characteristic");
             CharacteristicElement.SetAttribute("InherentNumber", Characteristic.InherentNumber.ToString());
             CharacteristicElement.SetAttribute("Bool", Characteristic.Bool.ToString());

             CharacteristicListElement.AppendChild(CharacteristicElement);
         }
         //Document.Save(Application.dataPath+filePath);
         Document.Save(filePath);
     }
     */
    public void CreateXml()
    {
        Characteristics = new List<XMLCharInfoCharacteristicData>();
        XmlDocument Document = new XmlDocument();
        XmlElement CharacteristicListElement = Document.CreateElement("CharacteristicList");
        Document.AppendChild(CharacteristicListElement);
        Document.Save(filePath);
    }

    public void LoadXml()
    {
        Characteristics = new List<XMLCharInfoCharacteristicData>();
        XmlDocument Document = new XmlDocument();
        Document.Load(filePath);
        XmlElement CharacteristicListElement = Document["CharacteristicList"];


        foreach (XmlElement CharacteristicElement in CharacteristicListElement.ChildNodes)
        {
            XMLCharInfoCharacteristicData Characteristic = new XMLCharInfoCharacteristicData
            {
                InherentNumber = System.Convert.ToInt32(CharacteristicElement.GetAttribute("InherentNumber")),
                //             Point = System.Convert.ToInt32(CharacteristicElement.GetAttribute("Point")),
                Bool = System.Convert.ToInt32(CharacteristicElement.GetAttribute("Bool")),
            };
            // Debug.Log(CharacteristicElement.GetAttribute("InherentNumber"));
            Characteristics.Add(Characteristic);
        }
    }

    public void AddXmlNode(string InherentNumber, string Bool)
    {
        Characteristics = new List<XMLCharInfoCharacteristicData>();
        XmlDocument Document = new XmlDocument();
        Document.Load(filePath);
        XmlElement CharacteristicListElement = Document["CharacteristicList"];

        XmlNode node = Document.DocumentElement;
        //        XmlElement root = Document.CreateElement("가나다라");

        XmlElement childNode = Document.CreateElement("Characteristic");

        childNode.SetAttribute("InherentNumber", InherentNumber);
        childNode.SetAttribute("Bool", Bool);

        CharacteristicListElement.AppendChild(childNode);
        //node.AppendChild(root);

        Document.Save(filePath);

    }

    public void RemoveXmlNode(string InherentNumber, string Bool)
    {
        Characteristics = new List<XMLCharInfoCharacteristicData>();
        XmlDocument Document = new XmlDocument();
        Document.Load(filePath);
        XmlNode node = Document.SelectSingleNode("/descendant::CharacteristicList/Characteristic");
        XmlAttributeCollection acxNode = node.Attributes;
        if (acxNode.GetNamedItem("InherentNumber" + InherentNumber).Value != null)
        {
            Debug.Log("아아");
            acxNode.GetNamedItem("Bool").Value = "1";
        }
        else
        {
            return;
        }
        Document.Save(filePath);

    }

    /*
    public void CreateNodeChangeXML(int _InherentNumber)                //xml 노드추가
    {
        LoadXml();
        Characteristics = new List<XMLCharInfoCharacteristicData>();
        XMLCharInfoCharacteristicData Characteristic = new XMLCharInfoCharacteristicData();
        CurrentData = GetCharacteristic(_InherentNumber);
        Characteristic.InherentNumber = _InherentNumber;
        Characteristic.Bool = 1;
        Characteristics.Add(Characteristic);

        XmlDocument Document = new XmlDocument();
        XmlElement CharacteristicListElement = Document.CreateElement("CharacteristicList");
        Document.AppendChild(CharacteristicListElement);

        XmlElement CharacteristicElement = Document.CreateElement("Characteristic");
        CharacteristicElement.SetAttribute("InherentNumber", Characteristic.InherentNumber.ToString());
        CharacteristicElement.SetAttribute("Bool", Characteristic.Bool.ToString());

        CharacteristicListElement.AppendChild(CharacteristicElement);

        Document.Save(filePath);
    }

    public void RemoveXMLNode(int _InherentNumber)      // 특정 리스트 삭제
    {
        Characteristics = new List<XMLCharInfoCharacteristicData>();

        LoadXml();

        Characteristics.RemoveAt(_InherentNumber);
    }

    public void SortListXML()       // 정렬
    {
        Characteristics = new List<XMLCharInfoCharacteristicData>();

        LoadXml();
        Characteristics.Sort(delegate(XMLCharInfoCharacteristicData A, XMLCharInfoCharacteristicData B)
        {
            if(A.InherentNumber>B.InherentNumber)
            {
                return 1;
            }
            else if (A.InherentNumber<B.InherentNumber)
            {
                return -1;
            }
            return 0;
        });
        

    }

    */          // 리스트를 이용하려고 했는데 XML을 건드려야 하는 문제였기에 사용이 불가한거같다.


    public int CharacteristicLength() // 길이값을 구하는 함수
    {
        return Characteristics.Count;
    }

    public XMLCharInfoCharacteristicData GetCharacteristic(int _InherentNumber) // Characteristic 얻을 함수
    {
        for (int i = 0; i < CharacteristicLength(); i++)         // Characteristic 길이만큼만 돌 예정
        {
            if (Characteristics[i].InherentNumber == _InherentNumber) // Characteristics[i]의 InherentNumber값과 _InherentNumber 값이 같을 경우
            {
                return Characteristics[i];                           // Characteristics[i]의 값을 부른다.  
            }
        }
        return null;                                         // 같지아니할경우 null
    }



}
