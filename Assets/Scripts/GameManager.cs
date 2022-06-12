using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ins;
    public Dictionary<string, GameObject> D_Player = new Dictionary<string, GameObject>();

    // 플레이어 3개 
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;

    private void Awake()
    {
        ins = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
