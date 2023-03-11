using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BritScript : MonoBehaviour
{
    public test MainSrcipt;
    public ButtonAttak attakButton;
    public BotScript botUsaScript;
    public ChinaScript botChinaScript;
    public FranchScript franchScript;
    public AfricaScript africaScript;

    [SerializeField] public int moneyBrit, proBrit, rocketBrit, factoryBrit, growthProBrit = 1, growthRocketBrit = 1, growthFactoryBrit = 1;
    [SerializeField] private TMP_Text textRosketBrit, textProBrit, textFabricBrit;
    [SerializeField] private int RandNomder, counterShop = 0;
    private int remainderRocketBrit;
    public GameObject ImageBritAttack;
    public Image ImageFone;


    private void Start()
    {
        StartCoroutine(RocketBrit());
        StartCoroutine(ProBrit());
        StartCoroutine(FactoryBrit());
        StartCoroutine(MoneyBrit());

        RandNomder = Random.Range(0, 3);
        moneyBrit = Random.Range(100, 700);
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
        //атака на францию
        franchScript.proFranch -= remainderRocketBrit;
        if (franchScript.proFranch < 0)
        {
            franchScript.factoryFranch += franchScript.proFranch / 5;
            franchScript.proFranch = 0;
        }
        //атака на ЮАР
        africaScript.proAfrica -= remainderRocketBrit;
        if (africaScript.proAfrica < 0)
        {
            africaScript.factoryAfrica += africaScript.proAfrica / 5;
            africaScript.proAfrica = 0;
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
        moneyBrit += factoryBrit * 1;
        StartCoroutine(MoneyBrit());
    }
    private void Update()
    {
        if (RandNomder == 0)
        {
            if (counterShop == 0 && moneyBrit >= 100)
            {
                moneyBrit -= 100;
                growthRocketBrit++;
                counterShop++;
            }
            if (counterShop == 1 && moneyBrit >= 100)
            {
                moneyBrit -= 100;
                growthRocketBrit++;
                counterShop++;
            }
            if (counterShop == 2 && moneyBrit >= 100)
            {
                moneyBrit -= 100;
                growthRocketBrit++;
                counterShop++;
            }
            if (counterShop == 3 && moneyBrit >= 150)
            {
                moneyBrit -= 150;
                growthProBrit++;
                counterShop++;
            }
            if (counterShop == 4 && moneyBrit >= 200)
            {
                moneyBrit -= 200;
                growthFactoryBrit++;
                counterShop = 0;
            }
        }
        if (RandNomder == 1)
        {
            if (counterShop == 0 && moneyBrit >= 100)
            {
                moneyBrit -= 100;
                growthRocketBrit++;
                counterShop++;
            }
            if (counterShop == 1 && moneyBrit >= 150)
            {
                moneyBrit -= 150;
                growthProBrit++;
                counterShop++;
            }
            if (counterShop == 2 && moneyBrit >= 200)
            {
                moneyBrit -= 200;
                growthFactoryBrit++;
                counterShop++;
            }
            if (counterShop == 3 && moneyBrit >= 200)
            {
                moneyBrit -= 200;
                growthFactoryBrit++;
                counterShop++;
            }
            if (counterShop == 4 && moneyBrit >= 200)
            {
                moneyBrit -= 200;
                growthFactoryBrit++;
                counterShop = 0;
            }
        }
        if (RandNomder == 2)
        {
            if (counterShop == 0 && moneyBrit >= 100)
            {
                moneyBrit -= 100;
                growthRocketBrit++;
                counterShop++;
            }
            if (counterShop == 1 && moneyBrit >= 150)
            {
                moneyBrit -= 150;
                growthProBrit++;
                counterShop++;
            }
            if (counterShop == 2 && moneyBrit >= 150)
            {
                moneyBrit -= 150;
                growthProBrit++;
                counterShop++;
            }
            if (counterShop == 3 && moneyBrit >= 150)
            {
                moneyBrit -= 150;
                growthProBrit++;
                counterShop++;
            }
            if (counterShop == 4 && moneyBrit >= 200)
            {
                moneyBrit -= 200;
                growthFactoryBrit++;
                counterShop = 0;
            }
        }
        //атака 
        if (rocketBrit > MainSrcipt.Rocket && rocketBrit > botUsaScript.rocketUsa && rocketBrit > botChinaScript.rocketChina && rocketBrit > franchScript.rocketFranch && rocketBrit > africaScript.rocketAfrica && rocketBrit >= 1000)
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
            ImageFone.color = new Color(0, 0, 0);
        }
        textRosketBrit.text = rocketBrit.ToString();
        textProBrit.text = proBrit.ToString();
        textFabricBrit.text = factoryBrit.ToString();
    }
}
