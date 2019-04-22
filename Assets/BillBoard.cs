using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour {
    //public GameObject MainCamera;

    private GameObject mainCamera;

    void Start()
    {
        this.mainCamera = GameObject.Find("Camera");
    }

    void Update () {
            this.transform.LookAt(mainCamera.transform);

        /*
        Vector3 p = mainCamera.transform.position;
        p.y = transform.position.y;
        transform.LookAt(p);
        */
    }
}
