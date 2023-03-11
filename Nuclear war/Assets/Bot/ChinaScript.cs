using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChinaScript : MonoBehaviour
{
    public test MainSrcipt;
    public ButtonAttak attakButton;
    public BotScript botUsaScript;
    public BritScript britScript;
    public FranchScript franchScript;
    public AfricaScript africaScript;

    [SerializeField] public int moneyChina, proChina, rocketChina, factoryChina, growthProChina = 1, growthRocketChina = 1, growthFactoryChina = 1;
    [SerializeField] private TMP_Text textRosketChina, textProChina, textFabricChina;
    [SerializeField] private int RandNomder, counterShop = 0;
    private int remainderRocketChina;
    public GameObject ImageChinaAttack;
    public Image ImageFone;


    private void Start()
    {
        StartCoroutine(RocketChina());
        StartCoroutine(ProChina());
        StartCoroutine(FactoryChina());
        StartCoroutine(MoneyChina());

        RandNomder = Random.Range(0, 3);
        moneyChina= Random.Range(100, 700);
        factoryChina= Random.Range(3, 7);
    }
    public void AttackChina()
    {
        remainderRocketChina = rocketChina / MainSrcipt.nomderCounry;
        //атака на игрока
        MainSrcipt.Pro -= remainderRocketChina;
        if (MainSrcipt.Pro < 0)
        {
            MainSrcipt.Factory += MainSrcipt.Pro / 5;
            MainSrcipt.Pro = 0;
        }
        //атака на сша
        botUsaScript.proUsa -= remainderRocketChina;
        if (botUsaScript.proUsa < 0)
        {
            botUsaScript.factoryUsa += botUsaScript.proUsa / 5;
            botUsaScript.proUsa = 0;
        }
        //атака на англию
        britScript.proBrit -= remainderRocketChina;
        if (britScript.proBrit < 0)
        {
            britScript.factoryBrit += britScript.proBrit / 5;
            britScript.proBrit = 0;
        }
        //атака на францию
        franchScript.proFranch -= remainderRocketChina;
        if (franchScript.proFranch < 0)
        {
            franchScript.factoryFranch += franchScript.proFranch / 5;
            franchScript.proFranch = 0;
        }
        //атака на ЮАР
        africaScript.proAfrica -= remainderRocketChina;
        if (africaScript.proAfrica < 0)
        {
            africaScript.factoryAfrica += africaScript.proAfrica / 5;
            africaScript.proAfrica = 0;
        }
        rocketChina = 0;
        remainderRocketChina = 0;
    }
    private IEnumerator RocketChina()
    {
        yield return new WaitForSeconds(1);
        rocketChina += growthRocketChina;   
        StartCoroutine(RocketChina());
    }
    private IEnumerator ProChina()
    {
        yield return new WaitForSeconds(1.5f);
        proChina += growthProChina;    
        StartCoroutine(ProChina());
    }
    private IEnumerator FactoryChina()
    {
        yield return new WaitForSeconds(10);
        factoryChina += growthFactoryChina;       
        StartCoroutine(FactoryChina());
    }
    private IEnumerator MoneyChina()
    {
        yield return new WaitForSeconds(2);
        moneyChina += factoryChina * 1;
        StartCoroutine(MoneyChina());
    }
    private void Update()
    {
        if (RandNomder == 0)
        {
            if (counterShop == 0 && moneyChina >= 100)
            {
                moneyChina -= 100;
                growthRocketChina++;
                counterShop++;
            }
            if (counterShop == 1 && moneyChina >= 100)
            {
                moneyChina -= 100;
                growthRocketChina++;
                counterShop++;
            }
            if (counterShop == 2 && moneyChina >= 100)
            {
                moneyChina -= 100;
                growthRocketChina++;
                counterShop++;
            }
            if (counterShop == 3 && moneyChina >= 150)
            {
                moneyChina -= 150;
                growthProChina++;
                counterShop++;
            }
            if (counterShop == 4 && moneyChina >= 200)
            {
                moneyChina -= 200;
                growthFactoryChina++;
                counterShop = 0;
            }
        }
        if (RandNomder == 1)
        {
            if (counterShop == 0 && moneyChina >= 100)
            {
                moneyChina -= 100;
                growthRocketChina++;
                counterShop++;
            }
            if (counterShop == 1 && moneyChina >= 150)
            {
                moneyChina -= 150;
                growthProChina++;
                counterShop++;
            }
            if (counterShop == 2 && moneyChina >= 200)
            {
                moneyChina -= 200;
                growthFactoryChina++;
                counterShop++;
            }
            if (counterShop == 3 && moneyChina >= 200)
            {
                moneyChina -= 200;
                growthFactoryChina++;
                counterShop++;
            }
            if (counterShop == 4 && moneyChina >= 200)
            {
                moneyChina -= 200;
                growthFactoryChina++;
                counterShop = 0;
            }
        }
        if (RandNomder == 2)
        {
            if (counterShop == 0 && moneyChina >= 100)
            {
                moneyChina -= 100;
                growthRocketChina++;
                counterShop++;
            }
            if (counterShop == 1 && moneyChina >= 150)
            {
                moneyChina -= 150;
                growthProChina++;
                counterShop++;
            }
            if (counterShop == 2 && moneyChina >= 150)
            {
                moneyChina -= 150;
                growthProChina++;
                counterShop++;
            }
            if (counterShop == 3 && moneyChina >= 150)
            {
                moneyChina -= 150;
                growthProChina++;
                counterShop++;
            }
            if (counterShop == 4 && moneyChina >= 200)
            {
                moneyChina -= 200;
                growthFactoryChina++;
                counterShop = 0;
            }
        }
        //атака 
        if (rocketChina > MainSrcipt.Rocket && rocketChina > botUsaScript.rocketUsa && rocketChina > britScript.rocketBrit && rocketChina > franchScript.rocketFranch && rocketChina > africaScript.rocketAfrica && rocketChina >= 1000)
        {   
            ImageChinaAttack.SetActive(true);
            attakButton.AttacStart();          
        }
        if (factoryChina <= 0)
        {
            moneyChina = 0;
            proChina = 0;
            rocketChina = 0;
            factoryChina = 0;
            growthProChina = 0;
            growthRocketChina = 0;
            growthFactoryChina = 0;
            ImageFone.color = new Color(0, 0, 0);
        }
        textRosketChina.text = rocketChina.ToString();
        textProChina.text = proChina.ToString();
        textFabricChina.text = factoryChina.ToString();
    }
}