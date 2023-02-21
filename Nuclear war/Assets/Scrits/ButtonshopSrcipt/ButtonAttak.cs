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
        MainSrcipt.AttckPleer();
        BotUsaScript.AttackUsa();
        BotChinaScript.AttackChina();

        ButtonAttacStart.SetActive(true);
        Time.timeScale = 1;
    }
}