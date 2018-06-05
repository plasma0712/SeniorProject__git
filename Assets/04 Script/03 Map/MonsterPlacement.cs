using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPlacement : Singleton<MonsterPlacement>
{
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
    //public MonsterSummon[] MonsterSummons = new MonsterSummon[10];

    private void Awake()
    {
        CullingMonster();
    }

    public void CurrentMonsterData(int _monsterdata)
    {
        Current = XMLMonsterSummon.Instance.GetMonsterSummonData(_monsterdata);
        
        InherentNumberData = Current.InherentNumber;
        MonsterPosXData = Current.fPosX;
        MonsterPosYData = Current.fPosY;
        vPos.x = MonsterPosXData;
        vPos.y = MonsterPosYData;

        //GameObject instance = (GameObject)Instantiate(MonsterSummon.Instance.BuyMonsterSummon[InherentNumberData], vPos, Quaternion.identity);
        MonsterSummon.Instance.SummonCurring(InherentNumberData,vPos.x,vPos.y);
    }

    void CullingMonster()
    {
        XMLMonsterSummon.Instance.LoadXml();
        for(int k =0; k< XMLMonsterSummon.Instance.MonsterSummonLegth(); k ++)
        {
            CurrentMonsterData(k);
            Debug.Log(k);
        }
    }
}
