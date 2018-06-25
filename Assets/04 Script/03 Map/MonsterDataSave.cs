using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MonsterDataSave :Singleton<MonsterDataSave>
{
    [SerializeField]
    Image iMonsterImage;

    [SerializeField]
    Text tMonsterGold;

    [SerializeField]
    Text tMonsterSoul;

    [SerializeField]
    Text tMonsterName;

    [SerializeField]
    Text tMonsterDescription;

    [SerializeField]
    Text tMonsterHp;

    [SerializeField]
    Text tMonsterAttack;

    [SerializeField]
    Text tMonsterDefence;

    public XMLMonsterData cMonsterData;

    public float fNumber;
    public float fGold;
    public float fSoul;


    public void Init(XMLMonsterData _cMonsterData)
    {
        cMonsterData = _cMonsterData;

        iMonsterImage.sprite = XMLMonster.Instance.MonsterSprites[(int)_cMonsterData.fNumber];
        tMonsterGold.text = cMonsterData.fGold.ToString();
        tMonsterSoul.text = cMonsterData.fSoul.ToString();
        tMonsterName.text = cMonsterData.sName.ToString();
        tMonsterDescription.text = cMonsterData.sDescription.ToString();
        tMonsterHp.text = cMonsterData.fHp.ToString();
        tMonsterAttack.text = cMonsterData.fAttack.ToString();
        tMonsterDefence.text = cMonsterData.fDefence.ToString();

        fNumber = cMonsterData.fNumber;
        fGold = cMonsterData.fGold;
        fSoul = cMonsterData.fSoul;
    }

    public void SummonButtonClick()
    {
        MonsterSummon.Instance.Summon((int)fNumber,(int)fGold,(int)fSoul);        
    }

    
    
}