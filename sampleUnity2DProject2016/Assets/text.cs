﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class text : MonoBehaviour {

    public string[] scenarios; // シナリオを格納する
    public Text uiText; // uiTextへの参照を保つ

    int currentLine = 0; // 現在の行番号

    void Start()
    {
        TextUpdate();
    }

    void Update()
    {
        // 現在の行番号がラストまで行ってない状態でクリックすると、テキストを更新する
        if (currentLine < scenarios.Length && Input.GetMouseButtonDown(0))
        {
            TextUpdate();
        }
    }

    // テキストを更新する
    void TextUpdate()
    {
        // 現在の行のテキストをuiTextに流し込み、現在の行番号を一つ追加する
        uiText.text = scenarios[currentLine];
        currentLine++;
    }
}