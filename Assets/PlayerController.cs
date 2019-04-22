using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private GameObject enemyPrefab;
    private GameObject playerStatus;
    private GameObject mainCamera;
    private GameObject turnManager;
    private DungeonGenerator dungeonGenerator;

    TurnManager turnM;

    //クラスCharacterStatusのインスタンス化
    CharacterStatus PlayerSta = new CharacterStatus();

    private bool isDead = false;


    void Start () {

        //ゲーム開始時にカメラの座標をプレイヤー附近にする
        mainCamera = GameObject.Find("Camera");
        float mainCameraX = this.gameObject.transform.position.x;
        float mainCameraY = this.gameObject.transform.position.y + 10;
        float mainCameraZ = this.gameObject.transform.position.z - 5.5f;
        
        mainCamera.transform.position = new Vector3(mainCameraX,mainCameraY,mainCameraZ);

        //各種オブジェクト取得
        enemyPrefab = GameObject.Find("EnemyPrefab(Clone)");
        turnManager = GameObject.Find("TurnManaherObj");
        turnM = turnManager.GetComponent<TurnManager>();
        this.playerStatus = GameObject.Find("Player Status");
        this.playerStatus.GetComponent<Text>().text = "HP:" + PlayerSta.hp;

        dungeonGenerator = GameObject.Find("FieldGeneratorObj").GetComponent<DungeonGenerator>();
    }

    void Update () {
        //移動
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (dungeonGenerator.map[dungeonGenerator.playerPosX - 1, dungeonGenerator.playerPosZ] != 0 /*&& 2 <= dungeonGenerator.mapChara[dungeonGenerator.playerPosX - 1, dungeonGenerator.playerPosZ]*/) //移動先が壁でない場合
            {
                dungeonGenerator.mapChara[dungeonGenerator.playerPosX, dungeonGenerator.playerPosZ] = 99; //移動前の座標に99を代入
                dungeonGenerator.playerPosX--;
                dungeonGenerator.mapChara[dungeonGenerator.playerPosX, dungeonGenerator.playerPosZ] = 100;//移動後の座標に100を代入

                this.transform.Translate(-1, 0, 0, Space.World);
                this.transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f); //Quaternion.Euler(, , ,)向きを直接代入
                turnM.turn = true;
            }
            else { }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (dungeonGenerator.map[dungeonGenerator.playerPosX + 1, dungeonGenerator.playerPosZ] != 0 /*&& 2 <= dungeonGenerator.mapChara[dungeonGenerator.playerPosX + 1, dungeonGenerator.playerPosZ]*/) //移動先が壁でない場合
            {
                dungeonGenerator.mapChara[dungeonGenerator.playerPosX, dungeonGenerator.playerPosZ] = 99; //移動前の座標に99を代入
                dungeonGenerator.playerPosX++;
                dungeonGenerator.mapChara[dungeonGenerator.playerPosX, dungeonGenerator.playerPosZ] = 100;//移動後の座標に100を代入

                this.transform.Translate(1, 0, 0, Space.World);
                this.transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
                turnM.turn = true;
            }
            //else { }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (dungeonGenerator.map[dungeonGenerator.playerPosX, dungeonGenerator.playerPosZ+1] != 0 /*&& 2 <= dungeonGenerator.mapChara[dungeonGenerator.playerPosX, dungeonGenerator.playerPosZ+1]*/) //移動先が壁でない場合
            {
                dungeonGenerator.mapChara[dungeonGenerator.playerPosX, dungeonGenerator.playerPosZ] = 99; //移動前の座標に99を代入
                dungeonGenerator.playerPosZ++;
                dungeonGenerator.mapChara[dungeonGenerator.playerPosX, dungeonGenerator.playerPosZ] = 100;//移動後の座標に100を代入

                this.transform.Translate(0, 0, 1, Space.World);
                this.transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                turnM.turn = true;
            }
            else { }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (dungeonGenerator.map[dungeonGenerator.playerPosX, dungeonGenerator.playerPosZ-1] != 0 /*&& 2 <= dungeonGenerator.mapChara[dungeonGenerator.playerPosX, dungeonGenerator.playerPosZ - 1]*/) //移動先が壁でない場合
            {
                dungeonGenerator.mapChara[dungeonGenerator.playerPosX, dungeonGenerator.playerPosZ] = 99; //移動前の座標に99を代入
                dungeonGenerator.playerPosZ--;
                dungeonGenerator.mapChara[dungeonGenerator.playerPosX, dungeonGenerator.playerPosZ] = 100;//移動後の座標に100を代入

                this.transform.Translate(0, 0, -1, Space.World);
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                turnM.turn = true;
            }
            else { }
        }

        //攻撃
        //攻撃コマンド（Zキー）を押下したとき
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //プレイヤーの向いて居る方向に敵が居た場合
            if (true /*「敵が居たら」の条件文　左のtrueは仮です*/)
            {
                //プレイヤーの攻撃力や敵の防御力などに基づいて、敵のHPを減らす処理
            }            
        }

        //HPのUI
        if (Input.GetKeyDown(KeyCode.O))
        {
            PlayerSta.hp -= 5;
            this.playerStatus.GetComponent<Text>().text = "HP:"+ PlayerSta.hp;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerSta.hp += 5;
            this.playerStatus.GetComponent<Text>().text = "HP:" + PlayerSta.hp;
        }
        if (PlayerSta.hp <= 0)
        {
            isDead = true;
            if (isDead)
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
    }

    public void PlayerMove()
    {
        int num = Random.Range(-1, 2);
        this.transform.Translate(num, 0, num, Space.Self);
        Debug.Log("PlayerMoveが実行");
    }
}
