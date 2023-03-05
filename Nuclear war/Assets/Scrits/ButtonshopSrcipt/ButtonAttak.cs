using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonAttak : MonoBehaviour
{
    public test MainSrcipt;
    public BotScript BotUsaScript;
    public ChinaScript BotChinaScript;
    public BritScript BotBritScript;

    public GameObject ButtonAttacStart;

    public void AttacStart()
    {
        Time.timeScale = 0;
        ButtonAttacStart.SetActive(false);
        MainSrcipt.UsaInfo.SetActive(true);
        MainSrcipt.ChinaInfo.SetActive(true);
        MainSrcipt.BritInfo.SetActive(true);
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
        if(BotBritScript.factoryBrit > 0)
        {
            MainSrcipt.nomderCounry++;
        }
        BotUsaScript.AttackUsa();
        BotChinaScript.AttackChina();
        BotBritScript.AttackBrit();
        MainSrcipt.AttckPleer();      
        ButtonAttacStart.SetActive(true);      
        
        MainSrcipt.nomderCounry = 0;
        MainSrcipt.ImagePleerAttack.SetActive(false);
        BotUsaScript.ImageUsaAttack.SetActive(false);
        BotChinaScript.ImageChinaAttack.SetActive(false);
        BotBritScript.ImageBritAttack.SetActive(false);

        Time.timeScale = 1;

        StartCoroutine(InfoCountry());
    }
    private IEnumerator InfoCountry()
    {
        yield return new WaitForSeconds(3);
        MainSrcipt.UsaInfo.SetActive(false);
        MainSrcipt.ChinaInfo.SetActive(false);
        MainSrcipt.BritInfo.SetActive(false);
    }
}