using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour {
    //public GameObject MainCamera;

    private GameObject mainCamera;

    void Start()
    {
        this.mainCamera = GameObject.Find("Main Camera");
    }

    void Update () {
        Vector3 p = mainCamera.transform.position;
        p.y = transform.position.y;
        transform.LookAt(p);
	}
}
