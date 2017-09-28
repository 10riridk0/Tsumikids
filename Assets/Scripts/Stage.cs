using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour {

    public static Vector3[] start_position = new Vector3[] {new Vector3(-585, -300, 0), new Vector3(-585, -300, 0), new Vector3(-735, -450, 0)};
    public static int[,,] map = { {{1, 1, 1, 1, 1, 1, 0, 0 }, {1, 0, 0, 0, 1, 1, 0, 0 }, {1, 0, 1, 0, 0, 1, 0, 0 }, {1, 0, 1, 1, 0, 1, 0, 0 }, {1, 0, 0, 0, 0, 1, 0, 0}, {1, 1, 1, 1, 1, 1, 0, 0 }, {0, 0, 0, 0, 0, 0, 0, 0 }, {0, 0, 0, 0, 0, 0, 0, 0 } },
                            {{1, 1, 1, 1, 1, 1, 0, 0 }, {1, 0, 1, 1, 1, 1 , 0, 0}, {1, 0, 0, 0, 0, 1, 0, 0 }, {1, 1, 0, 1, 0, 1, 0, 0}, {1, 1, 0, 0, 0, 1, 0, 0} ,{1, 1, 1, 1, 1, 1, 0, 0 }, {0, 0, 0, 0, 0, 0, 0, 0 }, {0, 0, 0, 0, 0, 0, 0, 0 }, },
                            {{1, 1, 1, 1, 1, 1, 1, 1 }, { 1, 0, 0, 0, 0, 0, 0, 1}, {1, 0, 1, 1, 1, 1, 0, 1 }, {1, 0, 1, 1, 0, 0, 0, 1 }, {1, 0, 1, 1, 0, 1, 1, 1 }, {1, 0, 0, 0, 0, 0, 0, 1 }, {1, 1, 0, 0, 0, 1, 0, 1 }, {1, 1, 1, 1, 1, 1, 1, 1 } } };
    public static int stage_num;
    public static string scene_name;

    // Use this for initialization
    void Start () {
        
    }

    private void Awake()
    {
        scene_name = SceneManager.GetActiveScene().name;
        //scene_num = scene_name;
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
