using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public MonsterData Mdata;
    GameObject[] Player;
    Rigidbody2D rig;

    public bool Back = false;
    public Vector3 OriPos;

    Animator ani;

    public int Hp;
    public int MaxHp;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        rig = GetComponent<Rigidbody2D>();
        OriPos = transform.position;
        ani = GetComponent<Animator>();

        Hp = Mdata.Hp;
        MaxHp = Mdata.MaxHp;
    }

    public void NormalAttack()
    {
        StartCoroutine("NormalAttackCT");
    }

    IEnumerator NormalAttackCT()
    {
        Back = false;
        int r = Random.Range(0, Player.Length);
        while (true)
        {
            if(Player[r] != null)
            {
                rig.MovePosition(Vector3.Lerp(transform.position, Player[r].transform.position, 20*Time.deltaTime));
                if(Vector3.Distance(transform.position, Player[r].transform.position) <= 0.5f)
                {
                    ani.SetTrigger("attack");
                    Player[r].GetComponent<Player>().Damage(Mdata.Attack);

                    yield return new WaitForSeconds(0.03f);
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
            rig.MovePosition(Vector3.Lerp(transform.position, OriPos, 20 * Time.deltaTime));
        }
    }

    public void Damage(int Attack)
    {
        Hp -= Attack;
        ani.SetTrigger("damage");
        // 데미지 텍스트

        if(Hp <= 0)
        {
            GameManager.ins.L_Monster.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
