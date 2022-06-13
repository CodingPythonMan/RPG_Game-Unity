using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolTime
{
    public float Cooltime;
    float CoolCnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        CoolCnt = 0;
    }

    public float Timer(float t)
    {
        if(CoolCnt + t <= Time.time)
        {
            CoolCnt = Time.time;
            Cooltime = 0;
        }
        Cooltime += Time.deltaTime;
        return Cooltime;
    }
}
