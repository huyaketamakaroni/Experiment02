using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCount : MonoBehaviour {

    private int starttime;
    private int now;
    private int duration;

    int hour = 0;
    int min = 0;
    int sec = 0;
    int msec = 0;


    void Start()
    {
        starttime = DateTime.Now.Hour * 60 * 60 * 1000 + DateTime.Now.Minute * 60 * 1000 +
        DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
    }

    void Update()
    {
        now = DateTime.Now.Hour * 60 * 60 * 1000 + DateTime.Now.Minute * 60 * 1000 +
        DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;

        duration = now - starttime;

        hour = duration / 60 /60 /1000;
        duration = duration - hour * 60 * 60 * 1000;

        min = duration / 60 / 1000;
        duration = duration - min * 60 * 1000;

        sec = duration / 1000;
        duration = duration - sec * 1000;

        msec = duration;


        
        if (Input.GetKeyDown("x"))
        {

            Debug.Log(hour + ":" + min + ":" + sec + ":" + msec);

           

        }

        if (Input.GetKeyDown("c"))
        {

            Debug.Log(duration);



        }

        if (Input.GetKeyDown("z"))
        {

            Debug.Log(DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Millisecond);



        }


    }
}
