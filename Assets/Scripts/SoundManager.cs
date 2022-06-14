using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �ڵ����� AudioSource ����
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    AudioSource myAudio;

    public AudioClip[] AttackSound;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void PlayerAttackSound(int num)
    {
        myAudio.PlayOneShot(AttackSound[num]);
    }
}