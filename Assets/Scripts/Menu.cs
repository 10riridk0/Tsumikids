using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SaveData.Clear();
	}
	
	// Update is called once per frame
	void Update () {
        SceneTransition.ChangeScene("Stage1");
	}
}
