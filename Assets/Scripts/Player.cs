using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    // ������
    public GameObject MagicAura;
    public Transform T_MagicAura;
    // ��������
    public GameObject Explosion;

    // ������ ĵ����
    public GameObject DamageCanvas;
    TextMeshProUGUI TMPdamage;

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
                    Sound();
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

    void Sound()
    {
        if(Pdata.Job == "�˻�")
        {
            SoundManager.instance.PlayerAttackSound(8);
        }

        if (Pdata.Job == "�Ű�")
        {
            SoundManager.instance.PlayerAttackSound(4);
        }

        if (Pdata.Job == "������")
        {
            SoundManager.instance.PlayerAttackSound(2);
        }
    }

    public void SpecialAttack()
    {
        if(GameManager.ins.CurrTurn == false)
        {
            StartCoroutine("SpecialAttackCT");
        }
    }

    IEnumerator SpecialAttackCT()
    {
        int r = Random.Range(0, Monster.Length);

        Instantiate(MagicAura, T_MagicAura.position, T_MagicAura.rotation);
        yield return new WaitForSeconds(2.5f);
    
        if(Monster[r] != null)
        {
            if (!Pdata.Job.Equals("�Ű�"))
            {
                Instantiate(Explosion, Monster[r].transform.position + Vector3.up * 0.8f, Quaternion.identity);
            }
            else
            {
                // �Ű�
                GameObject[] Player = GameObject.FindGameObjectsWithTag("Player");
                int i = Random.Range(0, Player.Length);
                Instantiate(Explosion, Player[i].transform.position + Vector3.up * 0.8f, Quaternion.identity);
            }
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
        GameObject go = Instantiate(DamageCanvas, transform.position, Quaternion.identity);
        // ĵ������ ���͸� �θ�� �ϰڴ�.
        go.transform.SetParent(transform);

        TMPdamage = go.GetComponentInChildren<TextMeshProUGUI>();
        TMPdamage.text = "" + Attack;

        if (Pdata.Hp <= 0)
        {
            GameManager.ins.D_Player.Remove(Pdata.Job);
            Destroy(gameObject);
        }
    }
}
