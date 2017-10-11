using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_main : MonoBehaviour {

    GameObject enemy_object;
    Vector3 initial_pos = new Vector3(90, 7, 0);
    public static string probrem;
    public static bool isdead;
    public static string stage;


    // Use this for initialization
    void Start () {
        isdead = false;
        //ライフの表示
        Main.life_display();
        //問題の取得、表示
        probrem = Enemy_data.get_probrem();
        display_prob();

        Debug.Log(probrem);
        //enemy_object = GameObject.Find(Dungeon_main.enemy_name);
        //SceneTransition.ChangeScene("Stage1");
    }

    private void Awake()
    {
        //enemy_object = GameObject.Find("Prefabs/Battle/" + Dungeon_main.enemy_name);
        enemy_object = (GameObject)Resources.Load("Battle/Battle_enemy/" + SaveData.GetString("enemy_name"));
        Instantiate(enemy_object, initial_pos, Quaternion.identity).name = "enemy";
    }

    // Update is called once per frame
    void Update () {
        SceneTransition.FadeIn();
        if (Program_Execution.correct == true)
        {
            BgmFader.FadeSet();
            SceneTransition.ChangeScene(SaveData.GetString("Stage"));
        }

        if (isdead)
        {
            BgmFader.FadeSet();
            SceneTransition.ChangeScene(stage);
        }
    }

    public static void display_prob()
    {
        GameObject icon;

        int icon_y = 345 - 60 * (5 - probrem.Length);
        Vector3 icon_pos = new Vector3(-350, 0, 0);
        for (int i = probrem.Length; i > 0; i--)
        {
            icon_pos.y =  -105 + icon_y - icon_y / (probrem.Length - 1) * (probrem.Length - i);
            icon = (GameObject)Resources.Load("Battle/attack_icon/" + probrem[probrem.Length - i]);
            Instantiate(icon, icon_pos, Quaternion.identity);
        }
    }

    public static void disp_black(int n)
    {
        GameObject black;
        int icon_y = 345 - 60 * (5 - probrem.Length);
        Vector3 icon_pos = new Vector3(-350, 0, 0);

        black = GameObject.Find(probrem[n] + "(Clone)");
        //Destroy(black);

        icon_pos.y = -105 + icon_y - icon_y / (probrem.Length - 1) * n;
        black = (GameObject)Resources.Load("Battle/attack_icon/" + probrem[n] + "2");
        Instantiate(black, icon_pos, Quaternion.identity).name += n.ToString();
    }

    public static void des_black()
    {
        GameObject des;
        for (int i = probrem.Length; i > 0; i--)
        {
            try
            {
                des = GameObject.Find(probrem[probrem.Length - i] + "2(Clone)" + (probrem.Length - i).ToString());
                Debug.Log(des);
                Destroy(des);
            }
            catch (System.NullReferenceException e)
            {

            }
            Debug.Log(i);
        }
    }

    public static void dead_tsu()
    {
        if (Main.life < 1)
        {
            stage = SaveData.GetString("Stage");
            SaveData.Clear();
            isdead = true;
            Main.life = 3;
        }
    }
}
