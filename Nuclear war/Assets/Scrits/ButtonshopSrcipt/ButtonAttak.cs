using System;
using UnityEngine;
using UnityEngine.UI;


public class ButtonAttak : MonoBehaviour
{
    public test MainSrcipt;
    public BotScript BotScript;

    private Slider Sliders;
    public GameObject ButtonAttacStart;

    private int remainderRocket, remainderRocketBot;
    private void Start()
    {
        Sliders = GameObject.Find("Slider").GetComponent<Slider>();       
    }
    public void AttacStart()
    {
        Time.timeScale = 0;
        ButtonAttacStart.SetActive(false);
    }
    public void AttacPreer()
    {   
        //игрок
        MainSrcipt.Rocket -= Convert.ToInt32(Sliders.value);
        remainderRocket = Convert.ToInt32(Sliders.value) - (BotScript.proBot * 2);
        BotScript.proBot -= Convert.ToInt32(Sliders.value) / 2;
        BotScript.factoryBot -= remainderRocket / 10;
        if(BotScript.proBot < 0)
        {
            BotScript.proBot = 0;
        }
        if (BotScript.factoryBot <= 0)
        {
            BotScript.BotDead = true;
        }
        //бот   
        remainderRocketBot = BotScript.rocketBot - (MainSrcipt.Pro * 2);
        MainSrcipt.Pro -= BotScript.rocketBot / 2;
        MainSrcipt.Factory -= remainderRocketBot / 10;
        BotScript.rocketBot = 0;
        if(MainSrcipt.Pro < 0)
        {
            MainSrcipt.Pro = 0;
        }
        if (MainSrcipt.Factory < 0)
        {
            MainSrcipt.DeadPrear = true;
        }

        ButtonAttacStart.SetActive(true);
        Time.timeScale = 1;
    }
    private void Update()
    {
        Sliders.maxValue = MainSrcipt.Rocket;      
    }
}