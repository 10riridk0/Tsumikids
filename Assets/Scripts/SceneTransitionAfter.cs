using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionAfter : MonoBehaviour {

    void Start () {
        Fade.alfa = 1;      //念のためalfa値を1で初期化する
	}
	
	void Update () {
        //isFadeinがtrue(フェードアウト済み, かつシーン切り替えが終了している)ときフェードインする
        if (Fade.isFade)
        {
            Debug.Log("フェードインします");
            Fade.Fadein();
        }
    }
}
