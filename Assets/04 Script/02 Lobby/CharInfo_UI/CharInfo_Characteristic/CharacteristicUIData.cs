using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class CharacteristicUIData : Singleton<CharacteristicUIData>
{   
    public float CharacteristicPointOriginal; // 플레이어 원래 특성포인트
    public float CharacteristicPoint;         // 플레이어 남은 특성포인트

    float CharacteristicUsePoint;      // 플레이어 특성포인트 사용
    float CharacteristicPointValue;    // 플레이어 특성에 대한 포인트 가치

    //public Text CharacteristicPointOriginalText; // 플레이어 원래 특성포인트의 텍스트
    public int CharacteristicInherentNumber;

    public XMLCharInfoCharacteristicData CurrentData;
    public XMLCharInfoCharacteristicPointData CurrentPointData;

    private void Start()
    {
        CurrentCharacteristicPointData();
        CharacteristicUIXMLLoad.Instance.CurrentCharacteristicPointText();
        CharacteristicPointOriginal = CharacteristicPoint;  
    }
    
    public void CurrentCharacteristicData(int _value)
    {
        CurrentData = XMLCharInfoCharacteristic.Instance.GetCharacteristic(_value);
    }

    public void CharacteristicPointLeave() // 플레이어가 가지고있는 최종 특성포인트 계산함수
    {
        CharacteristicPoint -= CharacteristicUsePoint; //
    }

    public void CharacteristicUsedPoint(float CharacteristicPointValue) //플레이어가 특성포인트 사용
    {
        CharacteristicUsePoint = CharacteristicPointValue;
        XMLCharInfoCharacteristicPoint.Instance.CreateXml();
    }

    public void CurrentCharacteristicPointData()
    {
        CurrentPointData = XMLCharInfoCharacteristicPoint.Instance.GetCharacteristicPointData(0);
        CharacteristicPoint = CurrentPointData.iPoint;
    }

    public void GetCharacteristicPoint(int _ipoint)
    {
        CharacteristicPoint += _ipoint;
        XMLCharInfoCharacteristicPoint.Instance.CreateXml();
        XMLCharInfoCharacteristicPoint.Instance.LoadXml();
        CharacteristicUIXMLLoad.Instance.CurrentCharacteristicPointText();
    }


}

/*
{   
    public float CharacteristicPointOriginal; // 플레이어 원래 특성포인트
public float CharacteristicPoint;         // 플레이어 남은 특성포인트

float CharacteristicUsePoint;      // 플레이어 특성포인트 사용
float CharacteristicPointValue;    // 플레이어 특성에 대한 포인트 가치

public Text CharacteristicPointOriginalText; // 플레이어 원래 특성포인트의 텍스트
public int CharacteristicInherentNumber;

XMLCharInfoCharacteristicData CurrentData;
XMLCharInfoCharacteristicPointData CurrentPointData;

private void Start()
{
    CharacteristicPointOriginal = 100;  //예시로 해놓음
    CharacteristicPoint = CharacteristicPointOriginal;
    CharacteristicPointOriginalText.text = CharacteristicPoint.ToString();
}

public void CurrentCharacteristicData(int _value)
{
    CurrentData = XMLCharInfoCharacteristic.Instance.GetCharacteristic(_value);
    Debug.Log(CurrentData.InherentNumber);
    Debug.Log(CurrentData.Point);
    Debug.Log(CurrentData.Bool);
}


public void CharacteristicPointLeave() // 플레이어가 가지고있는 최종 특성포인트 계산함수
{
    CharacteristicPoint -= CharacteristicUsePoint; //
    CharacteristicPointOriginalText.text = CharacteristicPoint.ToString();
}

public void CharacteristicUsedPoint(float CharacteristicPointValue) //플레이어가 특성포인트 사용
{
    CharacteristicUsePoint = CharacteristicPointValue;
}
}
*/