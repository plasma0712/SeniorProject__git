using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
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
}
