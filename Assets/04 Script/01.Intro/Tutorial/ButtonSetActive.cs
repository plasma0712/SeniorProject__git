using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSetActive : Singleton <ButtonSetActive>
{
    public GameObject Before;
    public GameObject Next;
    public GameObject Finish;

    public void Update()
    {
        if(TutorialText.Instance.TextNumber>0 && TutorialText.Instance.TextNumber<XMLMapSettingTutorial.Instance.MapSettingTutorialLength())
        {
            Before.gameObject.SetActive(true);
        }
        else if(TutorialText.Instance.TextNumber<=0)
        {
            Before.gameObject.SetActive(false);
        }

        if(TutorialText.Instance.TextNumber==XMLMapSettingTutorial.Instance.MapSettingTutorialLength()-1)
        {
            Before.gameObject.SetActive(false);
            Next.gameObject.SetActive(false);
            Finish.gameObject.SetActive(true);
            TutorialText.Instance.gameObject.SetActive(true);
        }
    }
}
