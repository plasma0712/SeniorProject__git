using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPlacement : Singleton<MonsterPlacement>
{
    [HideInInspector]
    public int iCountData;
    [HideInInspector]
    public int InherentNumberData;
    [HideInInspector]
    public float MonsterPosXData;
    [HideInInspector]
    public float MonsterPosYData;

    XMLMonsterSummonData Current;

    [HideInInspector]
    public Vector3 vPos;

    GameObject Monster;

    public string _iCount;
    //public MonsterSummon[] MonsterSummons = new MonsterSummon[10];

    private void Awake()
    {
        CullingMonster();
    }

    public void Update() // 이거 꼭 고쳐야함
    {
    }

    public void CurrentMonsterData(int _monsterdata)
    {
        Current = XMLMonsterSummon.Instance.GetMonsterSummonData(_monsterdata);

        InherentNumberData = Current.InherentNumber;
        MonsterPosXData = Current.fPosX;
        MonsterPosYData = Current.fPosY;
        iCountData = Current.iCount;

        vPos.x = MonsterPosXData;
        vPos.y = MonsterPosYData;

        MonsterSummon.Instance.SummonCurring(iCountData, vPos.x, vPos.y);

    }

    void CullingMonster()
    {
        XMLMonsterSummon.Instance.LoadXml();
        for(int k =0; k< XMLMonsterSummon.Instance.MonsterSummonLegth(); k ++)
        {
            CurrentMonsterData(k);
            //Debug.Log(k);
        }
    }

}
