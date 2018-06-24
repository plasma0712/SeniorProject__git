using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieSceneSetActive : MonoBehaviour
{
    public GameObject Movie;
    public GameObject Scene;

    public void MovieScene()
    {
        Movie.gameObject.SetActive(false);
        Scene.gameObject.SetActive(true);
    }
}
