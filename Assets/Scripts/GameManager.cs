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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
