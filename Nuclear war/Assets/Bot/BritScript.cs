using System.Collections;
using UnityEngine;
using TMPro;

public class BritScript : MonoBehaviour
{
    public test MainSrcipt;
    public ButtonAttak attakButton;
    public BotScript botUsaScript;
    public ChinaScript botChinaScript;

    [SerializeField] public int moneyBrit, proBrit, rocketBrit, factoryBrit, growthProBrit = 1, growthRocketBrit = 1, growthFactoryBrit = 1;
    [SerializeField] private TMP_Text textRosketBrit, textProBrit, textFabricBrit;
    [SerializeField] private int RandNomder, counterShop = 0;
    private int remainderRocketBrit;
    public GameObject ImageBritAttack;


    private void Start()
    {
        StartCoroutine(RocketBrit());
        StartCoroutine(ProBrit());
        StartCoroutine(FactoryBrit());
        StartCoroutine(MoneyBrit());

        RandNomder = Random.Range(0, 3);
        moneyBrit = Random.Range(10000, 70000);
        factoryBrit = Random.Range(3, 7);
    }
    public void AttackBrit()
    {
        remainderRocketBrit = rocketBrit / MainSrcipt.nomderCounry;
        //атака на игрока
        MainSrcipt.Pro -= remainderRocketBrit;
        if (MainSrcipt.Pro < 0)
        {
            MainSrcipt.Factory += MainSrcipt.Pro / 5;
            MainSrcipt.Pro = 0;
        }
        //атака на сша
        botUsaScript.proUsa -= remainderRocketBrit;
        if (botUsaScript.proUsa < 0)
        {
            botUsaScript.factoryUsa += botUsaScript.proUsa / 5;
            botUsaScript.proUsa = 0;
        }
        //атака на китай
        botChinaScript.proChina -= remainderRocketBrit;
        if(botChinaScript.proChina < 0)
        {
            botChinaScript.factoryChina += botChinaScript.proChina / 5;
            botChinaScript.proChina = 0;
        }

        rocketBrit = 0;
        remainderRocketBrit = 0;
    }
    private IEnumerator RocketBrit()
    {
        yield return new WaitForSeconds(1);
        rocketBrit += growthRocketBrit;
        StartCoroutine(RocketBrit());
    }
    private IEnumerator ProBrit()
    {
        yield return new WaitForSeconds(1.5f);
        proBrit += growthProBrit;
        StartCoroutine(ProBrit());
    }
    private IEnumerator FactoryBrit()
    {
        yield return new WaitForSeconds(10);
        factoryBrit += growthFactoryBrit;
        StartCoroutine(FactoryBrit());
    }
    private IEnumerator MoneyBrit()
    {
        yield return new WaitForSeconds(2);
        moneyBrit += factoryBrit * 100;
        StartCoroutine(MoneyBrit());
    }
    private void Update()
    {
        if (RandNomder == 0)
        {
            if (counterShop == 0 && moneyBrit >= 10000)
            {
                moneyBrit -= 10000;
                growthRocketBrit++;
                counterShop++;
            }
            if (counterShop == 1 && moneyBrit >= 10000)
            {
                moneyBrit -= 10000;
                growthRocketBrit++;
                counterShop++;
            }
            if (counterShop == 2 && moneyBrit >= 10000)
            {
                moneyBrit -= 10000;
                growthRocketBrit++;
                counterShop++;
            }
            if (counterShop == 3 && moneyBrit >= 15000)
            {
                moneyBrit -= 15000;
                growthProBrit++;
                counterShop++;
            }
            if (counterShop == 4 && moneyBrit >= 20000)
            {
                moneyBrit -= 20000;
                growthFactoryBrit++;
                counterShop = 0;
            }
        }
        if (RandNomder == 1)
        {
            if (counterShop == 0 && moneyBrit >= 10000)
            {
                moneyBrit -= 10000;
                growthRocketBrit++;
                counterShop++;
            }
            if (counterShop == 1 && moneyBrit >= 15000)
            {
                moneyBrit -= 15000;
                growthProBrit++;
                counterShop++;
            }
            if (counterShop == 2 && moneyBrit >= 20000)
            {
                moneyBrit -= 20000;
                growthFactoryBrit++;
                counterShop++;
            }
            if (counterShop == 3 && moneyBrit >= 20000)
            {
                moneyBrit -= 20000;
                growthFactoryBrit++;
                counterShop++;
            }
            if (counterShop == 4 && moneyBrit >= 20000)
            {
                moneyBrit -= 20000;
                growthFactoryBrit++;
                counterShop = 0;
            }
        }
        if (RandNomder == 2)
        {
            if (counterShop == 0 && moneyBrit >= 10000)
            {
                moneyBrit -= 10000;
                growthRocketBrit++;
                counterShop++;
            }
            if (counterShop == 1 && moneyBrit >= 15000)
            {
                moneyBrit -= 15000;
                growthProBrit++;
                counterShop++;
            }
            if (counterShop == 2 && moneyBrit >= 15000)
            {
                moneyBrit -= 15000;
                growthProBrit++;
                counterShop++;
            }
            if (counterShop == 3 && moneyBrit >= 15000)
            {
                moneyBrit -= 15000;
                growthProBrit++;
                counterShop++;
            }
            if (counterShop == 4 && moneyBrit >= 20000)
            {
                moneyBrit -= 20000;
                growthFactoryBrit++;
                counterShop = 0;
            }
        }
        if (rocketBrit > MainSrcipt.Rocket && rocketBrit > botUsaScript.rocketUsa && rocketBrit >= 1000)
        {
            ImageBritAttack.SetActive(true);
            attakButton.AttacStart();
        }
        if (factoryBrit <= 0)
        {
            moneyBrit = 0;
            proBrit = 0;
            rocketBrit = 0;
            factoryBrit = 0;
            growthProBrit = 0;
            growthRocketBrit = 0;
            growthFactoryBrit = 0;
        }
        textRosketBrit.text = rocketBrit.ToString();
        textProBrit.text = proBrit.ToString();
        textFabricBrit.text = factoryBrit.ToString();
    }
}
