using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacteristicUIXMLLoad : Singleton<CharacteristicUIXMLLoad>
{
    public Text tPoint;

    XMLCharInfoCharacteristicPointData CurrentText;

    public void CurrentCharacteristicPointText()
    {
        CurrentText = XMLCharInfoCharacteristicPoint.Instance.GetCharacteristicPointData(0);
        tPoint.text = CurrentText.iPoint.ToString();
    }
}
