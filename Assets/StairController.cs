using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StairController : MonoBehaviour {

    //プレイヤーが上にきたらシーン再ロード
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("GameScene");
            //Debug.Log("階段");
        }
    }

}
