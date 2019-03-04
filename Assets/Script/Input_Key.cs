using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Key : MonoBehaviour {
    public AudioClip sound_in;
    public AudioClip sound_under;
    public AudioClip none;
    GameObject SoundSource_in;
    GameObject SoundSource_under;

    // Use this for initialization
    void Start () {
        SoundSource_in = GameObject.Find("InSound");
        SoundSource_under = GameObject.Find("UnderSound");
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource audioSource_in = SoundSource_in.gameObject.GetComponent<AudioSource>();
        AudioSource audioSource_out = SoundSource_under.gameObject.GetComponent<AudioSource>();

        if (Input.GetKeyDown("i"))
        {
            audioSource_in.clip = sound_in;
            Debug.Log("I-String");
            audioSource_in.Play();
        }


        if (Input.GetKeyDown("o"))
        {
            audioSource_out.clip = sound_under;
            Debug.Log("O-String");
            audioSource_out.Play();
        }


        if (Input.GetKeyDown("p"))
        {
            audioSource_in.clip = none;
            audioSource_in.Play();
            audioSource_out.clip = none;
            audioSource_out.Play();

            Debug.Log("P-String");
            
        }



    }


}
