using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumTest : MonoBehaviour {

    enum 年號
    {
        明治,大正,昭和,平成
    }

    // Use this for initialization
    void Start()
    {
        年號[] era = new 年號[4] { 年號.明治, 年號.大正, 年號.昭和, 年號.平成 };
        int[] j_year = new int[4] { 12, 20, 10, 54 };
        int[] year = new int[5];

        Debug.Log("和暦      西暦\n");

        for (int i = 0; i < 5; ++i)
        {
            switch (era[i])
            {
                case 年號.明治: year[i] = j_year[i] + 1863; break;
                case 年號.大正: year[i] = j_year[i] + 1911; break;
                case 年號.昭和: year[i] = j_year[i] + 1925; break;
                case 年號.平成: year[i] = j_year[i] + 1988; break;
            }
            Debug.Log("{0}{1:d2}年  {2:d4}年\n");
        }
    }

        // Update is called once per frame
        void Update () {
		
	}
}
