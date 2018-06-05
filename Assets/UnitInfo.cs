using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public abstract class UnitInfo : MonoBehaviour
{
    // float fHp;
    // float fLevel;
    // float fAttack;
    // float fAttackSpeed;
    // float fAttackType;
    // float fCritical;
    // float fDefence;
    // float fDefenceType;
    //       
    // float fGold;
    // float fSoul;

    float fHp = 50f;
    float fLevel = 1f;
    float fAttack = 12f;
    float fAttackSpeed = 1f;
    float fAttackType = 0f;
    float fCritical = 1f;
    float fCriticalPercent = 0f;
    float fDefence = 2f;
    float fDefenceType = 0f;
    float fLevelIntervalAttackValue;
    float ResultAttackDamage;
    float LevelGap;
    float fGold;
    float fSoul;

    LevelInterval fLevelInterval = global::LevelInterval.Zero;

    float LevelInterval(float _Gap)
    {
        fLevelInterval =(global::LevelInterval)_Gap;
        switch (fLevelInterval)
        {
            case global::LevelInterval.Zero:
                fLevelIntervalAttackValue = 0;
                break;
            case global::LevelInterval.One:
                fLevelIntervalAttackValue = 1;
                break;
            case global::LevelInterval.Two:
                fLevelIntervalAttackValue = 2;
                break;
            case global::LevelInterval.Three:
                fLevelIntervalAttackValue = 4;
                break;
            case global::LevelInterval.Four:
                fLevelIntervalAttackValue = 8;
                break;
            case global::LevelInterval.Five:
                fLevelIntervalAttackValue = 16;
                break;
            case global::LevelInterval.Six:
                fLevelIntervalAttackValue = 32;
                break;
            case global::LevelInterval.Seven:
                fLevelIntervalAttackValue = 64;
                break;
            case global::LevelInterval.Nine:
                fLevelIntervalAttackValue = 128;
                break;
            case global::LevelInterval.Ten:
                fLevelIntervalAttackValue = 256;
                break;
            default:
                fLevelIntervalAttackValue = 512;
                break;
        }
        return fLevelIntervalAttackValue;
    }

    float AttackCalculate()  //공격계산
    {
        ResultAttackDamage = fDefence - (fAttack * CriticalCalculate(fCriticalPercent) + LevelInterval(LevelGap));
        //Defence - {Attack *(AttackType 비교 DefenceType) * Critical(2or1) +- LevelInterval}
        return ResultAttackDamage;
    }

    void Attribute(float _fAttackType, float _fDefenceType)    //속성<상성>
    {
        //
    }

    float CriticalCalculate(float _Percent)
    {
        // Random rCritical = new Random(unchecked((int)System.DateTime.Now.Ticks) + _Percent);
        int rCritical = Random.Range(0, 100);

        if (rCritical < _Percent)
        {
            fCritical = 2;
        }
        else
        {
            fCritical = 1;
        }
        return fCritical;
    }
}

public enum LevelInterval
{
    Zero,  //Zero = 0,
    One,  //One = 1,
    Two,  //Two = 2,
    Three, //Three = 4,
    Four,  //Four = 8,
    Five,  //Five = 16,
    Six,  //Six = 32,
    Seven, //Seven = 64,
    Eight, //Eight = 128,
    Nine,  //Nine = 256,
    Ten  //Ten = 512
}

public enum AttackType
{
    Nomal,
    Range,
    Magic
}

public enum DefenceType
{
    Small,
    Medium,
    Large
}
