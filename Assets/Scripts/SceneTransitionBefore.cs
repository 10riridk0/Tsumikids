using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionBefore : MonoBehaviour
{

    public string nextSceneName = null;                //切り替えるシーンの名前
    public static bool flag;

    //シーン切り替え関数
    //仮引数: 切り替えるシーンの名前
    public void ScreenTrans(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void Start()
    {
        flag = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            flag = true;
            Debug.Log("SceneTransitionBefore.flag>> " + flag);
        }
        if (flag)
        {
            //isFadeoutがfalseのとき(フェードアウトしていない)フェードアウトする
            if (!Fade.isFade)
            {
                Fade.Fadeout();
                Debug.Log("シーンをフェードアウトします");
            }
            //isFadeがtrueのとき(フェードアウトしている)ときシーンを切り替える
            if (Fade.isFade)
            {
                ScreenTrans(nextSceneName);
                Debug.Log("シーンを切り替えます");
            }
        }
    }
}
