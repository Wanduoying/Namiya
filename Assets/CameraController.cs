using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    void Start()
    {
    }

    void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-0.5f,0,0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(0.5f, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0, 0, 0.5f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0, 0, -0.5f);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.position += transform.up * -scroll * 5;

        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.Rotate(new Vector3(0, -0.5f, 0));
        }

        if (Input.GetKey(KeyCode.E))
        {
            this.transform.Rotate(new Vector3(0, 0.5f, 0));
        }
    }
}
