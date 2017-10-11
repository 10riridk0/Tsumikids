using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Program_Execution : MonoBehaviour {

    //プログラムの文字を格納する
    public static char instruction;
    //??
    public static Vector3 before_change;
    //移動時に足していく
    public static Vector3 add;// = new Vector3(0, 0, 0);
    //ステージ情報をとる
    public static Stage stage;
    //シーンの頭文字をとる
    public static char name_initial;
    //コルーチンを実行する
    public static Program_Execution instance;
    //問題正解したか
    public static bool isCorrect;
    //シーン遷移するか
    public static bool correct;
    //つみひこのいるマス
    public static int x, y;

    //つみひこのアニメーション
    GameObject enemy;
    GameObject tumihico;
    static Animator tumihico_animator;
    static Animator enemy_animator;
    static int tu = 0;
    static int en = 0;

    // Use this for initialization
    void Start () {

        //つみひこ、敵のアニメーター取得
        if (SceneManager.GetActiveScene().name == "battle")
        {
            tumihico = GameObject.Find("tu_mihico");
            enemy = GameObject.Find("enemy");
            tumihico_animator = tumihico.GetComponent<Animator>();
            enemy_animator = enemy.GetComponent<Animator>();

            Debug.Log(tumihico_animator);
            Debug.Log(enemy_animator);
        }
        //exe("uuu");
        
    }
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "battle")
        {
            enemy_animator.SetInteger("enemy_status", en);
            tumihico_animator.SetInteger("tu_mihico_status", tu);
            //Debug.Log(tu);
        }
    }

    private void Awake()
    {
        if (correct == true)
        {
            
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
        Debug.Log(Stage.map[Dungeon_main.stage_number - 1, Dungeon_main.tsumihiko_y, Dungeon_main.tsumihiko_x]);

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

    static IEnumerator Attack(char actions, char probrem, int n)
    {
        Debug.Log(probrem);
        Debug.Log(actions);
        if (actions != probrem)
        {
            Battle_main.des_black();
            Main.life--;
            isCorrect = false;

            //つみひこダメージ
            tu = 5;
            en = 1;

            yield break;
        }

        en = 2;
        switch (actions)
        {
            case 'p':
                tu =  3;
                Debug.Log("punch");
                Debug.Log(tu);
                break;
            case 'k':
                tu = 1;
                Debug.Log("kick");
                Debug.Log(tu);
                break;
            case 'm':
                tu = 2;
                Debug.Log("magic");
                Debug.Log(tu);
                break;
        }
        Battle_main.disp_black(n);
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
        int i;
        int err_check = check_error(program, scene_initial);
        Debug.Log(err_check);
        if (err_check != 0)
        {
            instance.StartCoroutine(Main.disp_error(err_check));
            yield break;
        }
        program = expansion(program);
        program = program.TrimEnd(' ');
        for (i = 0; i < program.Length; i++)
        {
            Debug.Log(program[i]);
        }
        
        //一文字ずつ読み込むやつ
        for (i = 0; i < program.Length; i++)
        {
            instruction = program[i];

            if (scene_initial == 'S')
            {
                instance.StartCoroutine(move(instruction));
                yield return new WaitForSeconds(2.2f);
            }
            else if (scene_initial == 'b'){
                //問題の文字数を超えたらアウト
                try {
                    Debug.Log(Battle_main.probrem[i]);
                    instance.StartCoroutine(Attack(instruction, Battle_main.probrem[i], i));
                }
                catch (System.IndexOutOfRangeException e)
                {
                    Main.life--;
                    //つみひこだめーじ
                    tu = 5;
                    en =  1;
                    isCorrect = false;
                    break;
                }

                
                yield return new WaitForSeconds(3.0f);

                /*if (isCorrect == true)
                {
                    if (program != Battle_main.probrem)
                    {
                        tu = 0;
                        en = 0;
                        yield return new WaitForSeconds(1.0f);
                        Main.life--;
                        //つみひこだめーじ
                        tu = 5;
                        en = 1;
                        isCorrect = false;
                        yield return new WaitForSeconds(3.0f);
                        Debug.Log("足りない");
                    }
                }*/

                Main.life_display();

                //アニメーション戻す
                tu = 0;
                en = 0;
                Debug.Log("Reset");
                yield return new WaitForSeconds(1.0f);

                if (isCorrect == false)
                {
                    Debug.Log("中断");
                    break;
                }
            }

            //yield return move(directions);
            
        }
        if (scene_initial == 'b')
        {
            if (isCorrect == true)
            {
                if (isCorrect == true)
                {
                    string alive = SaveData.GetString("isAlive");
                    char[] new_alive = alive.ToCharArray();
                    int n = SaveData.GetInt("enemy_num");

                    new_alive[n - 1] = '0';
                    alive = new string(new_alive);
                    SaveData.SetString("isAlive", alive);
                    Debug.Log(alive);
                    correct = true;
                }
            }
            else
            {
                Debug.Log("isCorrect == true");
                isCorrect = true;
            }

            Battle_main.dead_tsu();
        }

    }

    //ループが使用されているときの展開
    public static string expansion(string original)
    {
        Debug.Log(original);
        string expanded = "";
        int start_pos = original.IndexOf("f");
        int end_pos = original.IndexOf("f", start_pos + 1);
        char[] new_str = new char[20];
        int index;

        Debug.Log(start_pos);
        Debug.Log(end_pos);

        Debug.Log("before roop");
        //ループ前の文字列を代入
        for (index = 0; index < start_pos; index++)
        {
            //new_str[index]
            expanded += original[index].ToString();
            Debug.Log(original[index]);
        }

        Debug.Log("roop");
        //index++;
        //ループ内の文字列を代入
        for (int i = 0; i < (original[start_pos + 1] - '0'); i++)
        {
            Debug.Log(i - (original[start_pos + 1] - '0'));
            for (int j = start_pos + 2; j < end_pos; j++)
            {
                //new_str[index]
                expanded += original[j].ToString();
                Debug.Log(original[j]);
                Debug.Log(index);
                index++;
            }

            if (i > original.Length)
            {
                break;
            }
        }

        Debug.Log("after roop");
        //ループ後の文字列代入
        for (int i = end_pos + 1; i < original.Length; i++)
        {
            //new_str[index]
            expanded += original[i].ToString();
            Debug.Log(original[i]);
            index++;
        }

        //expanded = new_str.ToString();
        //expanded = new string(new_str);

        for (int i = 0; i < new_str.Length; i++)
        {
            Debug.Log(new_str[i]);
        }
        //Debug.Log(new_str);
        Debug.Log(new_str.ToString());
        Debug.Log(expanded);
        return (expanded);
    }

    public static void exe(string pro)
    {
        name_initial = Stage.scene_name[0];
        Debug.Log(pro);
        Debug.Log(name_initial);
        instance.StartCoroutine(Read(pro, name_initial));
    }

    public static int check_error(string program, char sce_ini)
    {
        int err = 0;
        bool start = false;

        switch (sce_ini)
        {
            case 'S':
                for (int i = 0; i < program.Length; i++)
                {
                    if (program[i] == 'p' || program[i] == 'k' || program[i] == 'm')
                    {
                        err = -6;
                    }
                }
                break;
            case 'b':
                for (int i = 0; i < program.Length; i++)
                {
                    if (program[i] == 'u' || program[i] == 'd' || program[i] == 'r' || program[i] == 'l')
                    {
                        err = -6;
                    }
                }
                break;
        }

        if (err != 0)
        {
            return (err);
        }

        for (int i = 0; i < program.Length; i++)
        {
            try
            {
                if (program[i] == 'f' && program[i + 1] - '0' < 10)
                {
                    start = true;
                }
            }
            catch
            {

            }

            if (start == true)
            {
                try
                {
                    if (program[i] == 'f' && program[i + 1] - '0' > 9)
                    {
                        start = false;
                    }
                }
                catch (System.IndexOutOfRangeException e)
                {
                    start = false;
                }
            }
            
        }

        if (start == true)
        {
            err = -4;
        }

        return (err);
    }
}