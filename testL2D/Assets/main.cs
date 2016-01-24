﻿using UnityEngine;
using System;
using System.Collections;
using live2d;

public class main : MonoBehaviour
{
    public TextAsset mocFile;
    public Texture2D[] textures;

    private Live2DModelUnity live2DModel;


    // Use this for initialization
    void Start()
    {

        Live2D.init();

        live2DModel = Live2DModelUnity.loadModel(mocFile.bytes);

        for (int i = 0; i < textures.Length; i++)
        {
            live2DModel.setTexture(i, textures[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnRenderObject()
    {
        float modelWidth = live2DModel.getCanvasWidth();
        Matrix4x4 m1 = Matrix4x4.Ortho(
                0,
                modelWidth,
                modelWidth,
                0,
                -50.0f, 50.0f);
        Matrix4x4 m2 = transform.localToWorldMatrix;
        Matrix4x4 m3 = m2 * m1;

        live2DModel.setMatrix(m3);
        live2DModel.update();
        live2DModel.draw();
    }
}