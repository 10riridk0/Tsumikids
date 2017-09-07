using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionAfter : MonoBehaviour
{
    private bool isFadein = true;
    void Start()
    {
        Fade.alfa = 1;      //念のためalfa値を1で初期化する
    }

    void Update()
    {
        if (isFadein)
        {
            //isFadeinがtrue(フェードアウト済み, かつシーン切り替えが終了している)ときフェードインする
            Debug.Log("シーンをフェードインします");
            Fade.Fadein();
        }
    }
}
