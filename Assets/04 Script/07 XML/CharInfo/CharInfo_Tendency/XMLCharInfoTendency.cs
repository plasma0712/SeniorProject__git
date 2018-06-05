using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XMLCharInfoTendency : Singleton<XMLCharInfoTendency>
{
    List<XMLCharInfoTendencyData> Tendencys;

    string filePath = "./Assets/Resources/TendencyList.xml";

    private void Awake()
    {
       //  CreateXml();
         LoadXml();
    }

    public void CreateXml()
    {
        Tendencys = new List<XMLCharInfoTendencyData>();

        for (int i = 0; i < 1; i++)
        {
            XMLCharInfoTendencyData Tendency = new XMLCharInfoTendencyData
            {
                fSanctity = TendencyUIData.Instance.fSanctityOrigin,
                fDarkNess = TendencyUIData.Instance.fDarkNessOrigin,
                fHeart = TendencyUIData.Instance.fHeartOrigin
            };
            Tendencys.Add(Tendency);
        }

        XmlDocument Document = new XmlDocument();
        XmlElement TendencyListElement = Document.CreateElement("TendencyList");
        Document.AppendChild(TendencyListElement);

        foreach (XMLCharInfoTendencyData Tendency in Tendencys)
        {
            XmlElement TendencyElement = Document.CreateElement("Tendency");
            TendencyElement.SetAttribute("fSanctity", Tendency.fSanctity.ToString());
            TendencyElement.SetAttribute("fDarkNess", Tendency.fDarkNess.ToString());
            TendencyElement.SetAttribute("fHeart", Tendency.fHeart.ToString());

            TendencyListElement.AppendChild(TendencyElement);
        }
        Document.Save(filePath);                                     
    }

    public void LoadXml()
    {
        Tendencys = new List<XMLCharInfoTendencyData>();
        XmlDocument Document = new XmlDocument();
        Document.Load(filePath);
        XmlElement TendencyListElement = Document["TendencyList"];

        foreach(XmlElement TendencyElement in TendencyListElement.ChildNodes)
        {
            XMLCharInfoTendencyData Tendency = new XMLCharInfoTendencyData
            {
                fSanctity = System.Convert.ToSingle(TendencyElement.GetAttribute("fSanctity")),
                fDarkNess = System.Convert.ToSingle(TendencyElement.GetAttribute("fDarkNess")),
                fHeart = System.Convert.ToSingle(TendencyElement.GetAttribute("fHeart")),
            };
 //           Debug.Log(TendencyElement.GetAttribute("fSanctity"));
            Tendencys.Add(Tendency);
        }
    }

    public int TendencyLength()
    {
        return Tendencys.Count;
    }

    public XMLCharInfoTendencyData GetTendencyData(int _num)
    {
#pragma warning disable CS0162 // 접근할 수 없는 코드가 있습니다.
        for (int i = 0; i<TendencyLength(); i++)
#pragma warning restore CS0162 // 접근할 수 없는 코드가 있습니다.
        {
            return Tendencys[i];
        }
        return null;
    }

}
