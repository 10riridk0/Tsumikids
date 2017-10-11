using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour {

    public static Vector3[] start_position = new Vector3[] {new Vector3(-585, -300, 0), new Vector3(-585, -300, 0), new Vector3(-585, -395, 0), new Vector3(-735, -380, 0), new Vector3(-735, -450, 0)};
    public static int[,,] map = { {{1, 1, 1, 1, 1, 1, 0, 0}, {1, 100, 0, 0, 1, 1, 0, 0}, {1, 0, 1, 3, 0, 1, 0, 0}, {1, 0, 1, 1, 0, 1, 0, 0}, {1, 2, 0, 0, 99, 1, 0, 0}, {1, 1, 1, 1, 1, 1, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0} },
                            {{1, 1, 1, 1, 1, 1, 0, 0}, {1, 100, 1, 1, 1, 1, 0, 0}, {1, 0, 0, 2, 0, 1, 0, 0}, {1, 1, 2, 1, 0, 1, 0, 0}, {1, 1, 0, 2, 99, 1, 0, 0}, {1, 1, 1, 1, 1, 1, 0, 0 }, {0, 0, 0, 0, 0, 0, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0} },
                            {{1, 1, 1, 1, 1, 1, 0, 0}, {1, 100, 0, 0, 1, 1, 0, 0}, {1, 0, 1, 3, 0, 1, 0, 0}, {1, 0, 1, 1, 0, 1, 0, 0}, {1, 3, 0, 1, 2, 1, 0, 0}, {1, 1, 0, 2, 99, 1, 0, 0}, {1, 1, 1, 1, 1, 1, 0, 0}, {0, 0, 0, 0, 0, 0, 0, 0} },
                            {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 100, 0, 0, 1, 1, 1, 1}, {1, 0, 1, 3, 0, 0, 2, 1}, {1, 2, 1, 1, 1, 1, 0, 1}, {1, 0, 1, 0, 3, 0, 2, 1}, {1, 0, 3, 0, 1, 1, 99, 1}, {1, 1, 1, 1, 1, 1, 1, 1}, {0, 0, 0, 0, 0, 0, 0, 0} },
                            {{1, 1, 1, 1, 1, 1, 1, 1}, {1, 100, 0, 0, 2, 1, 1, 1}, {1, 0, 1, 1, 0, 1, 1, 1}, {1, 3, 1, 1, 0, 2, 1, 1}, {1, 0, 1, 1, 1, 0, 1, 1}, {1, 0, 2, 1, 0, 0, 1, 3 }, {1, 1, 0, 0, 2, 1, 99, 1 }, {1, 1, 1, 1, 1, 1, 1, 1 } } };

    public static string[,] map_enemy = { {"teki_Lv1", "teki_Lv2", "", "", "", ""},
                                                                        {"teki_Lv3", "teki_Lv2", "teki_Lv1", "", "", ""},
                                                                        {"teki_Lv2_1", "teki_Lv1", "teki_Lv2_2", "teki_Lv3", "", ""},
                                                                        {"teki_Lv1_1", "teki_Lv4_1", "teki_Lv2", "teki_Lv4_2", "teki_Lv3", "teki_Lv1_2"},
                                                                        {"teki_Lv2", "teki_Lv4_1", "teki_Lv4_2", "teki_Lv3", "teki_Lv1", "teki_Lv5"} };
    public static int stage_num;
    public static string scene_name;
    private int a = 0;

    // Use this for initialization
    void Start () {
        
    }

    private void Awake()
    {
        scene_name = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(scene_name);
    }
    
    public static int get_stage_number()
    {
        return (set_num());
    }

    public static int set_num()
    {
        Debug.Log(scene_name);
        stage_num = scene_name[5] - '0';
        return stage_num;
    }
}
//ダンジョンとバトルシーンで共有するデータはmainに書く