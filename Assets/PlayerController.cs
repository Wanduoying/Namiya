using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class status{
}

public class PlayerController : MonoBehaviour {

    private int hp = 15; //HP
    private int level = 1; //レベル
    private int attackPower = 1; //攻撃力
    private int defensePower = 0; //防禦力
    private int accuracy = 50; //命中率
    private int evasioRate = 50; //囘避率
    private int satiation = 100; //滿腹度

    //カメラ用
    private GameObject mainCamera;
    float mainCameraX;
    float mainCameraY;
    float mainCameraZ;

    void Start () {
        //ゲーム開始時にカメラの座標をプレイヤー附近にする
        mainCamera = GameObject.Find("Camera");
        mainCameraX = this.gameObject.transform.position.x;
        mainCameraY = this.gameObject.transform.position.y + 4;
        mainCameraZ = this.gameObject.transform.position.z - 2;

        mainCamera.transform.position = new Vector3(mainCameraX,mainCameraY,mainCameraZ);
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.Translate(-1, 0, 0, Space.World);
            this.transform.Rotate(0,0,0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.Translate(1, 0, 0, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.transform.Translate(0, 0, 1, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.transform.Translate(0, 0, -1, Space.World);
        }
    }
}
