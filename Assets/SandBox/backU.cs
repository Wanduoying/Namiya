using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backU : MonoBehaviour
{
    //オブジェクトを宣言
    public GameObject wallPrefab;

    //ランダム數値の制禦
    private int randomMin = 0;
    private int randomMax = 2;

    //配列の幅
    public int m_width = 10;


    void Start()
    {
        //１次元の配列を置く
        int[] map = new int[m_width];

        //for文を用ゐて各インデックスに1もしくは0を代入
        for (int i = 0; i < map.GetLength(0); i++)
        {
            map[i] = Random.Range(randomMin, randomMax);
        }

        //各インデックスに代入された値を基に、壁の生成、不生成を判別
        for (int i = 0; i < map.GetLength(0); i++)
        {
            //インデックスの値が1の時、wallPrefabを生成
            if (map[i] == 1)
            {
                GameObject wall = Instantiate(wallPrefab) as GameObject;
                wall.transform.position = new Vector3(i, 0, 0);
                Debug.Log("壁" + i);
            }
        }
    }
}