using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_data : MonoBehaviour {

    public static string[,] Probrems = { {"pk" , "pm"}, {"kpm", "mkp"}, {"ppkmm", "kpmmk"}, {"pkmm", "pkmm"}, {"mmmm", "pppp"}};

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static string get_probrem()
    {
        return (Probrems[Dungeon_main.enemy_name[7] - '1', Dungeon_main.enemy_number]);
    }
}
