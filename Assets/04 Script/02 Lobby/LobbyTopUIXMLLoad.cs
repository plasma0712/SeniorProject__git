using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;

public class LobbyTopUIXMLLoad : Singleton<LobbyTopUIXMLLoad>
{
    public Text tGold;
    public Text tSoul;
    public Text tHeart;

    XMLLobbyTopUIData CurrentText;

    public void CurrentLobbyTopUIText()
    {
        CurrentText = XMLLobbyTopUI.Instance.GetLobbyTopUIData(0);
        tGold.text = CurrentText.iGold.ToString();
        tSoul.text = CurrentText.iSoul.ToString();
        tHeart.text = CurrentText.iHeart.ToString();
    }


}
