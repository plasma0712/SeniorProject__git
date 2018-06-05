using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class CharInfo_MenualPopUp : MonoBehaviour
{
    public int CharacteristicButtonInfo;   // 버튼마다 특정 고유번호를 주어 XML로 저장된 파일 검사를 통해 이름을 가지고 올 예정
    public GameObject MenuPopUp;
    public Text MenualText;

    MenualText CurrentText; // 현재 텍스트

    public void CurrentMenualText() // 현재메뉴의 텍스트를 불러오는 함수 
    {
        CurrentText = XMLMenual.Instance.GetMenual(CharacteristicButtonInfo); // XMLMenual에 있는 GetMenual함수를 통해 현재 번호(특성의 이름)와 같은 배열에 있는 특정 정보를 불러온다.
        MenualText.text = CurrentText.MenualExplanationText;                  // CurrentText에 담긴 정보중 MenualExplantionText의 정보를 불러와 MenualText를 불러온다.
    }

    public void OnMouseEnter()
    {
        StartCoroutine("MenuPostion");                          // MenuPostion이라는 이름을 가진 코루틴 시작
    }

    public void OnMouseExit()
    {
        StopCoroutine("MenuPostion");                           // MenuPostion이라는 이름을 가진 코루틴 종료
        MenuPopUp.SetActive(false);                             // 특성메뉴얼을 끈다.
    }

    // 메뉴얼은 피벗에 의해 위치도 변경이 되기때문에 이쁜 UI/UX를 원한다면 건드려 볼 필요성이 있다.

    IEnumerator MenuPostion() // 마우스의 포지션을 0.02f만큼의 시간간격으로 불러와 메뉴를 이동시킨다. 
    {                         // 이렇게 진행을 할경우 update를 통해 쓸때없는 호출을 줄이면서, 정보창을 어느 포지션이든 자연스럽게 보이게 할 수 있다.
        while (true)
        {
            yield return new WaitForSeconds(0.02f);
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 타겟의 위치 즉 마우스 좌표 값.
            MenuPopUp.transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, target);  //마우스 포지션먼저 가져오기 (순서때문에 꼬일 가능성 다분)
            MenuPopUp.SetActive(true); // 특성메뉴얼을 킨다.
            CurrentMenualText(); // 함수를 호출하여 MenualText의 텍스트를 변경한다.
        }
    }

}
