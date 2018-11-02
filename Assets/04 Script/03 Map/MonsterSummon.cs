using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSummon : Singleton<MonsterSummon>
{
    public GameObject[] BuyMonsterSummon;

    public int iCount;
    public int iNumber;
    public int iGold;
    public int iSoul;

    GameObject followingSummonMonster;
    GameObject Dummy;
    public bool bBuy = false;

    TileInfo NowTile;
    XMLMonsterData NowMonster;

    float iNearPoint; //가까운 거리
    float iDistance; // 두점사이의 거리
    public Vector3 vPoint;

    public bool TileIn = false;

    bool PossibleSummon = false; // 소환이 가능한지 않한지 확인하기 위한 bool TileNumbering이 1인경우에만 가능하게 할것

    public bool FundGoldUse = false; // Gold 없을 때 Soul 소모 안하게 하기 위함
    public bool FundSoulUse = false; // Soul 없을 때 Gold 소모 안하게 하기 위함

    bool DoubleSummon = false; // 소환중에 소환이 안되게 하기 위함

    public int iTileNumbering;

    public bool DoingSummon = true; // 여기서 설정해주는게 맞음 Overlap에서는 이걸 변경


    void Update()   // 코루틴으로 변경예정 
    {
        if (DoubleSummon == true)
        {
            if (bBuy == true)
            {
                Vector3 NewPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 5));
                //Debug.Log("마우스 좌표 X : " + NewPosition.x + " 마우스 좌표 Y : " + NewPosition.y);
                //followingSummonMonster = Instantiate(BuyMonsterSummon[iNumber], NewPosition, Quaternion.identity);
                MouseClick(vPoint.x, vPoint.y);
                if (bBuy == true)
                {
                    if (TileIn == false)
                    {
                        followingSummonMonster.transform.position = NewPosition;
                    }
                    else
                    {
                        followingSummonMonster.transform.position = vPoint;
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        /*
        if (bBuy == true)
        {
            Vector3 NewPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 5));
            //Debug.Log("마우스 좌표 X : " + NewPosition.x + " 마우스 좌표 Y : " + NewPosition.y);
            //followingSummonMonster = Instantiate(BuyMonsterSummon[iNumber], NewPosition, Quaternion.identity);
            MouseClick();
            if (bBuy == true)
            {
                followingSummonMonster.transform.position = NewPosition;
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
        */

    }

    /*
    public void Summon(int _iNumber)
    {
        // 자원소모하고 나서 진행이 되야하기 때문에 여기서 할 예정
        iNumber = _iNumber;
        bBuy = true;
        Debug.Log(iNumber);
        followingSummonMonster = Instantiate(BuyMonsterSummon[iNumber], new Vector3(0, 0, 0), Quaternion.identity);
        followingSummonMonster.GetComponent<BoxCollider2D>().enabled = false;
    }
    */

    public void Summon(int _iNumber, int _iGold, int _iSoul)
    {
        if (DoubleSummon == false) // 소환중 이중으로 안되게 하기 위함
        {
            // 자원소모하고 나서 진행이 되야하기 때문에 여기서 할 예정
            iNumber = _iNumber;
            iGold = _iGold;
            iSoul = _iSoul;

            LobbyTopUIData.Instance.MonsterSummonUseGold(iGold);
            LobbyTopUIData.Instance.MonsterSummonUseSoul(iSoul);

            if (FundGoldUse == false && FundSoulUse == true)
            {
                LobbyTopUIData.Instance.GetSoul(iSoul);
            }
            if (FundSoulUse == false && FundGoldUse == true)
            {
                LobbyTopUIData.Instance.GetGold(iGold);
            }

            if (FundGoldUse == true && FundSoulUse == true)
            {
                bBuy = true;
                Debug.Log(iNumber);
                followingSummonMonster
                    = Instantiate(BuyMonsterSummon[iNumber], new Vector3(0, 0, 0), Quaternion.identity);
                followingSummonMonster.GetComponent<BoxCollider2D>().enabled = false;
                DoubleSummon = true;
                Debug.Log("DoubleSummon : " + DoubleSummon);

            }
        }
    }

    public void BSummon()
    {
        LobbyTopUIData.Instance.GetGold(iGold);
        LobbyTopUIData.Instance.GetSoul(iSoul);
    }

    public void SummonCurring(int _iNumber, float _vPosX, float _vPosY)
    {
        iNumber = _iNumber;
        GameObject instance = Instantiate(BuyMonsterSummon[iNumber], new Vector3(_vPosX, _vPosY, 0), Quaternion.identity);

        MonsterPlacement.Instance.MonsterList.Add(instance); // 타워 관리차원
    }

    public void MouseClick(float fPosX, float fPosY)
    {
        if (bBuy == true)
        {
            TutorialText.Instance.SummonSuccess++;
            if (Input.GetMouseButtonDown(0))        // 소환 시키기
            {
                if (iTileNumbering == 1 && DoingSummon == true)
                {
                    followingSummonMonster.GetComponent<BoxCollider2D>().enabled = true;
                    followingSummonMonster = Dummy;
                    //XMLMonsterSummon.Instance.AddXmlNode(MonsterDataSave.Instance.fNumber.ToString(), (followingSummonMonster.transform.position.x).ToString(), (followingSummonMonster.transform.position.y).ToString());
                    //XMLMonsterSummon.Instance.AddXmlNode("1","1","1");
                    //MonsterPlacement.Instance._iCount = XMLMonster.Instance.MonsterLegth().ToString();
                    XMLMonsterSummon.Instance.LoadXml();
                    XMLMonsterSummon.Instance.AddXmlNode(iNumber.ToString(), XMLMonsterSummon.Instance.MonsterSummonLegth().ToString(), fPosX.ToString(), fPosY.ToString());
                    bBuy = false;
                    TileIn = false;

                    DoubleSummon = false;
                    Debug.Log("DoubleSummon : " + DoubleSummon);
                    iTileNumbering = 0;

                }
                else
                {
                    return;
                }
            }
            else if (Input.GetMouseButtonDown(1))   // 소환 취소 
            {
                Destroy(followingSummonMonster);
                bBuy = false;
                DoubleSummon = false;
                Debug.Log("DoubleSummon : " + DoubleSummon);

                BSummon();
                iTileNumbering = 0;
                //자원소모 된것에 대해서 다시 되돌리기
            }
        }
    }

    public bool SummonMonsters()
    {
        Vector3 pos = GetTilePos(NowTile.pos[0], NowTile.pos[1]);
        //GameObject tmp2 = Instantiate(BuyMonsterSummon[])
        return true;
    }

    public Vector3 GetTilePos(int _i, int _j)
    {
        Vector3 result = new Vector3(Map.TileX * _i, Map.TileY * _j);
        return result;
    }

    /*
        public void Distance(float _fsmX, float _fsmY)  // 가장 짧은 거리 구하기  
        {
            Map.Instance.CurrentMapData(0);
            iNearPoint = DistanceBetweenTwoPoints(_fsmX, _fsmY, Map.Instance.vPos.x, Map.Instance.vPos.y);

            for (int i = 0; i < XMLMap.Instance.MapLength(); i++)
            {
                Map.Instance.CurrentMapData(i);
                iDistance = DistanceBetweenTwoPoints(_fsmX, _fsmY, Map.Instance.vPos.x, Map.Instance.vPos.y);
                if(iNearPoint>=iDistance)
                {
                    vNearPoint.x = Map.Instance.vPos.x;
                    vNearPoint.y = Map.Instance.vPos.y;
                }
            }
            //Debug.Log("두점사이의 거리에 대한 최소값 " + "x값 : " + vNearPoint.x + " y값 : " + vNearPoint.y);
        }

        public float DistanceBetweenTwoPoints(float _fsmX, float _fsmY, float _mapVposX, float _mapVposY) // 두점사이의 거리 구하기
        {
            float fsmX = _fsmX;
            float fsmY = _fsmY;
            float mapVposX = _mapVposX;
            float mapVposY = _mapVposY;

            return ((fsmX - mapVposX) * (fsmX - mapVposX) + (fsmY - mapVposY) * (fsmY - mapVposY));
        }
    */
}
