using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // �÷��̾� �����͸� ���� �� �ִ� ����
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
            // �÷��̾� ����
            StartCoroutine("NormalAttackCT");
        }
    }

    IEnumerator NormalAttackCT()
    {
        Back = false; // �÷��̾ �����ϰ� ���ƿԴ��� üũ�ϴ� ����
        int r = Random.Range(0, Monster.Length); // ���͸� �����ϰ� Ÿ����

        while (true)
        {
            if(Monster[r] != null)
            {
                rig.MovePosition(Vector3.Lerp(transform.position, Monster[r].transform.position, 20*Time.deltaTime));
                if (Vector3.Distance(transform.position, Monster[r].transform.position) <= 0.5f)
                {
                    // ���ݸ��
                    ani.SetTrigger("attack");
                    // ���ݻ���
                    // ���� ���ݵ�����
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
        // ������ �ؽ�Ʈ 

        if(Pdata.Hp <= 0)
        {
            GameManager.ins.D_Player.Remove(Pdata.Job);
            Destroy(gameObject);
        }
    }
}
