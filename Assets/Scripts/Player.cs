using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 플레이어 데이터를 가질 수 있는 변수
    public PlayerData Pdata;
    GameObject[] Monster;
    Rigidbody2D rig;

    public bool Back = false;
    public Vector3 OriPos;
    Animator ani;


    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
