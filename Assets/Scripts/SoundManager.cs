using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 자동으로 AudioSource 부착
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    AudioSource myAudio;

    public AudioClip[] AttackSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
