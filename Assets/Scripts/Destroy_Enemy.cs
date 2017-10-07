using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Enemy : MonoBehaviour {
    //ダンジョン上の敵番号
    public static int enemy_number;

    // Use this for initialization
    void Start () {
        //kill_Enemy();
        //Destroy_Enemy.transform.position = new Vector3(0, 0, 0);
        //kill_Enemy();
    }

    private void Awake()
    {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void kill_Enemy()
    {
        GameObject destroy_obj;
        for (int i = 0; i < Main.isAlive.Length; i++)
        {
            if (Main.isAlive[i] == '0')
            {
                destroy_obj = GameObject.Find(Stage.map_enemy[Dungeon_main.stage_number - 1, i]);
                Destroy(destroy_obj);
            }
        }
    }
    
}
