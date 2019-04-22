using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    public bool turn = false;

    private DungeonGenerator dungeonGenerator;

    //行動状態
    public enum State
    {
        // プレイヤー
        Player_Turn, // キー入力待ち。もしくは待機中
        // 敵
        Enemy_Turn,      // 実行中
    };

    public State StateNumber = State.Player_Turn;

    void Start()
    {
        dungeonGenerator = GameObject.Find("FieldGeneratorObj").GetComponent<DungeonGenerator>();
    }

    void Update () {
        
        if (turn)
        {
            switch (StateNumber)
            {
                case State.Player_Turn:
                    StateNumber = State.Enemy_Turn;
                    break;
                case State.Enemy_Turn:
                    for (int i = 0; i < dungeonGenerator.enemyCtrlList.Count; i++)
                    {
                        dungeonGenerator.enemyCtrlList[i].EnemyMove();
                    }
                    StateNumber = State.Player_Turn;
                    turn = false;
                    break;
            }
        }
    }
}
