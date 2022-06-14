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

    // ��üũ
    // True �� �÷��̾���, False �� ������
    public bool PlayTurn = true;
    // �ڷ�ƾ���� ����� ���� ����� ���Ϳ� ���� �� ����
    public bool MonsterTurn = true;
    // Ture �� ������, False �� �÷��̾���
    public bool CurrTurn = false;

    // �÷��̾� 3�� 
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;

    public GameObject Monster1;
    public GameObject Monster2;
    public GameObject Monster3;

    // ����â
    public GameObject[] Status;
    Text[] swordmanText;
    Text[] priestText;
    Text[] witchText;

    // ��ü ��
    public Slider Turn;
    public Text TurnText;
    public float TurnTime = 10;

    CoolTime ct;

    // ĵ���� GameOver
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
        // ��ųʸ� �ʿ��� �����͸� �־� �����Ѵ�.
        D_Player.Add("�˻�", Player1);
        D_Player.Add("�Ű�", Player2);
        D_Player.Add("������", Player3);

        L_Monster.Add(Monster1);
        L_Monster.Add(Monster2);
        L_Monster.Add(Monster3);

        // ����â
        Status = GameObject.FindGameObjectsWithTag("Status");

        swordmanText = Status[0].GetComponentsInChildren<Text>();
        priestText = Status[1].GetComponentsInChildren<Text>();
        witchText = Status[2].GetComponentsInChildren<Text>();

        // ĵ���� �ʱ�ȭ
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

        // ��ü��
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
                
                // ���� ����
                StartCoroutine("MonsterAttack");
            }
            PlayTurn = !PlayTurn;
            CurrTurn = PlayTurn;
        }

        // ����ǥ��â
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
                swordmanText[1].text = "����        " + P.Pdata.Level;
                swordmanText[2].text = "����ġ     " + P.Pdata.Exp;
                swordmanText[3].text = "HP          " + P.Pdata.Hp + "/" + P.Pdata.MaxHp;
                swordmanText[4].text = "MP         " + P.Pdata.Mp + "/" + P.Pdata.MaxMp;
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
                priestText[1].text = "����        " + P.Pdata.Level;
                priestText[2].text = "����ġ     " + P.Pdata.Exp;
                priestText[3].text = "HP          " + P.Pdata.Hp + "/" + P.Pdata.MaxHp;
                priestText[4].text = "MP         " + P.Pdata.Mp + "/" + P.Pdata.MaxMp;
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
                witchText[1].text = "����        " + P.Pdata.Level;
                witchText[2].text = "����ġ     " + P.Pdata.Exp;
                witchText[3].text = "HP          " + P.Pdata.Hp + "/" + P.Pdata.MaxHp;
                witchText[4].text = "MP         " + P.Pdata.Mp + "/" + P.Pdata.MaxMp;
            }
        }
    }
}
