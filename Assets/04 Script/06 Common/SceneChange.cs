using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : Singleton <SceneChange>
{
    public void LobbyMapSceneChange()
    {
        SceneManager.LoadScene("MapSetting");
    }

    public void MapLobbySceneChange()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void IntroLobbySceneChange()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void LobbyStartGameSceneChange()
    {
        SceneManager.LoadScene("GameStart");
    }

    /////////////////////////////////////////////////////////////////////////////
    public void IntroMapSettingTutorial()
    {
        XMLCharInfoCharacteristicPoint.Instance.NewGameCreateXml();
        XMLCharInfoTendency.Instance.NewGameCreateXml();
        XMLLobbyTopUI.Instance.NewGameCreateXml();
        XMLCharInfoCharacteristic.Instance.CreateXml();
        XMLMonsterSummon.Instance.Create();
        XMLMonsterListUnLock.Instance.Create();
        XMLMonsterListUnLock.Instance.AddXmlNode(XMLMonsterListUnLock.Instance.MonsterListUnLockLegth().ToString(), 1.ToString());// 몬스터 락

        //넘어가기전에 XML을 Create해야하기 때문에(NEW 게임이니깐) 
        SceneManager.LoadScene("MapSettingTutorial");
    }

    public void MapSettingGameStartTutorial()
    {
        SceneManager.LoadScene("GameStartTutorial");
    }

}
