using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapXMLLoad : Singleton<MapXMLLoad>
{
    public int iMapTileName;
    public int iXPostion;
    public int iYPostion;

    XMLMapData CurrentData;

    public void CurrentMapData(int _iMapTileName)
    {
        CurrentData = XMLMap.Instance.GetMapData(_iMapTileName);
        iMapTileName = CurrentData.iMapTileName;
        iXPostion = CurrentData.iMapTileX;
        iYPostion = CurrentData.iMapTileY;        
    }
}
