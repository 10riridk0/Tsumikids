using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    /*シーン遷移・フェード用の変数*/
    GameObject fadePrefab;                                      //プレハブを取得する
    public static GameObject fadeCanvas;                        //フェードするためのCanvas
    public static GameObject sceneTransition;                   //シーン遷移するためのGameObject
    public static Image image;
    public static float r, b, g, alfa;                          //alfa: 1のとき不透明, 0のとき透明
    public static float fadeSpeed = 0.05f;                      //フェードスピード
    public static bool isFadeOut = false, isFadeIn = false;     //フェードしたか否かを判定する変数

    //フェードイン関数
    //isFadeInがfalseの間フェードインし続ける
    public static void FadeIn()
    {
        if (!isFadeIn)
        {
            alfa -= fadeSpeed;
            Debug.Log(alfa);
            image.color = new Color(r, g, b, alfa);     //透明度を更新
            if (alfa <= 0)
            {
                Debug.Log("フェードイン終了");
                isFadeIn = true;                        //alfa < 0なのでフェードイン終了
                fadeCanvas.SetActive(false);
            }
        }
    }
    //フェードアウト関数
    //isFadeOutがfalseの間フェードアウトし続ける
    public static void FadeOut()
    {
        fadeCanvas.SetActive(true);
        if (!isFadeOut)
        {
            alfa += fadeSpeed;
            image.color = new Color(r, g, b, alfa);
            //Debug.Log("isFadeOut>> " + isFadeOut);
            if (alfa > 1)
            {
                //Debug.Log("フェードアウト終了");
                isFadeOut = true;
            }
        }
    }

    //フェードアウトしてシーンを切り替える関数
    //仮引数: 遷移したいシーンの名前
    public static void ChangeScene(string sceneName)
    {
        Debug.Log(sceneName);
        Debug.Log(SceneManager.GetActiveScene().name);
        Debug.Log("フェードアウト開始");
        FadeOut();
        if (isFadeOut)                               //フェードアウトし終えたら次のシーンを読み込む
        {
            SceneManager.LoadScene(sceneName);       //シーン読み込み
            Debug.Log("シーン遷移終了");
            isFadeOut = false;
            isFadeIn = false;                        //isFadeOutとisFadeInをfalseに戻しておく
            Debug.Log(isFadeOut);
        }
    }
    //フェードイン関数
    public static void SceneFadeIn()
    {
        //Debug.Log("フェードイン開始");
        FadeIn();
    }

    // Use this for initialization
    void Start()
    {
        if (GameObject.Find("FadeCanvas(Clone)") == null)                               //Hierarchyの中にFadeCanvasがなかったら生成する
        {
            fadePrefab = (GameObject)Resources.Load("FadePrefab/FadeCanvas");
            fadeCanvas = (GameObject)Instantiate(fadePrefab);
        }
        DontDestroyOnLoad(this);                                                        //遷移してもSceneTransitionを破棄しないようにする
        DontDestroyOnLoad(fadeCanvas);
        image = GameObject.Find("Panel").GetComponent<Image>();                         //PanelのImageコンポーネント取得
        fadeCanvas.SetActive(false);                                                    //非表示にする
    }
}
