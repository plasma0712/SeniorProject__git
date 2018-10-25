using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo : Singleton<TileInfo>
{
    #region 사용하려나...
    //public GameObject[] TileType;

    public Unit unit;

    public int[] pos = new int[2];

    public bool MyUnitTile(int PosX,int PosY)        // IsNearMyTile
    {
        TileInfo Exist;

        Exist = Map.Instance.MapTiles[pos[PosX], pos[PosY]];

        if(Exist != null)
        {
            return true;
        }

        return false;
    }

    public bool UnitSummon()
    {
        if(unit != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    #endregion

    public GameObject[] TileType;

}
