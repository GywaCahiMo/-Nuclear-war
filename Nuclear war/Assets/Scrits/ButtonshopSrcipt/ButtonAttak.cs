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
    public FranchScript FranchScript;
    public AfricaScript AfricaScript;

    public GameObject ButtonAttacStart;

    public void AttacStart()
    {
        Time.timeScale = 0;
        ButtonAttacStart.SetActive(false);
        MainSrcipt.UsaInfo.SetActive(true);
        MainSrcipt.ChinaInfo.SetActive(true);
        MainSrcipt.BritInfo.SetActive(true);
        MainSrcipt.FranchInfo.SetActive(true);
        MainSrcipt.AfricaInfo.SetActive(true);
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
        if (FranchScript.factoryFranch > 0)
        {
            MainSrcipt.nomderCounry++;
        }
        if (AfricaScript.factoryAfrica > 0)
        {
            MainSrcipt.nomderCounry++;
        }
        BotUsaScript.AttackUsa();
        BotChinaScript.AttackChina();
        BotBritScript.AttackBrit();
        FranchScript.AttackFranch();
        AfricaScript.AttackAfrica();
        MainSrcipt.AttckPleer();      
        ButtonAttacStart.SetActive(true);      
        
        MainSrcipt.nomderCounry = 0;
        MainSrcipt.ImagePleerAttack.SetActive(false);
        BotUsaScript.ImageUsaAttack.SetActive(false);
        BotChinaScript.ImageChinaAttack.SetActive(false);
        BotBritScript.ImageBritAttack.SetActive(false);
        FranchScript.ImageFranchAttack.SetActive(false);
        AfricaScript.ImageAfricaAttack.SetActive(false);

        Time.timeScale = 1;

        StartCoroutine(InfoCountry());
    }
    private IEnumerator InfoCountry()
    {
        yield return new WaitForSeconds(3);
        MainSrcipt.UsaInfo.SetActive(false);
        MainSrcipt.ChinaInfo.SetActive(false);
        MainSrcipt.BritInfo.SetActive(false);
        MainSrcipt.FranchInfo.SetActive(false);
        MainSrcipt.AfricaInfo.SetActive(false);
    }
}