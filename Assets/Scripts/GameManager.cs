using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public Dictionary<string, GameObject> D_Player = new Dictionary<string, GameObject>();

    // �÷��̾� 3�� 
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;

    // ����â
    public GameObject[] Status;
    Text[] swordmanText;
    Text[] priestText;
    Text[] witchText;

    private void Awake()
    {
        ins = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // ��ųʸ� �ʿ��� �����͸� �־� �����Ѵ�.
        D_Player.Add("�˻�", Player1);
        D_Player.Add("�Ű�", Player2);
        D_Player.Add("������", Player3);

        // ����â
        Status = GameObject.FindGameObjectsWithTag("Status");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
