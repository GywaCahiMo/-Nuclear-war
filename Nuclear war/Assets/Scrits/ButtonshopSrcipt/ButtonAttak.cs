using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAttak : MonoBehaviour
{
    public test MainSrcipt;
    public BotScript BotUsaScript;
    public ChinaScript BotChinaScript;

    public GameObject ButtonAttacStart;

    public void AttacStart()
    {
        Time.timeScale = 0;
        ButtonAttacStart.SetActive(false);
    }
    public void GeneralAttack()
    {
        if(BotUsaScript.factoryUsa > 0)
        {
            MainSrcipt.nomderCounry++;
        }
        if (BotChinaScript.factoryChina > 0)
        {
            MainSrcipt.nomderCounry++;
        }     
        BotUsaScript.AttackUsa();
        BotChinaScript.AttackChina();
        MainSrcipt.AttckPleer();      
        ButtonAttacStart.SetActive(true);      
        Time.timeScale = 1;
        MainSrcipt.nomderCounry = 0;
        MainSrcipt.ImagePleerAttack.SetActive(false);
        BotUsaScript.ImageUsaAttack.SetActive(false);
        BotChinaScript.ImageChinaAttack.SetActive(false);
    }
}