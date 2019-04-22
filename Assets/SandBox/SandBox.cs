using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBox : MonoBehaviour
{

    //オブジェクトを宣言
    public GameObject floorPrefab; //床
    public GameObject wallPrefab; //壁
    public GameObject ItemPrefab;//アイテム
    public GameObject TrapPrefab;//罠
    public GameObject PlayerPrefab;//プレイヤー
    public GameObject EnemyPrefab;//敵

    //ランダム値
    private int randomMin = 0;
    private int randomMax = 100;

    //マップ
    public int mapWidth = 100;
    public int mapHeight = 100;
    public int maxRoom = 10;

    int[,] map;

    void Start()
    {
        MapGenerator();
        //Debug.Log(map[,]);
        CharacterGenerator();
        ItemGenerator();
        GroundObjectGenerator();

    }

    //マップ作成
    void MapGenerator()
    {
        //２次元の配列にする
        MapGenerator mapGen = new MapGenerator();
        //0が壁、1が通路、2が部屋のint型二次元配列
        map = mapGen.GenerateMap(mapWidth, mapHeight, maxRoom);

        //各インデックスに代入された値を基に、壁などの生成、不生成を判別
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                //インデックスの値が0の時、wallPrefabを生成
                if (map[i, j] == 0)
                {
                    GameObject go = Instantiate(wallPrefab);
                    go.transform.position = new Vector3(i, 0, j);
                }

                //インデックスの値が1、2の時、floorPrefabを生成
                if (map[i, j] == 1 || map[i, j] == 2)
                {
                    GameObject go = Instantiate(floorPrefab);
                    go.transform.position = new Vector3(i, -0.5f, j);

                }
            }
        }
    }

    //プレイヤーと敵作成
    void CharacterGenerator()
    {
        //２次元の配列にする
        int[,] mapChara = new int[mapWidth, mapHeight];

        //for文を用ゐて各インデックスに1もしくは0を代入
        for (int i = 0; i < mapChara.GetLength(0); i++)
        {
            for (int j = 0; j < mapChara.GetLength(1); j++)
            {
                //mapの壁部分には生成せず
                if (map[i, j] == 0)
                {
                    mapChara[i, j] = 1000;
                }
                else
                {
                    mapChara[i, j] = Random.Range(randomMin, randomMax);
                }
            }
        }

        //各インデックスに代入された値を基に、壁などの生成、不生成を判別
        for (int i = 0; i < mapChara.GetLength(0); i++)
        {
            for (int j = 0; j < mapChara.GetLength(1); j++)
            {
                //インデックスの値が規定値以下の時、EnemyPrefabを生成
                if (2 <= mapChara[i, j] && mapChara[i, j] < 4)
                {
                    GameObject enem = Instantiate(EnemyPrefab);
                    enem.transform.position = new Vector3(i, 0, j);
                }

            }
        }

        //PlayerPrefabを生成
        GameObject go = Instantiate(PlayerPrefab);
        go.transform.position = new Vector3(0, 0, 0);
    }

    //アイテム作成
    void ItemGenerator()
    {
        //２次元の配列にする
        int[,] map = new int[mapWidth, mapHeight];

        //for文を用ゐて各インデックスに1もしくは0を代入
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                map[i, j] = Random.Range(randomMin, randomMax);
            }
        }

        //各インデックスに代入された値を基に、壁などの生成、不生成を判別
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                //インデックスの値が規定値以下の時、ItemPrefabを生成
                if (map[i, j] < 2)
                {
                    GameObject go = Instantiate(ItemPrefab);
                    go.transform.position = new Vector3(i, 0, j);

                }

            }
        }

    }

    //罠など、地面設置物の作成
    void GroundObjectGenerator()
    {
        //２次元の配列にする
        int[,] mapGround = new int[mapWidth, mapHeight];

        //for文を用ゐて各インデックスに1もしくは0を代入
        for (int i = 0; i < mapGround.GetLength(0); i++)
        {
            for (int j = 0; j < mapGround.GetLength(1); j++)
            {
                //mapの通路部分には生成せず
                if (map[i, j] == 1)
                {
                    mapGround[i, j] = 1000;
                }
                else
                {
                    mapGround[i, j] = Random.Range(randomMin, randomMax);
                }
            }
        }

        //各インデックスに代入された値を基に、壁などの生成、不生成を判別
        for (int i = 0; i < mapGround.GetLength(0); i++)
        {
            for (int j = 0; j < mapGround.GetLength(1); j++)
            {
                //インデックスの値が規定値以下の時、TrapPrefabを生成
                if (mapGround[i, j] < 2)
                {
                    GameObject go = Instantiate(TrapPrefab);
                    go.transform.position = new Vector3(i, 0, j);

                }

            }
        }

    }



}
