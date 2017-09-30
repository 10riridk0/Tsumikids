using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon_main : MonoBehaviour {

    public static bool fading = false;
    public static int stage_number;
    public static string enemy_name;
    public static int enemy_number;
    public static int tsumihiko_x, tsumihiko_y;

    // Use this for initialization
    void Start()
    {
        SaveData.SetInt("x", tsumihiko_x);
        SaveData.SetInt("y", tsumihiko_y);
        SaveData.Save();
        stage_number = Stage.get_stage_number();
        Debug.Log(stage_number);
        Debug.Log(Stage.start_position[stage_number - 1]);
        Main.trans_tsumihiko = GetComponent<Transform>();
        Debug.Log(Main.trans_tsumihiko);
        Vector3 initial = Stage.start_position[stage_number - 1];
        Main.trans_tsumihiko.position = initial;
    }

    private void Awake()
    {
        tsumihiko_x = 1;
        tsumihiko_y = 1;
        fading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!fading)
        {
            SceneTransition.FadeIn();
        }

        if (fading)
        {
            SceneTransition.ChangeScene("battle");
        }
    }

    void OnTriggerEnter2D(Collider2D t)
    {
        GameObject enemy = t.gameObject;
        enemy_name = enemy.name;
        Debug.Log(enemy_name);
        enemy_number = Stage.map[stage_number - 1, tsumihiko_y, tsumihiko_x] - 2;
        Debug.Log(Stage.map[stage_number - 1, tsumihiko_y, tsumihiko_x]);
        Debug.Log(enemy_number);
        Animator animator;
        animator = enemy.GetComponent<Animator>();
        animator.SetBool("wara", true);
        SaveData.SetInt("x", Program_Execution.x);
        SaveData.SetInt("y", Program_Execution.y);
        SaveData.Save();
        fading = true;
    }

    public static string get_probrem(int num)
    {
        return (Enemy_data.Probrems[Dungeon_main.enemy_name[7], Dungeon_main.enemy_number]);
    }

    public static void Goal()
    {
        Vector3[] p = { new Vector3(-500, -300, 0), new Vector3(-0, 150, 0), new Vector3(150, -100, 0)} ;
        EffectPosition.fire_work(p[0]);
        EffectPosition.fire_work(p[1]);
        EffectPosition.fire_work(p[2]);
    }
}
