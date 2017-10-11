using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    GameObject t;
    Animator a;

    public static string scene_name = "empty"; 

    // Use this for initialization
    void Start() {
        scene_name = "empty";
        SaveData.Clear();
    }
	
	// Update is called once per frame
	void Update () {
        SceneTransition.FadeIn();
        if (scene_name != "empty")
        {
            SceneTransition.ChangeScene(scene_name);
        }
        //SceneTransition.ChangeScene("Stage1");
	}

    IEnumerator tu()
    {
        a.SetInteger("tu_mihico_status", 1);
        yield return new WaitForSeconds(3.0f);
        Debug.Log(a);

        a.SetInteger("tu_mihico_status", 0);
        yield return new WaitForSeconds(3.0f);
        Debug.Log(a);

        a.SetInteger("tu_mihico_status", 2);
        yield return new WaitForSeconds(3.0f);
        Debug.Log(a);

        a.SetInteger("tu_mihico_status", 0);
        yield return new WaitForSeconds(3.0f);
        Debug.Log(a);

        a.SetInteger("tu_mihico_status", 3);
        yield return new WaitForSeconds(3.0f);
        Debug.Log(a);

        a.SetInteger("tu_mihico_status", 0);
        yield return new WaitForSeconds(3.0f);
        Debug.Log(a);

        a.SetInteger("tu_mihico_status", 4);
        yield return new WaitForSeconds(3.0f);
        Debug.Log(a);

        a.SetInteger("tu_mihico_status", 0);
        yield return new WaitForSeconds(3.0f);
        Debug.Log(a);

        a.SetInteger("tu_mihico_status", 5);
        yield return new WaitForSeconds(3.0f);
        Debug.Log(a);

        a.SetInteger("tu_mihico_status", 0);
        yield return new WaitForSeconds(3.0f);
        Debug.Log(a);
    }

    public static void main_menu(Vector3 pos)
    {
        SaveData.Clear();
        Debug.Log(pos);
        if (pos.x >= 500 && pos.y <= 700)
        {
            if (pos.y >= 251 && pos.y <= 500)
            {
                //続きから
                scene_name = SaveData.GetString("Stage", "Stage1");
                SaveData.Clear();
            }
            else if (pos.y >= 1 && pos.y <= 250)
            {
                scene_name = SaveData.GetString("Stage", "Stage1");
                SaveData.Clear();
                //scene_name = "tutorial";
                //チュートリアル
            }
            else if (pos.y >= -251 && pos.y <= 0)
            {
                //設定
            }
            else if (pos.y >= -500 && pos.y <= -250)
            {
                Debug.Log("終了します");
                Application.Quit();
                //終了
            }
        }
    }
}
