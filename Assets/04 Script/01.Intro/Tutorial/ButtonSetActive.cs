using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSetActive : Singleton <ButtonSetActive>
{
    public GameObject Next;
    public GameObject Finish;

    public void Update()
    {

        //if(TutorialText.Instance.TextNumber==XMLMapSettingTutorial.Instance.MapSettingTutorialLength()-1)
        //{
        //    Next.gameObject.SetActive(false);
        //    Finish.gameObject.SetActive(true);
        //    TutorialText.Instance.gameObject.SetActive(true);
        //}
    }
}
