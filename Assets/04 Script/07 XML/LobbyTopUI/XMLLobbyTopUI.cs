using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;


public class XMLLobbyTopUI : Singleton<XMLLobbyTopUI>
{
    List<XMLLobbyTopUIData> LobbyTopUIs;

    string filePath = "./Assets/Resources/LobbyTopUIList.xml";

    private void Awake()
    {
        //CreateXml();
        LoadXml();
    }

    public void CreateXml()
    {
        LobbyTopUIs = new List<XMLLobbyTopUIData>();

        for (int i = 0; i < 1; i++)
        {
            XMLLobbyTopUIData LobbyTopUI = new XMLLobbyTopUIData
            {
                iGold = LobbyTopUIData.Instance.iGoldOrigin,        // XML 저장 할 것 미리 염두해두어 만들었음. 
                iSoul = LobbyTopUIData.Instance.iSoulOrigin,        // XML 저장 할 것 미리 염두해두어 만들었음. 
                iHeart = LobbyTopUIData.Instance.iHeartOrigin       // XML 저장 할 것 미리 염두해두어 만들었음. 
            };
            LobbyTopUIs.Add(LobbyTopUI);
        }

        XmlDocument Document = new XmlDocument();
        XmlElement LobbyTopUIListElement = Document.CreateElement("LobbyTopUIList");
        Document.AppendChild(LobbyTopUIListElement);

        foreach (XMLLobbyTopUIData LobbyTopUI in LobbyTopUIs)
        {
            XmlElement LobbyTopUIElement = Document.CreateElement("LobbyTopUI");
            LobbyTopUIElement.SetAttribute("iGold", LobbyTopUI.iGold.ToString());
            LobbyTopUIElement.SetAttribute("iSoul", LobbyTopUI.iSoul.ToString());
            LobbyTopUIElement.SetAttribute("iHeart", LobbyTopUI.iHeart.ToString());

            LobbyTopUIListElement.AppendChild(LobbyTopUIElement);
        }
        Document.Save(filePath);

        LoadXml();
    }


    public void LoadXml()
    {
        LobbyTopUIs = new List<XMLLobbyTopUIData>();
        XmlDocument Document = new XmlDocument();
        Document.Load(filePath);
        XmlElement LobbyTopUIListElement = Document["LobbyTopUIList"];

        foreach (XmlElement LobbyTopUIElement in LobbyTopUIListElement.ChildNodes)
        {
            XMLLobbyTopUIData LobbyTopUI = new XMLLobbyTopUIData
            {
                iGold = System.Convert.ToInt32(LobbyTopUIElement.GetAttribute("iGold")),
                iSoul = System.Convert.ToInt32(LobbyTopUIElement.GetAttribute("iSoul")),
                iHeart = System.Convert.ToInt32(LobbyTopUIElement.GetAttribute("iHeart")),
            };
            LobbyTopUIs.Add(LobbyTopUI);
        }
    }
  
    public int LobbyTopUILength()
    {
        return LobbyTopUIs.Count;
    }

    public XMLLobbyTopUIData GetLobbyTopUIData(int _num)
    {
#pragma warning disable CS0162 // 접근할 수 없는 코드가 있습니다.
        for (int i = 0; i<LobbyTopUILength(); i++)
#pragma warning restore CS0162 // 접근할 수 없는 코드가 있습니다.
        {
            return LobbyTopUIs[i];
        }
        return null;
    }



}
