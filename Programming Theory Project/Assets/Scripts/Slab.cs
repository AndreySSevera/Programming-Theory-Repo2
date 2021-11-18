using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Slab : Obstacles, GameSceneManager.IInformer
{
    private float timer;
    public GameObject infoCanvas;
    public Text nameT;
    public Text massT;

    private bool activCanvas = false;
    private void Start()
    {
        Mass = 1500f;
        ParticalName = "Slab Type 1";
        infoCanvas.SetActive(false);
    }
    public string Info()
    {
        return Convert.ToString(Mass);
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            timer = 0;
            GetInfo();
        }
    }
    private void OnMouseOver()
    {
        if (!activCanvas)
        {
            infoCanvas.SetActive(true);
            activCanvas = true;
            nameT.text = "Name : " + ParticalName;
            massT.text = "Mass : " + Mass + " KG";
        }
    }
    private void OnMouseExit()
    {
        activCanvas = false;
        infoCanvas.SetActive(false);
    }
}
