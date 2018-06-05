using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TendencyUIData : Singleton<TendencyUIData>
{
    public float fSanctity;    // 선
    public float fDarkNess;    // 악
    public float fHeart;       // 선+악 합산치?

    public float fSanctityOrigin;    // 선
    public float fDarkNessOrigin;    // 악
    public float fHeartOrigin;           // 선+악 합산치?

    float fSanctityRatio;   //선 비율
    float fDarkNessRatio;   //악 비율

    public GameObject[] gHeartRatioAccording; // 선악비율에 따라 이미지 변경

    XMLCharInfoTendencyData CurrentData;

    private void Start()        // 게임프로젝트가 실행되었을 때 단 한번 실행할 함수
    {
        CurrenTendencyData();   // XML에서 데이터를 가지고와서 fSanctity,fDarkNess,fHeart에 데이터값을 넣어준다.
        TendencyUIXMLLoad.Instance.CurrentTendencyUIText(); // XML데이터를 이용해 UI데이터를 변경하는 스크립트 호출
        fSanctityOrigin = fSanctity;            // XML데이터값을 받은 fSanctity값이 fSanctityOrigin을 초기화
        fDarkNessOrigin = fDarkNess;            // XML데이터값을 받은 fDarkNess값이 fDarkNessOrigin을 초기화
        fHeartOrigin = fHeart;                  // XML데이터값을 받은 fHeart값이 fHeartOrigin을 초기화
        HeartRatio();                           // 심성 비율을 계산해주는 함수를 호출
        HeartCompare();                         // 선 악 비교함수를 함수
    }

    public void CurrenTendencyData() // XML에서 데이터를 가지고와서 fSanctity,fDarkNess,fHeart에 데이터값을 변경
    {
        CurrentData = XMLCharInfoTendency.Instance.GetTendencyData(0);
        fSanctity = CurrentData.fSanctity;
        fDarkNess = CurrentData.fDarkNess;
        fHeart = CurrentData.fHeart;
    }

    void HeartRatio()       // 심성 비율나타내는 함수
    {
        fHeartOrigin = (fSanctityOrigin + fDarkNessOrigin);
        if (fHeartOrigin == 0)
        {
            fSanctityRatio = 0;
            fDarkNessRatio = 0;
        }
        else
        {
            fSanctityRatio = (fSanctityOrigin / fHeartOrigin) * 100; // 선 비율
            fDarkNessRatio = (fDarkNessOrigin / fHeartOrigin) * 100; // 악 비율
        }
    }

    void HeartCompare() // 선 악 비교함수
    {
        if (fSanctityRatio == fDarkNessRatio)               
        {   // 중립 표시            
            gHeartRatioAccording[0].SetActive(true);
            gHeartRatioAccording[1].SetActive(false);
            gHeartRatioAccording[2].SetActive(false);
        }
        else if (fSanctityRatio > fDarkNessRatio)
        {   // 선 표시            
            gHeartRatioAccording[0].SetActive(false);
            gHeartRatioAccording[1].SetActive(true);
            gHeartRatioAccording[2].SetActive(false);
        }
        else
        {   // 악 표시            
            gHeartRatioAccording[0].SetActive(false);
            gHeartRatioAccording[1].SetActive(false);
            gHeartRatioAccording[2].SetActive(true);
        }
    }

    public void GetSanctity(float _ivalue)              // 선 지수 얻을 때 이용할 함수
    {
        fSanctityOrigin += _ivalue;
        HeartRatio();
        HeartCompare();
        XMLCharInfoTendency.Instance.CreateXml();
        TendencyUIXMLLoad.Instance.CurrentTendencyUIText();
    }

    public void GetDarkNess(float _ivalue)              // 악 지수 얻을 때 이용할 함수
    {
        fDarkNessOrigin += _ivalue;
        HeartRatio();
        HeartCompare();
        XMLCharInfoTendency.Instance.CreateXml();
        TendencyUIXMLLoad.Instance.CurrentTendencyUIText();
    }

    public void Reset(float _ivalue)            // 데이터 리셋필요해서 만든것이므로 완성본에선 삭제할 함수
    {
        fSanctityOrigin = _ivalue;
        fDarkNessOrigin = _ivalue;
        fHeartOrigin = _ivalue;
        HeartRatio();
        HeartCompare();
        XMLCharInfoTendency.Instance.CreateXml();
        TendencyUIXMLLoad.Instance.CurrentTendencyUIText();
    }
}
