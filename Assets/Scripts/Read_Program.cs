using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Read_Program : MonoBehaviour {

	// Use this for initialization
	void Start() {
        //Read("urur");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Read(string program)
    {
        string direction;
        Queue<string> queue = new Queue<string>() { };

        for (int i = 0; i < program.Length; i++)
        {
            queue.Enqueue(program[i].ToString());
            direction = queue.Dequeue();
            Debug.Log(direction);
            StartCoroutine("move", direction);
        }
    }
}
