using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MonsterDataSave :Singleton<MonsterDataSave>
{
    #region 리스트관리
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
    //////////////////////////////////////////////////////////////

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

        // 씨발 이거 고쳐야함 ㅋㅋㅋㅋㅋㅋ
        if(fNumber==0)
        {
            Lock.gameObject.SetActive(false);
        }
        //
    }
    #endregion

    #region 잠금해제
    public GameObject Lock;
    XMLMonsterListUnLockData Current;
    public int cInherentNumber;
    public int cUnLock;

    public void UnLock(int _cMonsterListUnLockData )
    {
        Current = XMLMonsterListUnLock.Instance.GetMonsterListUnLockData(_cMonsterListUnLockData);
        cInherentNumber = Current.InherentNumber;
        cUnLock = Current.UnLock;
        //if(fNumber == cInherentNumber)
        //{
        //    Lock.gameObject.SetActive(false);
        //    Debug.Log("가나다라");
        //}         
    }

    #endregion

    public void SummonButtonClick()
    {
        MonsterSummon.Instance.Summon((int)fNumber,(int)fGold,(int)fSoul);        
    }

    
    
}