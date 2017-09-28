using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon_main : MonoBehaviour {

    public static Transform trans_tsumihiko;
    public static bool fading = false;
    int stage_number;

    // Use this for initialization
    void Start()
    {
        stage_number = Stage.get_stage_number();
        Debug.Log(stage_number);
        Debug.Log(Stage.start_position[stage_number - 1]);
        trans_tsumihiko = GetComponent<Transform>();
        Debug.Log(trans_tsumihiko);
        Vector3 initial = Stage.start_position[stage_number - 1];
        trans_tsumihiko.position = initial;

    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            SceneTransition.ChangeScene("battle");
        }
    }

    void OnTriggerEnter2D(Collider2D t)
    {
        GameObject enemy = t.gameObject;
        Animator animator;
        animator = enemy.GetComponent<Animator>();
        animator.SetBool("wara", true);
        Debug.Log(t);
        fading = true;
    }
}
