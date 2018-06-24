using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : Singleton <SceneChange>
{
    public void LobbyMapSceneChange()
    {
        SceneManager.LoadScene("TestMap");
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
        SceneManager.LoadScene("TestMap2");
    }
}
