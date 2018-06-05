using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


// CustomEditor() 애트리뷰트를 사용해서 어떤 타입을 커스터마이즈 할 것 인지를 명시해 주어야 한다.
[CustomEditor(typeof(Movement))]
// 모든 인스펙터 커스터마이즈 클래스는 Editor를 상속받아야 합니다.
public class MapTilePostionTool : Editor
{
    // 커스터마이즈 할 대상의 레퍼런스를 저장
    Movement _movememt;

    // 커스터마이즈된 에디터의 인스턴스가 생성될 때 호출
    private void OnEnable()
    {
        // target은 위의 CustomEditor() 애드리뷰트에서 설정해 준 타입의 객체에 대한 레퍼런스
        // object형이므로 실제 사용할 타입으로 캐스팅 해 준다.
        _movememt = target as Movement;
    }

    // 인스펙터에 표시되는 GUI들은 이 메서드에서 다루어져야 한다.
    // 여기에서는 EditorGUILayout 이 제공하는 메서드를 사용해서
    // 미리 정의된 에디터 레이아웃으로 컨트롤들을 배치한다.
    public override void OnInspectorGUI()
    {
        // 컨트롤들을 가로로 배치하기 위해 BeginHorizontal()/EndHorizontal() 메서드를 사용한다.
        EditorGUILayout.BeginHorizontal();
        // 이동 속도 레이블
        EditorGUILayout.LabelField("Speed", GUILayout.Width(75f));
        // 이동 속도는 4가지 중 하나로 선택하도록 IntPopup() 컨트롤을 사용한다.
        string[] speedNames = new string[]
        {
                "slow","normal","fast","faster"
        };
        int[] speedValues = new int[]
        {
                1,5,10,20
        };
        _movememt._speed = EditorGUILayout.IntPopup(_movememt._speed, speedNames, speedValues);
        EditorGUILayout.EndHorizontal();

        // x,y,z 값을 가로로 표시하는 Vector3Field() 컨트롤을 생성
        _movememt._targetPosition = EditorGUILayout.Vector3Field("Target Postion", _movememt._targetPosition);

        // GUI가 변경되었다면 타겟을 다시 렌더링 하도록 하기 위해 dirty 상태로 마크한다.

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

       //EditorGUILayout.BeginHorizontal();
       //
       //
       // // 리셋 버튼
       //
       // if (GUILayout.Button("Up"))
       // {
       //     //              _movememt.Start();
       //     _movememt.move = true;
       //     _movememt._targetPosition = new Vector3(0, 3, 0);
       // }
       // if (GUILayout.Button("Down"))
       // {
       //     //              _movememt.Start();
       //     _movememt.move = true;
       //     _movememt._targetPosition = new Vector3(0, -3, 0);
       // }
       // if (GUILayout.Button("Left"))
       // {
       //     //              _movememt.Start();
       //     _movememt.move = true;
       //     _movememt._targetPosition = new Vector3(-3, 0, 0);
       // }
       // if (GUILayout.Button("Right"))
       // {
       //     //              _movememt.Start();
       //     _movememt.move = true;
       //     _movememt._targetPosition = new Vector3(3, 0, 0);
       // }
       // if (GUILayout.Button("Reset"))
       // {
       //     //              _movememt.Start();
       //     _movememt.move = true;
       //     _movememt._targetPosition = new Vector3(0, 0, 0);
       // }
       //
       // EditorGUILayout.EndHorizontal();

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("O_Up"))
        {
            _movememt.move = true;
            _movememt._targetPosition += new Vector3(0, 0.64f, 0);
            _movememt.EditorMove();

        }
        if (GUILayout.Button("O_Down"))
        {
            _movememt.move = true;
            _movememt._targetPosition += new Vector3(0, -0.64f, 0);
            _movememt.EditorMove();

        }
        if (GUILayout.Button("O_Left"))
        {
            _movememt.move = true;
            _movememt._targetPosition += new Vector3(-0.64f, 0, 0);
            _movememt.EditorMove();

        }
        if (GUILayout.Button("O_Right"))
        {
            _movememt.move = true;
            _movememt._targetPosition += new Vector3(0.64f, 0, 0);
            _movememt.EditorMove();
        }
        if (GUILayout.Button("O_Reset"))
        {
            _movememt.move = true;
            _movememt._targetPosition = new Vector3(0, 0, 0);
            _movememt.EditorMove();
        }

        EditorGUILayout.EndHorizontal();

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // 테스트용 컨트롤들 -
        //      OnInspectorGUIForTest();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }

    }
}
