using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_animaiton : MonoBehaviour
{
    // 유니티 UI 애니메이션을 넣어 활용하기가 까다로워 임시방편
    // 01. image는 애니메이션이 바뀔 gameobject
    // 02. sprites는 애니메이션을 강제로 이끌어 내기위한 sprite 모음
    // 03. animationspeed는 말그대로 애니메이션속도이고 이걸통해 조절을 할 예정
    // 04. UI_ani()은 sprite의 길이를 통해 for을 돌리고 모두 돌았을 경우 While문을 통해 다시 반복할 예정

    public Image image;
    public Sprite[] sprites;
    public float animationSpeed;

    public IEnumerator UI_ani()
    {
        while (true)
        {
            //destroy all game objects
            for (int i = 0; i < sprites.Length; i++)
            {
                image.sprite = sprites[i];
                yield return new WaitForSeconds(animationSpeed);
            }
        }
           
    }
    public void Awake()
    {
        StartCoroutine("UI_ani");
    }

}
