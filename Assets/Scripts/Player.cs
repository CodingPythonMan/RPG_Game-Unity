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
        Monster = GameObject.FindGameObjectsWithTag("Monster");
        rig = GetComponent<Rigidbody2D>();
        OriPos = transform.position;
        ani = GetComponent<Animator>();
    }

    public void NormalAttack()
    {
        if (GameManager.ins.CurrTurn == false)
        {
            // 플레이어 공격
            StartCoroutine("NormalAttackCT");
        }
    }

    IEnumerator NormalAttackCT()
    {
        Back = false; // 플레이어가 공격하고 돌아왔는지 체크하는 변수
        int r = Random.Range(0, Monster.Length); // 몬스터를 랜덤하게 타겟팅

        while (true)
        {
            if(Monster[r] != null)
            {
                rig.MovePosition(Vector3.Lerp(transform.position, Monster[r].transform.position, 20*Time.deltaTime));
                if (Vector3.Distance(transform.position, Monster[r].transform.position) <= 0.5f)
                {
                    // 공격모션
                    ani.SetTrigger("attack");
                    // 공격사운드
                    // 몬스터 공격데미지
                    Monster[r].GetComponent<Monster>().Damage(Pdata.Attack);

                    yield return new WaitForSeconds(0.3f);
                    Back = true;

                    break;
                }
            }

            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Back == true)
        {
            rig.MovePosition(Vector3.Lerp(transform.position, OriPos, 20*Time.deltaTime));
        }
    }

    public void Damage(int Attack)
    {
        Pdata.Hp -= Attack;
        ani.SetTrigger("damage");
        // 데미지 텍스트 

        if(Pdata.Hp <= 0)
        {
            GameManager.ins.D_Player.Remove(Pdata.Job);
            Destroy(gameObject);
        }
    }
}
