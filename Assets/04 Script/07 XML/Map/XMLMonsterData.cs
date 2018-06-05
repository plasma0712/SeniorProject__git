using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMLMonsterData
{
    public float fNumber;
    public string sName;
    public string sDescription;
    public float fHp;
    public float fLevel;
    public float fAttack;
    public float fAttackSpeed;
    public AttackType eAttackType;
    public float fCritical;
    public float fDefence;
    public DefenceType eDefenceType;

    public float fGold;
    public float fSoul;
}

[System.Serializable]
public class MonsterListBase
{
    float fNumber;

    public void Init(float _fNumber)
    {
        fNumber = _fNumber;
    }


}
