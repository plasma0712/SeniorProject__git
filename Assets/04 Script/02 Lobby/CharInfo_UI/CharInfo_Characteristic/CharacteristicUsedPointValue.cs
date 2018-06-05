using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacteristicUsedPointValue : Singleton<CharacteristicUsedPointValue> // 특성마다 포인트가치가 다르기 때문에 따로 스크립트를 뽑은것
{                                                                                   // 어디서든 참조 가능하게 싱글톤으로 설정
    public float CUPV_CharacteristicName;       // 플레이어 특성에 대한 고유이름
    public float CUPV_CharacteristicPointValue; // 플레이어 특성에 대한 포인트 가치
    float BoolCheck;

    public GameObject Transparency;             // 투명 오브젝트
    XMLCharInfoCharacteristicData CurrentData;

    private void Start()
    {
        TransparencyLoad();
    }

    public void TransparencyLoad()
    {
        CurrentData = XMLCharInfoCharacteristic.Instance.GetCharacteristic((int)CUPV_CharacteristicName);
        if (CurrentData.Bool == 1)
        {
            Transparency.SetActive(false);
            BoolCheck = 1;
        }
    }

    public void CharacteristicUsed() // 특성 사용함수
    {
        if (BoolCheck == 1)
        {
            return;
        }
        else
        {
            if (CharacteristicUIData.Instance.CharacteristicPoint >= CUPV_CharacteristicPointValue) // 특성포인트가 특성가치보다 높거나 같을경우만 실행
            {
                CharacteristicUIData.Instance.CharacteristicUsedPoint(CUPV_CharacteristicPointValue);// 플레이어가 특성포인트 사용
                CharacteristicUIData.Instance.CharacteristicPointLeave();// 플레이어가 가지고있는 최종 특성포인트 계산함수
                XMLCharInfoCharacteristic.Instance.AddXmlNode(CUPV_CharacteristicName.ToString(), "1"); // 이름,"1"=>Bool값
                XMLCharInfoCharacteristicPoint.Instance.CreateXml();
                XMLCharInfoCharacteristic.Instance.LoadXml();
                CharacteristicUIXMLLoad.Instance.CurrentCharacteristicPointText();
                TransparencyLoad();
            }
            else
            {
                return;
            }
        }
    }
}

