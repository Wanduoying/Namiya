using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    CharacterStatus enemySta = new CharacterStatus();

	void Start () {
		
	}
	
	void Update () {
    }

    public void EnemyMove()
    {
        //this.transform.Translate(1, 0, 0, Space.World);


        int numX = Random.Range(-1, 2);
        int numY = Random.Range(-1, 2);
        this.transform.Translate(numX, 0, numY, Space.World);
        if (0 < numX)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
        }
        else if (numX < 0)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f); 
        }
        else if (0 < numY)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, -180.0f, 0.0f);
        }
        else if (numY < 0)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }
    }
}
