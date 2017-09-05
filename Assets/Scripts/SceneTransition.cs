using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    GameObject prefab;
    GameObject fadeCanvas;
    Image image;
    private float r, b, g, alfa;        //alfa: 1のとき不透明, 0のとき透明
    private float fadeSpeed = 0.07f;
    private bool finishFadeOut = true;

    //フェードイン関数
    private void FadeIn()
    {
        alfa += fadeSpeed;
        image.color = new Color(r, g, b, alfa);

    } 
    //フェードアウト関数
    private void FadeOut()
    {
        if (finishFadeOut)
        {
            Debug.Log(alfa);
            alfa += fadeSpeed;
            image.color = new Color(r, g, b, alfa);
            if (alfa > 1)
            {
                alfa = 1;
                finishFadeOut = false;
            }
        }
    }
    //シーンの切り替え+フェードアウト関数
    public void Change(string sceneName)
    {
        FadeOut();
        SceneManager.LoadScene(sceneName);
        //FadeIn();
    }
    // Use this for initialization
    void Start () {
        if (GameObject.Find("FadeCanvas") == null)                              //Hierarchyの中にFadeCanvasなかったら生成する
        {
            prefab = (GameObject)Resources.Load("FadePrefab/FadeCanvas");
            fadeCanvas = (GameObject)Instantiate(prefab);
        }
        DontDestroyOnLoad(fadeCanvas);                                          //シーン遷移しても破棄しないようにする(永続的に保持)
        image = GameObject.Find("Panel").GetComponent<Image>();                 //PanelのImageコンポーネント取得
        alfa = 0;
    }
	
	// Update is called once per frame
	void Update () {
        FadeOut();
	}
}
