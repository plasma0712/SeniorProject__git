using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;

public class TendencyUIXMLLoad : Singleton<TendencyUIXMLLoad>
{
    public Text fSanctity;
    public Text fDarkNess;
    public Text fHeart;

    XMLCharInfoTendencyData CurrentText;

    public void CurrentTendencyUIText()
    {
        CurrentText = XMLCharInfoTendency.Instance.GetTendencyData(0);
        fSanctity.text = CurrentText.fSanctity.ToString();
        fDarkNess.text = CurrentText.fDarkNess.ToString();
        fHeart.text = CurrentText.fHeart.ToString();
    }
}
