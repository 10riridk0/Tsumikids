using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SaveTest : MonoBehaviour
{

    [SerializeField]
    public class Player
    {
        [SerializeField]
        public int hp;
        public float atk;
        public string name;
        public List<string> items;
        public Player()
        {

            items = new List<string>();
            items.Add("�|�[�V����");
            items.Add("�G�[�e��");
            items.Add("�G���N�T�[");
            hp = 10;
            atk = 100f;
            name = "�N���E�h";
        }

    }
    // Use this for initialization
    void Start()
    {
        //�Z�[�u�f�[�^�̐ݒ�
        SaveData.SetInt("i", 10);
        SaveData.SetClass<Player>("p1", new Player());
        SaveData.Save();

        Player getPlayer = SaveData.GetClass<Player>("p1", new Player());

        Debug.Log("�擾����int�l��" + SaveData.GetInt("i"));
        Debug.Log(getPlayer.name);
        Debug.Log(getPlayer.items.Count + "���A�C�e���������Ă܂�");
        Debug.Log(getPlayer.items[0] + getPlayer.items[1] + getPlayer.items[2]);


    }

    // Update is called once per frame
    void Update()
    {

    }
}