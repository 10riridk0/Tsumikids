using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_main : MonoBehaviour {

    GameObject enemy_object;
    Vector3 initial_pos = new Vector3(90, 7, 0);
    public static string probrem;
    

	// Use this for initialization
	void Start () {
        probrem = Enemy_data.get_probrem();
        Debug.Log(probrem);
        //enemy_object = GameObject.Find(Dungeon_main.enemy_name);
        enemy_object = (GameObject)Resources.Load("Enemy/" + Dungeon_main.enemy_name);
        Instantiate(enemy_object, initial_pos, Quaternion.identity);
        //SceneTransition.ChangeScene("Stage1");
    }

    private void Awake()
    {
        //enemy_object = GameObject.Find("Prefabs/Battle/" + Dungeon_main.enemy_name);
    }

    // Update is called once per frame
    void Update () {
        SceneTransition.FadeIn();
        if (Program_Execution.correct == true)
        {
            SceneTransition.ChangeScene("Stage1");
        }
    }
}
