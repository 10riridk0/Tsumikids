using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string test_text = "test";
        UDPClient UDP = GetComponent<UDPClient>();

        //UDP.text = test_text;
        //UDPClient.Send_data(test_text);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
