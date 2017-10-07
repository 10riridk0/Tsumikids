using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_data : MonoBehaviour {

    public static string[,] Probrems = { {"pk" , "mp"}, {"ppm", "pkp"}, {"kkk", "mmm"}, {"ppm", "mpk"}, {"kkkp", "mpkm"}, {"kmkmp", "mpkkm"} };

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public static string get_probrem()
    {
        Debug.Log(Dungeon_main.enemy_name[7]);
        Debug.Log(Dungeon_main.probrem_number);
        return (Probrems[Dungeon_main.enemy_name[7] - '1', Dungeon_main.probrem_number]);
    }
}
