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

        swordmanText = Status[0].GetComponentsInChildren<Text>();
        priestText = Status[1].GetComponentsInChildren<Text>();
        witchText = Status[2].GetComponentsInChildren<Text>();


    }

    // Update is called once per frame
    void Update()
    {
        // ����ǥ��â
        StatusShow();
    }

    // ���� ǥ�� �Լ�
    void StatusShow()
    {
        // Dictionary ���� �˻縦 ã�ƾ��Ѵ�.
        if (D_Player.ContainsKey("�˻�"))
        {
            // �ҵ�� ������Ʈ
            Player P = D_Player["�˻�"].GetComponent<Player>();
            if(P != null)
            {
                // �÷��̾� �� ������.
                swordmanText[0].text = P.Pdata.Job;
                swordmanText[1].text = "����            " + P.Pdata.Level;
                swordmanText[2].text = "����ġ          " + P.Pdata.Exp;
                swordmanText[3].text = "HP              " + P.Pdata.Hp + "/" + P.Pdata.MaxHp;
                swordmanText[4].text = "MP              " + P.Pdata.Mp + "/" + P.Pdata.MaxMp;
            }
        }

        // Dictionary ���� �˻縦 ã�ƾ��Ѵ�.
        if (D_Player.ContainsKey("�Ű�"))
        {
            // �ҵ�� ������Ʈ
            Player P = D_Player["�Ű�"].GetComponent<Player>();
            if (P != null)
            {
                // �÷��̾� �� ������.
                priestText[0].text = P.Pdata.Job;
                priestText[1].text = "����            " + P.Pdata.Level;
                priestText[2].text = "����ġ          " + P.Pdata.Exp;
                priestText[3].text = "HP              " + P.Pdata.Hp + "/" + P.Pdata.MaxHp;
                priestText[4].text = "MP              " + P.Pdata.Mp + "/" + P.Pdata.MaxMp;
            }
        }

        // Dictionary ���� �˻縦 ã�ƾ��Ѵ�.
        if (D_Player.ContainsKey("������"))
        {
            // �ҵ�� ������Ʈ
            Player P = D_Player["������"].GetComponent<Player>();
            if (P != null)
            {
                // �÷��̾� �� ������.
                witchText[0].text = P.Pdata.Job;
                witchText[1].text = "����            " + P.Pdata.Level;
                witchText[2].text = "����ġ          " + P.Pdata.Exp;
                witchText[3].text = "HP              " + P.Pdata.Hp + "/" + P.Pdata.MaxHp;
                witchText[4].text = "MP              " + P.Pdata.Mp + "/" + P.Pdata.MaxMp;
            }
        }
    }
}
