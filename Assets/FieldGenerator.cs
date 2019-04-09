using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerator : MonoBehaviour {

    public GameObject wallPrefab;

    //ランダム数値の制御
    private int randomMin = 0;
    private int randomMax = 2;


    // Use this for initialization
    void Start () {

        //１次元の配列
        int[] field = new int[3];
        
        //各インデックスに0～1のランダムな値を入れる
        field[0] = Random.Range(randomMin, randomMax);
        field[1] = Random.Range(randomMin, randomMax);
        field[2] = Random.Range(randomMin, randomMax);

        //壁の生成
        for (int i = 0; i < 3; i++)
        {
            //インデックスの値が1の時、wallPrefabを生成
            if (field[i] == 1)
            {
                GameObject wall = Instantiate(wallPrefab) as GameObject;
                wall.transform.position = new Vector3(i, 0, 0);

            }

            Debug.Log(field[i]);

        }




        /*
        GameObject wall = Instantiate(wallPrefab) as GameObject;
        wall.transform.position = new Vector3(0, 0, 0);
        */
    }

    // Update is called once per frame
    void Update () {
		
	}
}
