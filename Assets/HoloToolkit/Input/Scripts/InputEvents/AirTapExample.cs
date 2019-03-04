using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class AirTapExample : MonoBehaviour, IInputClickHandler
{
    public Camera HololensCamara;

    void Start()
    {
        //AirTapを検出したとき、OnInputClickedが呼ばれる。
        InputManager.Instance.PushFallbackInputHandler(gameObject);
    }

    void Update()
    {

    }

    //AirTapを検出したとき呼ばれるメソッド
    void OnInputClicked(InputClickedEventData eventData)
    {
        //AirTap検出時の処理を記述
        GetComponent<AudioSource>().Play();
    }

    void IInputClickHandler.OnInputClicked(InputClickedEventData eventData)
    {
        throw new NotImplementedException();
    }
}
