using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerator : MonoBehaviour {

    //オブジェクトを宣言
    public GameObject outerWallPrefab; //マップ端の外壁
    public GameObject floorPrefab; //床
    public GameObject wallPrefab; //マップ内の壁

    //ランダム數値の制禦
    private int randomMin = 1;
    private int randomMax = 3;

    //マップ全域の幅
    public int m_width = 100; //x軸方向
    public int m_heigt = 100; //y軸方向



    void Start () {

        //２次元の配列にする
        int[,] map = new int[m_width, m_heigt];

        //for文を用ゐて各インデックスに1もしくは0を代入
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for(int j = 0; j < map.GetLength(1); j++)
            {
                //マップの端の座標に0を代入
                if (i == 0 || i == m_width-1 || j == 0 || j == m_heigt-1)
                {
                    map[i, j] = 0;
                }
                //それ以外の座標にrandomMin～randomMaxを代入
                else
                {
                    map[i, j] = Random.Range(randomMin, randomMax);
                }
            }
        }        
        
        //各インデックスに代入された値を基に、壁などの生成、不生成を判別
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                //インデックスの値が0の時、OuterWallPrefabを生成
                if (map[i, j] == 0)
                {
                    GameObject go = Instantiate(outerWallPrefab);
                    go.transform.position = new Vector3(i, 0, j);
                }

                //インデックスの値が1の時、床を生成
                if (map[i, j] == 1)
                {
                    GameObject go = Instantiate(floorPrefab);
                    go.transform.position = new Vector3(i, -1, j);

                }

                //インデックスの値が2の時、壁を生成
                if (map[i, j] == 2)
                {
                    GameObject go = Instantiate(wallPrefab);
                    go.transform.position = new Vector3(i, 0, j);

                }

            }
        }
    }



}
