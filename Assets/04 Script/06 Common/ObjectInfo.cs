using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class ObjectInfo : Singleton<ObjectInfo>
{

    public float fHp = 50f;                    // 체력
    public float fLevel = 1f;                  // 레벨
    public float fAttack = 12f;                // 공격력
    public float fAttackSpeed = 1f;            // 공격속도
    public float fAttackType = 0f;             // 공격타입
    public float fCritical = 1f;               // 치명타 데미지배율
    public float fCriticalPercent = 0f;        // 치명타확률
    public float fDefence = 2f;                // 방어력
    public float fDefenceType = 0f;            // 방어타입
    public float fLevelIntervalAttackValue;    // 레벨차이에 따른 추가데미지
    public float ResultAttackDamage;           // 최종 공격데미지
    public float LevelGap;                     // 레벨 차이
    public float fGold;                        // 골드
    public float fSoul;                        // 소울

    public LevelInterval fLevelInterval = global::LevelInterval.Zero;

    public float LevelInterval(float _Gap)
    {
        fLevelInterval = (global::LevelInterval)_Gap;
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

    public float AttackCalculate()  //공격계산
    {
        ResultAttackDamage = fDefence - (fAttack * CriticalCalculate(fCriticalPercent) + LevelInterval(LevelGap));
        //Defence - {Attack *(AttackType 비교 DefenceType) * Critical(2or1) +- LevelInterval}
        return ResultAttackDamage;
    }

    public void Attribute(float _fAttackType, float _fDefenceType)    //속성<상성>
    {
        //
    }

    public float CriticalCalculate(float _Percent)
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
