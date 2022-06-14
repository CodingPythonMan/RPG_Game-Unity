using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public Dictionary<string, GameObject> D_Player = new Dictionary<string, GameObject>();
    public List<GameObject> L_Monster = new List<GameObject>();

    // 턴체크
    // True 는 플레이어턴, False 는 몬스터턴
    public bool PlayTurn = true;
    // 코루틴에서 사용할 일이 생기면 몬스터에 대한 턴 변수
    public bool MonsterTurn = true;
    // Ture 는 몬스터턴, False 는 플레이어턴
    public bool CurrTurn = false;

    // 플레이어 3개 
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;

    public GameObject Monster1;
    public GameObject Monster2;
    public GameObject Monster3;

    // 상태창
    public GameObject[] Status;
    Text[] swordmanText;
    Text[] priestText;
    Text[] witchText;

    // 전체 턴
    public Slider Turn;
    public Text TurnText;
    public float TurnTime = 10;

    CoolTime ct;

    // 캔버스 GameOver
    public GameObject GameOver;
    public GameObject GameWin;

    private void Awake()
    {
        ins = this;

        ct = new CoolTime();
    }

    // Start is called before the first frame update
    void Start()
    {
        // 딕셔너리 쪽에서 데이터를 넣어 관리한다.
        D_Player.Add("검사", Player1);
        D_Player.Add("신관", Player2);
        D_Player.Add("마법사", Player3);

        L_Monster.Add(Monster1);
        L_Monster.Add(Monster2);
        L_Monster.Add(Monster3);

        // 상태창
        Status = GameObject.FindGameObjectsWithTag("Status");

        swordmanText = Status[0].GetComponentsInChildren<Text>();
        priestText = Status[1].GetComponentsInChildren<Text>();
        witchText = Status[2].GetComponentsInChildren<Text>();

        // 캔버스 초기화
        GameOver.SetActive(false);
        GameWin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // 전체턴
        Turn.value = ct.Timer(TurnTime);
        
        if (Turn.value >= TurnTime)
        {
            if (PlayTurn)
            {
                TurnText.text = "Player Turn";
                MonsterTurn = false;
            }
            else
            {
                MonsterTurn = true;
                TurnText.text = "Monster Turn";
                
                // 몬스터 공격
                StartCoroutine("MonsterAttack");
            }
            PlayTurn = !PlayTurn;
            CurrTurn = PlayTurn;
        }

        // 상태표시창
        if(D_Player.Count > 0)
        {
            StatusShow();
        }

        if (D_Player.Count == 0)
        {
            GameOver.SetActive(true);
        }

        if (L_Monster.Count == 0)
        {
            GameWin.SetActive(true);
        }
    }

    public void Win()
    {
        SceneManager.LoadScene("Main");
    }

    public void Over()
    {
        SceneManager.LoadScene("Main");
    }

    IEnumerator MonsterAttack()
    {
        int i = 0;
        while (MonsterTurn)
        {
            if (L_Monster.Count != 0)
            {
                L_Monster[(i++)%L_Monster.Count].GetComponent<Monster>().NormalAttack();
            }

            yield return new WaitForSeconds(2f);
        }
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
                swordmanText[1].text = "레벨        " + P.Pdata.Level;
                swordmanText[2].text = "경험치     " + P.Pdata.Exp;
                swordmanText[3].text = "HP          " + P.Pdata.Hp + "/" + P.Pdata.MaxHp;
                swordmanText[4].text = "MP         " + P.Pdata.Mp + "/" + P.Pdata.MaxMp;
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
                priestText[1].text = "레벨        " + P.Pdata.Level;
                priestText[2].text = "경험치     " + P.Pdata.Exp;
                priestText[3].text = "HP          " + P.Pdata.Hp + "/" + P.Pdata.MaxHp;
                priestText[4].text = "MP         " + P.Pdata.Mp + "/" + P.Pdata.MaxMp;
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
                witchText[1].text = "레벨        " + P.Pdata.Level;
                witchText[2].text = "경험치     " + P.Pdata.Exp;
                witchText[3].text = "HP          " + P.Pdata.Hp + "/" + P.Pdata.MaxHp;
                witchText[4].text = "MP         " + P.Pdata.Mp + "/" + P.Pdata.MaxMp;
            }
        }
    }
}
