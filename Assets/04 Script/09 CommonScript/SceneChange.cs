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
        SceneManager.LoadScene("MapSettingTutorial");
    }

    public void MapSettingGameStartTutorial()
    {
        SceneManager.LoadScene("GameStartTutorial");
    }

}
