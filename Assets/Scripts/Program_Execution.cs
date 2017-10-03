using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program_Execution : MonoBehaviour {

    public static char instruction;
    public static Vector3 before_change;
    public static Vector3 add;// = new Vector3(0, 0, 0);
    public static Stage stage;
    public static char name_initial;
    public static Program_Execution instance;
    public static bool isCorrect;
    public static bool correct;
    public static int x, y;

    // Use this for initialization
    void Start () {
        //exe("uuu");
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void Awake()
    {
        GameObject Lv1 = GameObject.Find("teki_Lv1");
        if (correct == true)
        {
            Destroy(Lv1);
        }
        isCorrect = true;
        correct = false;
        instance = this;
        stage = GetComponent<Stage>();
    }

    //つみひこ移動関数
    static IEnumerator move(char direction)
    {
        x = Dungeon_main.tsumihiko_x;
        y = Dungeon_main.tsumihiko_y;
        add = new Vector3(0, 0, 0);
        //before_change = main.trans_tsumihiko.position;
        add = direction_dicied(add, direction);
        //Debug.Log(Stage.map[Dungeon_main.stage_number - 1, x, y]);
        if (Stage.map[Dungeon_main.stage_number - 1, y, x] == 1)
        {
            yield break;
        }

        //つみひこマス移動
        Dungeon_main.tsumihiko_x = x;
        Dungeon_main.tsumihiko_y = y;
        Debug.Log(Dungeon_main.tsumihiko_x);
        Debug.Log(Dungeon_main.tsumihiko_y);
        Debug.Log(Stage.map[Dungeon_main.stage_number - 1, Dungeon_main.tsumihiko_x, Dungeon_main.tsumihiko_y]);

        for (int i = 0; i < 15; i++)
        {
            //つみひこの位置変える
            Main.trans_tsumihiko.position += add;
            //Debug.Log(direction);

            yield return new WaitForSeconds(0.1f);
        }

        if (Stage.map[Dungeon_main.stage_number - 1, Dungeon_main.tsumihiko_x, Dungeon_main.tsumihiko_y] == 99)
        {
            Dungeon_main.Goal();
        }
    }

    static Vector3 direction_dicied(Vector3 add, char direction)
    {
        switch (direction){
            case 'u':
                y++;
                add.y = 10;
                break;
            case 'd':
                y--;
                add.y = -10;
                break;
            case 'r':
                x++;
                add.x = 10;
                break;
            case 'l':
                x--;
                add.x = -10;
                break;
        }

        return (add);
    }

    static IEnumerator Attack(char actions, char probrem)
    {
        Debug.Log(actions);
        if (actions != probrem)
        {
            Main.life--;
            isCorrect = false;
            yield return null;
        }
        switch (actions)
        {
            case 'p':
                break;
            case 'k':
                break;
            case 'm':
                break;
        }
        yield return null;
    }

    /*void OnGUI()
    {
        directions = GUI.TextField(new Rect(10, 10, 200, 20), directions, 25);
        if (GUI.Button(new Rect(10, 10, 100, 40), "Move"))
        {
            StartCoroutine(Read(directions, 'S'));
        }
    }*/

    static IEnumerator Read(string program, char scene_initial)
    {
        //一文字ずつ読み込むやつ
        for (int i = 0; i < program.Length; i++)
        {
            instruction = program[i];

            if (scene_initial == 'S')
            {
                instance.StartCoroutine(move(instruction));
            }
            else if (scene_initial == 'b'){
                instance.StartCoroutine(Attack(instruction, Battle_main.probrem[i]));
            }
            
            //yield return move(directions);
            yield return new WaitForSeconds(2.2f);
        }
        if (scene_initial == 'b')
        {
            if (isCorrect == true)
            {
                correct = true;
            }
            else
            {
                isCorrect = true;
            }
        }

    }

    public static void exe(string pro)
    {
        name_initial = Stage.scene_name[0];
        Debug.Log(pro);
        Debug.Log(name_initial);
        instance.StartCoroutine(Read(pro, name_initial));
    }
}