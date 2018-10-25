using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Map : Singleton<Map>
{
    public const float TileX = 0.62f;
    public const float TileY = 0.62f;

    int TileArrX = 0;
    int TileArrY = 0;

    public const int MapXCount = 70;            // 최대 리미트 맵 10개라고 현재 기획상태
    public const int MapYCount = 90;             // 맵 길이 

    [HideInInspector]
    public int TileXData = 0;
    [HideInInspector]
    public int TileYData = 0;
    [HideInInspector]
    public int MapCount;
    [HideInInspector]
    public int MapSize;

    float TileTypeData;

    float TileType;

    XMLMapData Current;
    public Vector3 vPos;
    //public GameObject Tile;
    public GameObject Parent;                               // 맵 타일 
    [SerializeField]
    public List<GameObject> TileList = new List<GameObject>();

    /////////////////////////////////////////////////////////////////////////////////////////////////////////
    public int[,] MapTileBase = new int[MapXCount, MapYCount];
    public TileInfo[,] MapTiles = new TileInfo[MapXCount, MapYCount];


    private void Awake()
    {
        Culling();
    }

    public void CurrentMapData(int _mapdata)
    {
        Current = XMLMap.Instance.GetMapData(_mapdata);
        TileXData = Current.iMapTileX;
        TileYData = Current.iMapTileY;
        TileTypeData = Current.fType;
        vPos.x = TileX * TileXData;
        vPos.y = TileY * TileYData;

        TileArrX = Current.iMapTileX;
        TileArrY = Current.iMapTileY;

        //Debug.Log("X_Pos : " + TileXData + "Y_Pos : " + TileYData);
        MapTileBase[TileXData, TileYData] = (int)TileTypeData;
        GameObject instance = Instantiate(TileInfo.Instance.TileType[(int)TileTypeData], vPos, Quaternion.identity);
        instance.transform.parent = Parent.transform; // 인스턴트로 생성된 오브젝트를 정리하기 위해서 이용함.
        MapTiles[TileXData, TileYData] = instance.GetComponent<TileInfo>();

        TileList.Add(instance);                       // 인스턴트로 생성된 오브젝트를 리스트로 넣어 관리하기 위해 함.
    }

    void Culling()
    {
        MapCount = 0;
        XMLMap.Instance.LoadXml();
        for (int k = 0; k < XMLMap.Instance.MapLength(); k++)
        {
            CurrentMapData(k);
            MapCount++;                                   // MapCount를 이용하여 현재 깔린 타일의 수를 알기 위함
        }
    }
    /*
    public void MapArrangement1(GameObject MapTile)
    {
        for(int TileY = 0; TileY<9;TileY++)
        {
            for (int TileX = 0; TileX < 7*(XMLMap.Instance.MapLength()/63); TileX++)
            {
                MapTileBase[TileX, TileY] = 1;
                MapTiles[TileX, TileY] = MapTile.GetComponent<TileInfo>();

                MapTiles[TileX, TileY].pos = new int[2] { TileX, TileY };

                Debug.Log("꺄락꺄ㅑㅑㅑ" + TileX + " Y값도 알려줭 " + TileY);
            }
        }
    }
    */
    //public void MapArrangement(GameObject MapTile,int k)
    //{
    //    CurrentMapData(k);
    //    MapTileBase[TileArrX, TileArrY] = 1;
    //    MapTiles[TileArrX, TileArrY] = MapTile.GetComponent<TileInfo>();
    //
    //    MapTiles[TileArrX, TileArrY].pos = new int[2] { TileArrX, TileArrY };
    //
    //    Debug.Log("꺄락꺄ㅑㅑㅑ" + TileX + " Y값도 알려줭 " + TileY);
    //
    //}


    public void MapAddFuction()
    {
        MapSize = MapCount / 63;
        for (int TileY = 0; TileY < 9; TileY++)
        {
            for (int TileX = 0; TileX < 7; TileX++)
            {
                switch (TileY)
                {
                    case 0:
                        if (TileX == 0)
                        {
                            TileType = 1;
                        }
                        else if (TileX == 6)
                        {
                            TileType = 4;
                        }
                        else
                        {
                            TileType = 8;
                        }
                        break;

                    case 1:
                        if (TileX == 0)
                        {
                            TileType = 5;
                        }
                        else if (TileX == 6)
                        {
                            TileType = 7;
                        }
                        else
                        {
                            TileType = 0;
                        }
                        break;

                    case 2:
                        if (TileX == 0)
                        {
                            TileType = 5;
                        }
                        else if (TileX == 6)
                        {
                            TileType = 7;
                        }
                        else
                        {
                            TileType = 0;
                        }
                        break;

                    case 3:
                        if (TileX == 0)
                        {
                            TileType = 5;
                        }
                        else if (TileX == 6)
                        {
                            TileType = 7;
                        }
                        else
                        {
                            TileType = 0;
                        }
                        break;

                    case 4:
                        TileType = 0;
                        break;

                    case 5:
                        if (TileX == 0)
                        {
                            TileType = 5;
                        }
                        else if (TileX == 6)
                        {
                            TileType = 7;
                        }
                        else
                        {
                            TileType = 0;
                        }
                        break;

                    case 6:
                        if (TileX == 0)
                        {
                            TileType = 5;
                        }
                        else if (TileX == 6)
                        {
                            TileType = 7;
                        }
                        else
                        {
                            TileType = 0;
                        }
                        break;

                    case 7:
                        if (TileX == 0)
                        {
                            TileType = 5;
                        }
                        else if (TileX == 6)
                        {
                            TileType = 7;
                        }
                        else
                        {
                            TileType = 0;
                        }
                        break;

                    case 8:
                        if (TileX == 0)
                        {
                            TileType = 2;
                        }
                        else if (TileX == 6)
                        {
                            TileType = 3;
                        }
                        else
                        {
                            TileType = 6;
                        }

                        break;

                    default:
                        break;

                }
                XMLMap.Instance.AddXmlNode(((TileY * 7 + TileX) + MapCount).ToString(), (TileX + 7 * MapSize).ToString(), TileY.ToString(), TileType.ToString());
            }
        }
        XMLMap.Instance.LoadXml();
        Culling();
    }

    

}
