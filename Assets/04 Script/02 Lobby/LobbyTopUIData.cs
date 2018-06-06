using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyTopUIData : Singleton<LobbyTopUIData>                // 어디서든 참조 가능하게 싱글톤으로 설정
{
    public int iGold;                                                  // XML로 데이터 가져옴
    public int iGoldOrigin;
    public int iSoul;                                                  // XML로 데이터 가져옴
    public int iSoulOrigin;
    public int iHeart;                                                 // XML로 데이터 가져옴
    public int iHeartOrigin;

    XMLLobbyTopUIData CurrentData;

    private void Start()
    {
        CurrentLobbyTopUIData();
        LobbyTopUIXMLLoad.Instance.CurrentLobbyTopUIText();

        iGoldOrigin = iGold;                                            // iGold값이라는 데이터를 가지고와 변경처리해준다. 
        iSoulOrigin = iSoul;                                            // iSoul값이라는 데이터를 가지고와 변경처리해준다. 
        iHeartOrigin = iHeart;                                          // iHeart값이라는 데이터를 가지고와 변경처리해준다. 
    }

    public void CurrentLobbyTopUIData()                                 // 
    {
        CurrentData = XMLLobbyTopUI.Instance.GetLobbyTopUIData(0);
        iGold = CurrentData.iGold;
        iSoul = CurrentData.iSoul;
        iHeart = CurrentData.iHeart;
    }

    public void UseGold(int _ivalue)                                    // 금 사용할때 불러오는 함수
    {
        if (iGoldOrigin < _ivalue)                                      // 금 보유량 보다 높을땐 return
        {
            return;
        }
        else
        {
            iGoldOrigin -= _ivalue;
            XMLLobbyTopUI.Instance.CreateXml();                         // XML에 다시 저장    
            LobbyTopUIXMLLoad.Instance.CurrentLobbyTopUIText();         // XML저장 한 값을 TOP_UI창에 다시 불러줌
        }
    }

    public void UseSoul(int _ivalue)                                    // 영혼 사용할때 불러오는 함수
    {
        if (iSoulOrigin < _ivalue)                                      // 영혼 보유량 보다 높을땐 return
        {
            return;
        }
        else
        {
            iSoulOrigin -= _ivalue;
            XMLLobbyTopUI.Instance.CreateXml();                         // XML에 다시 저장    
            LobbyTopUIXMLLoad.Instance.CurrentLobbyTopUIText();         // XML저장 한 값을 TOP_UI창에 다시 불러줌
        }
    }

    public void UseHeart(int _ivalue)                                   // 하트 사용할때 불러오는 함수
    {
        if (iHeartOrigin < _ivalue)                                     // 하트 보유량보다 높을때 return
        {
            return;
        }
        else
        {
            iHeartOrigin -= _ivalue;
            XMLLobbyTopUI.Instance.CreateXml();                         // XML에 다시 저장    
            LobbyTopUIXMLLoad.Instance.CurrentLobbyTopUIText();         // XML저장 한 값을 TOP_UI창에 다시 불러줌
        }
    }

    public void GetGold(int _ivalue)                                    // 금 얻을때 불러오는 함수
    {
        iGoldOrigin += _ivalue;
        XMLLobbyTopUI.Instance.CreateXml();                             // XML에 다시 저장    
        LobbyTopUIXMLLoad.Instance.CurrentLobbyTopUIText();             // XML저장 한 값을 TOP_UI창에 다시 불러줌
    }

    public void GetSoul(int _ivalue)                                    // 영혼 얻을때 불러오는 함수
    {
        iSoulOrigin += _ivalue;
        XMLLobbyTopUI.Instance.CreateXml();                             // XML에 다시 저장    
        LobbyTopUIXMLLoad.Instance.CurrentLobbyTopUIText();             // XML저장 한 값을 TOP_UI창에 다시 불러줌
    }

    public void GetHeart(int _ivalue)                                   // 하트 얻을때 불러오는 함수
    {
        iHeartOrigin += _ivalue;
        XMLLobbyTopUI.Instance.CreateXml();                             // XML에 다시 저장    
        LobbyTopUIXMLLoad.Instance.CurrentLobbyTopUIText();             // XML저장 한 값을 TOP_UI창에 다시 불러줌
    }


    public void MonsterSummonUseGold(int _ivalue)                                    // 금 사용할때 불러오는 함수
    {
        if (iGoldOrigin < _ivalue)                                      // 금 보유량 보다 높을땐 return
        {
            MonsterSummon.Instance.FundGoldUse = false;
            return;
        }
        else
        {
            MonsterSummon.Instance.FundGoldUse = true;
            iGoldOrigin -= _ivalue;
            XMLLobbyTopUI.Instance.CreateXml();                         // XML에 다시 저장    
            LobbyTopUIXMLLoad.Instance.CurrentLobbyTopUIText();         // XML저장 한 값을 TOP_UI창에 다시 불러줌
        }
    }

    public void MonsterSummonUseSoul(int _ivalue)                                    // 영혼 사용할때 불러오는 함수
    {
        if (iSoulOrigin < _ivalue)                                      // 영혼 보유량 보다 높을땐 return
        {
            MonsterSummon.Instance.FundSoulUse = false;
            return;
        }
        else
        {
            MonsterSummon.Instance.FundSoulUse = true;
            iSoulOrigin -= _ivalue;
            XMLLobbyTopUI.Instance.CreateXml();                         // XML에 다시 저장    
            LobbyTopUIXMLLoad.Instance.CurrentLobbyTopUIText();         // XML저장 한 값을 TOP_UI창에 다시 불러줌
        }
    }
}
