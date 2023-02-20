using System;
using UnityEngine;
using UnityEngine.UI;


public class ButtonAttak : MonoBehaviour
{
    public test MainSrcipt;
    public BotScript BotScript;

    private Slider Sliders;
    public GameObject ButtonAttacStart;
    private void Start()
    {
        Sliders = GameObject.Find("Slider").GetComponent<Slider>();       
    }
    public void AttacStart()
    {
        Time.timeScale = 0;
        ButtonAttacStart.SetActive(false);
    }
    public void Attac()
    {
        MainSrcipt.Rocket -= Convert.ToInt32(Sliders.value);
        BotScript.proBot -= Convert.ToInt32(Sliders.value) / 2;
        BotScript.factoryBot -= Convert.ToInt32(Sliders.value) / 10;
        if (BotScript.factoryBot <= 0)
        {
            BotScript.BotDead = true;
        }
        if(BotScript.proBot <= 0)
        {
            BotScript.proBot = -1;
        }
        ButtonAttacStart.SetActive(true);
        Time.timeScale = 1;
    }
    private void Update()
    {
        Sliders.maxValue = MainSrcipt.Rocket;      
    }
}