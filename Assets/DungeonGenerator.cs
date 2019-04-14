using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGenerator : MonoBehaviour
{

    //オブジェクトを宣言
    public GameObject floorPrefab; //床
    public GameObject wallPrefab; //壁
    public GameObject ItemPrefab;//アイテム
    public GameObject TrapPrefab;//罠
    public GameObject StairPrefab;//階段
    public GameObject PlayerPrefab;//プレイヤー
    public GameObject EnemyPrefab;//敵

    //ランダム値
    private int randomMin = 0;
    private int randomMax = 100;

    //マップ
    int[,] map;
    public int mapWidth = 100;
    public int mapHeight = 100;
    public int maxRoom = 10;


    void Start()
    {
        MapGenerator();
        CharacterGenerator();
        ItemGenerator();
        GroundObjectGenerator();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            SceneManager.LoadScene("GameScene");
        }

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

        //for文を用ゐて各インデックスにランダム値を代入
        for (int i = 0; i < mapChara.GetLength(0); i++)
        {
            for (int j = 0; j < mapChara.GetLength(1); j++)
            {
                //mapの壁(map[i, j] == 0)には生成せず
                mapChara[i, j] = (map[i, j] == 0) ? 1000: Random.Range(randomMin, randomMax);
            }
        }

        //各インデックスに代入された値を基に、生成、不生成を判別
        for (int i = 0; i < mapChara.GetLength(0); i++)
        {
            for (int j = 0; j < mapChara.GetLength(1); j++)
            {
                //インデックスの値が規定値以下の時、EnemyPrefabを生成
                if (mapChara[i, j] < 2)
                {
                    GameObject enemGo = Instantiate(EnemyPrefab);
                    enemGo.transform.position = new Vector3(i, 0, j);
                }
            }
        }

        //プレイヤーを生成
        //int debugNum = 0;
        int playerPosX;
        int playerPosZ;

        while (true)
        {
            //debugNum++;

            //playerPosX、playerPosYにランダムな値を代入
            playerPosX = Random.Range(mapWidth - mapWidth, mapWidth);
            playerPosZ = Random.Range(mapHeight - mapHeight, mapHeight);

            //Debug.Log(debugNum + "囘目" + "、playerPosX＝" + playerPosX + "、playerPosZ＝" + playerPosZ + "、map[,]の座標＝" + map[playerPosX, playerPosZ] + "、mapCharaの座標＝" + mapChara[playerPosX, playerPosZ]);


            //生成位置が壁中でなく、かつ敵の生成位置と重ならなければ終了
            if (map[playerPosX, playerPosZ]==2 && 2 <= mapChara[playerPosX, playerPosZ]) break;
        }
        //whire文で求めた座標にPlayerPrefabを生成
        GameObject playerGo = Instantiate(PlayerPrefab);
        playerGo.transform.position = new Vector3(playerPosX, 0, playerPosZ);

        //Debug.Log("whire終了、playerGoの座標＝"+playerGo.transform.position);

    }

    //アイテム作成
    void ItemGenerator()
    {
        //２次元の配列にする
        int[,] mapItem = new int[mapWidth, mapHeight];

        //for文を用ゐて各インデックスにランダム値を代入
        for (int i = 0; i < mapItem.GetLength(0); i++)
        {
            for (int j = 0; j < mapItem.GetLength(1); j++)
            {
                mapItem[i, j] = Random.Range(randomMin, randomMax);
            }
        }

        //各インデックスに代入された値を基に、生成、不生成を判別
        for (int i = 0; i < mapItem.GetLength(0); i++)
        {
            for (int j = 0; j < mapItem.GetLength(1); j++)
            {
                //インデックスの値が規定値以下の時、ItemPrefabを生成
                if (mapItem[i, j] < 2)
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

        //for文を用ゐて各インデックスにランダム値を代入
        for (int i = 0; i < mapGround.GetLength(0); i++)
        {
            for (int j = 0; j < mapGround.GetLength(1); j++)
            {
                //mapの通路部分(map[i, j] == 1)には生成せず
                mapGround[i, j] = (map[i, j] == 1) ? 1000 : Random.Range(randomMin, randomMax);
            }
        }

        //各インデックスに代入された値を基に、生成、不生成を判別
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

        //階段を生成
        int stairPosX;
        int stairPosZ;

        while (true)
        {
            //playerPosX、playerPosYにランダムな値を代入
            stairPosX = Random.Range(mapWidth - mapWidth, mapWidth);
            stairPosZ = Random.Range(mapHeight - mapHeight, mapHeight);

            //生成位置が壁中でなく、かつ敵の生成位置と重ならなければ終了
            if (map[stairPosX, stairPosZ] == 2 && 2 <= mapGround[stairPosX, stairPosZ]) break;
        }
        //whire文で求めた座標にPlayerPrefabを生成
        GameObject stair = Instantiate(StairPrefab);
        stair.transform.position = new Vector3(stairPosX, 0, stairPosZ);
    }
}
