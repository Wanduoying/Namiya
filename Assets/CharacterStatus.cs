using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterStatus : MonoBehaviour {

    //ステータス用
    public int level = 0; //レベル
    public float currentExp = 0; //現在の經驗値
    public int hp = 15; //HP
    public int attackPower = 1; //攻撃力
    public int defensePower = 0; //防禦力
    public int accuracy; //命中率
    public int evasioRate; //囘避率
    public int satiation = 100; //滿腹度

    public bool isDead = false; //死亡判定

    private void LevelUp ()
    {
        //敵を倒して得た經驗値が基準値を超えるとレベルが加算される

    }

    //倒されたキャラが、倒したキャラに經驗値を渡す
    public void GiveExp()
    {
        float giveExp = currentExp * 0.1f;
        //渡す処理（後で書く）


    }

    //プレイヤー死亡の場合
    public void PlayerDead()
    {
        isDead = true;
        Destroy(this.gameObject);
        SceneManager.LoadScene("TitleScene");
    }

    //プレイヤー以外死亡の場合
    public void Dead()
    {
        isDead = true;
        Destroy(this.gameObject);
    }
}
