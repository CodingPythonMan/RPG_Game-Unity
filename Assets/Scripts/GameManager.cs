using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public Dictionary<string, GameObject> D_Player = new Dictionary<string, GameObject>();

    // 플레이어 3개 
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;

    // 상태창
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
        // 딕셔너리 쪽에서 데이터를 넣어 관리한다.
        D_Player.Add("검사", Player1);
        D_Player.Add("신관", Player2);
        D_Player.Add("마법사", Player3);

        // 상태창
        Status = GameObject.FindGameObjectsWithTag("Status");

        swordmanText = Status[0].GetComponentsInChildren<Text>();
        priestText = Status[1].GetComponentsInChildren<Text>();
        witchText = Status[2].GetComponentsInChildren<Text>();


    }

    // Update is called once per frame
    void Update()
    {
        // 상태표시창
        StatusShow();
    }

    // 상태 표시 함수
    void StatusShow()
    {
        // Dictionary 에서 검사를 찾아야한다.
        if (D_Player.ContainsKey("검사"))
        {
            // 소드맨 오브젝트
            Player P = D_Player["검사"].GetComponent<Player>();
            if(P != null)
            {
                // 플레이어 잘 가져옴.
                swordmanText[0].text = P.Pdata.Job;
                swordmanText[1].text = "레벨            " + P.Pdata.Level;
                swordmanText[2].text = "경험치          " + P.Pdata.Exp;
                swordmanText[3].text = "HP              " + P.Pdata.Hp + "/" + P.Pdata.MaxHp;
                swordmanText[4].text = "MP              " + P.Pdata.Mp + "/" + P.Pdata.MaxMp;
            }
        }

        // Dictionary 에서 검사를 찾아야한다.
        if (D_Player.ContainsKey("신관"))
        {
            // 소드맨 오브젝트
            Player P = D_Player["신관"].GetComponent<Player>();
            if (P != null)
            {
                // 플레이어 잘 가져옴.
                priestText[0].text = P.Pdata.Job;
                priestText[1].text = "레벨            " + P.Pdata.Level;
                priestText[2].text = "경험치          " + P.Pdata.Exp;
                priestText[3].text = "HP              " + P.Pdata.Hp + "/" + P.Pdata.MaxHp;
                priestText[4].text = "MP              " + P.Pdata.Mp + "/" + P.Pdata.MaxMp;
            }
        }

        // Dictionary 에서 검사를 찾아야한다.
        if (D_Player.ContainsKey("마법사"))
        {
            // 소드맨 오브젝트
            Player P = D_Player["마법사"].GetComponent<Player>();
            if (P != null)
            {
                // 플레이어 잘 가져옴.
                witchText[0].text = P.Pdata.Job;
                witchText[1].text = "레벨            " + P.Pdata.Level;
                witchText[2].text = "경험치          " + P.Pdata.Exp;
                witchText[3].text = "HP              " + P.Pdata.Hp + "/" + P.Pdata.MaxHp;
                witchText[4].text = "MP              " + P.Pdata.Mp + "/" + P.Pdata.MaxMp;
            }
        }
    }
}
