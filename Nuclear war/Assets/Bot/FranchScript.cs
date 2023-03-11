using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FranchScript : MonoBehaviour
{
    public test MainSrcipt;
    public ButtonAttak attakButton;
    public ChinaScript chinaScript;
    public BritScript britScript;
    public BotScript usaScript;
    public AfricaScript africaScript;

    [SerializeField] public int moneyFranch, proFranch, rocketFranch, factoryFranch, growthProFranch = 1, growthRocketFranch = 1, growthFactoryFranch = 1;
    [SerializeField] private TMP_Text textRosketFranch, textProFranch, textFabricFranch;
    [SerializeField] private int RandNomder, counterShop = 0;
    private int remainderRocketFranch;
    public GameObject ImageFranchAttack;
    public Image ImageFone;

    private void Start()
    {
        StartCoroutine(RocketFranch());
        StartCoroutine(ProFranch());
        StartCoroutine(FactoryFranch());
        StartCoroutine(MoneyFranch());

        RandNomder = Random.Range(0, 3);
        moneyFranch = Random.Range(100, 700);
        factoryFranch = Random.Range(3, 7);
    }
    public void AttackFranch()
    {
        remainderRocketFranch = rocketFranch / MainSrcipt.nomderCounry;
        //атака на игрока
        MainSrcipt.Pro -= remainderRocketFranch;
        if (MainSrcipt.Pro < 0)
        {
            MainSrcipt.Factory += MainSrcipt.Pro / 5;
            MainSrcipt.Pro = 0;
        }
        //атака на сша
        usaScript.proUsa -= remainderRocketFranch;
        if (usaScript.proUsa < 0)
        {
            usaScript.factoryUsa += usaScript.proUsa / 5;
            usaScript.proUsa = 0;
        }
        //атака на китай
        chinaScript.proChina -= remainderRocketFranch;
        if (chinaScript.proChina < 0)
        {
            chinaScript.factoryChina += chinaScript.proChina / 5;
            chinaScript.proChina = 0;
        }
        //атака на англию
        britScript.proBrit -= remainderRocketFranch;
        if (britScript.proBrit < 0)
        {
            britScript.factoryBrit += britScript.proBrit / 5;
            britScript.proBrit = 0;
        }
        //атака на ЮАР
        africaScript.proAfrica-= remainderRocketFranch;
        if(africaScript.proAfrica < 0)
        {
            africaScript.factoryAfrica += africaScript.proAfrica / 5;
            africaScript.proAfrica = 0;
        }
        rocketFranch = 0;
        remainderRocketFranch = 0;
    }
    private IEnumerator RocketFranch()
    {
        yield return new WaitForSeconds(1);
        rocketFranch += growthRocketFranch;
        StartCoroutine(RocketFranch());
    }
    private IEnumerator ProFranch()
    {
        yield return new WaitForSeconds(1.5f);
        proFranch += growthProFranch;
        StartCoroutine(ProFranch());
    }
    private IEnumerator FactoryFranch()
    {
        yield return new WaitForSeconds(10);
        factoryFranch += growthFactoryFranch;
        StartCoroutine(FactoryFranch());
    }
    private IEnumerator MoneyFranch()
    {
        yield return new WaitForSeconds(2);
        moneyFranch += factoryFranch * 1;
        StartCoroutine(MoneyFranch());
    }
    private void Update()
    {
        if (RandNomder == 0)
        {
            if (counterShop == 0 && moneyFranch >= 100)
            {
                moneyFranch -= 100;
                growthRocketFranch++;
                counterShop++;
            }
            if (counterShop == 1 && moneyFranch >= 100)
            {
                moneyFranch -= 100;
                growthRocketFranch++;
                counterShop++;
            }
            if (counterShop == 2 && moneyFranch >= 100)
            {
                moneyFranch -= 100;
                growthRocketFranch++;
                counterShop++;
            }
            if (counterShop == 3 && moneyFranch >= 150)
            {
                moneyFranch -= 150;
                growthProFranch++;
                counterShop++;
            }
            if (counterShop == 4 && moneyFranch >= 200)
            {
                moneyFranch -= 200;
                growthFactoryFranch++;
                counterShop = 0;
            }
        }
        if (RandNomder == 1)
        {
            if (counterShop == 0 && moneyFranch >= 100)
            {
                moneyFranch -= 100;
                growthRocketFranch++;
                counterShop++;
            }
            if (counterShop == 1 && moneyFranch >= 150)
            {
                moneyFranch -= 150;
                growthProFranch++;
                counterShop++;
            }
            if (counterShop == 2 && moneyFranch >= 200)
            {
                moneyFranch -= 200;
                growthFactoryFranch++;
                counterShop++;
            }
            if (counterShop == 3 && moneyFranch >= 200)
            {
                moneyFranch -= 200;
                growthFactoryFranch++;
                counterShop++;
            }
            if (counterShop == 4 && moneyFranch >= 200)
            {
                moneyFranch -= 200;
                growthFactoryFranch++;
                counterShop = 0;
            }
        }
        if (RandNomder == 2)
        {
            if (counterShop == 0 && moneyFranch >= 100)
            {
                moneyFranch -= 100;
                growthRocketFranch++;
                counterShop++;
            }
            if (counterShop == 1 && moneyFranch >= 150)
            {
                moneyFranch -= 150;
                growthProFranch++;
                counterShop++;
            }
            if (counterShop == 2 && moneyFranch >= 150)
            {
                moneyFranch -= 150;
                growthProFranch++;
                counterShop++;
            }
            if (counterShop == 3 && moneyFranch >= 150)
            {
                moneyFranch -= 150;
                growthProFranch++;
                counterShop++;
            }
            if (counterShop == 4 && moneyFranch >= 200)
            {
                moneyFranch -= 200;
                growthFactoryFranch++;
                counterShop = 0;
            }
        }
        //атака 
        if (rocketFranch > MainSrcipt.Rocket && rocketFranch > usaScript.rocketUsa && rocketFranch > chinaScript.rocketChina && rocketFranch > britScript.rocketBrit && rocketFranch > africaScript.rocketAfrica && rocketFranch >= 1000)
        {
            ImageFranchAttack.SetActive(true);
            attakButton.AttacStart();
        }
        if (factoryFranch <= 0)
        {
            moneyFranch = 0;
            proFranch = 0;
            rocketFranch = 0;
            factoryFranch = 0;
            growthProFranch = 0;
            growthRocketFranch = 0;
            growthFactoryFranch = 0;
            ImageFone.color = new Color(0, 0, 0);
        }
        textRosketFranch.text = rocketFranch.ToString();
        textProFranch.text = proFranch.ToString();
        textFabricFranch.text = factoryFranch.ToString();
    }
}