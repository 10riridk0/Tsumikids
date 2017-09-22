using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        //animator.SetBool("wara", true);
        string test_text = "test";
        UDPClient UDP = GetComponent<UDPClient>();
        //UDP.Send_data(test_text);
    }
	
	// Update is called once per frame
	void Update () {

	}
}
