using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AfricaScript : MonoBehaviour
{
    public test MainSrcipt;
    public ButtonAttak attakButton;
    public ChinaScript chinaScript;
    public BritScript britScript;
    public BotScript usaScript;
    public FranchScript franchScript;

    [SerializeField] public int moneyAfrica, proAfrica, rocketAfrica, factoryAfrica, growthProAfrica = 1, growthRocketAfrica = 1, growthFactoryAfrica = 1;
    [SerializeField] private TMP_Text textRosketAfrica, textProAfrica, textFabricAfrica;
    [SerializeField] private int RandNomder, counterShop = 0;
    private int remainderRocketAfrica;
    public GameObject ImageAfricaAttack;
    public Image ImageFone;

    private void Start()
    {
        StartCoroutine(RocketAfrica());
        StartCoroutine(ProAfrica());
        StartCoroutine(FactoryAfrica());
        StartCoroutine(MoneyAfrica());

        RandNomder = Random.Range(0, 3);
        moneyAfrica = Random.Range(100, 700);
        factoryAfrica = Random.Range(3, 7);
    }
    public void AttackAfrica()
    {
        remainderRocketAfrica = rocketAfrica / MainSrcipt.nomderCounry;
        //атака на игрока
        MainSrcipt.Pro -= remainderRocketAfrica;
        if (MainSrcipt.Pro < 0)
        {
            MainSrcipt.Factory += MainSrcipt.Pro / 5;
            MainSrcipt.Pro = 0;
        }
        //атака на сша
        usaScript.proUsa -= remainderRocketAfrica;
        if (usaScript.proUsa < 0)
        {
            usaScript.factoryUsa += usaScript.proUsa / 5;
            usaScript.proUsa = 0;
        }
        //атака на китай
        chinaScript.proChina -= remainderRocketAfrica;
        if (chinaScript.proChina < 0)
        {
            chinaScript.factoryChina += chinaScript.proChina / 5;
            chinaScript.proChina = 0;
        }
        //атака на англию
        britScript.proBrit -= remainderRocketAfrica;
        if (britScript.proBrit < 0)
        {
            britScript.factoryBrit += britScript.proBrit / 5;
            britScript.proBrit = 0;
        }
        //атака на францию
        franchScript.proFranch -= remainderRocketAfrica;
        if(franchScript.proFranch < 0)
        {
            franchScript.factoryFranch += franchScript.proFranch / 5;
            franchScript.proFranch = 0;
        }
        rocketAfrica = 0;
        remainderRocketAfrica = 0;
    }
    private IEnumerator RocketAfrica()
    {
        yield return new WaitForSeconds(1);
        rocketAfrica += growthRocketAfrica;
        StartCoroutine(RocketAfrica());
    }
    private IEnumerator ProAfrica()
    {
        yield return new WaitForSeconds(1.5f);
        proAfrica += growthProAfrica;
        StartCoroutine(ProAfrica());
    }
    private IEnumerator FactoryAfrica()
    {
        yield return new WaitForSeconds(10);
        factoryAfrica += growthFactoryAfrica;
        StartCoroutine(FactoryAfrica());
    }
    private IEnumerator MoneyAfrica()
    {
        yield return new WaitForSeconds(2);
        moneyAfrica += factoryAfrica * 1;
        StartCoroutine(MoneyAfrica());
    }
    private void Update()
    {
        if (RandNomder == 0)
        {
            if (counterShop == 0 && moneyAfrica >= 100)
            {
                moneyAfrica -= 100;
                growthRocketAfrica++;
                counterShop++;
            }
            if (counterShop == 1 && moneyAfrica >= 100)
            {
                moneyAfrica -= 100;
                growthRocketAfrica++;
                counterShop++;
            }
            if (counterShop == 2 && moneyAfrica >= 100)
            {
                moneyAfrica -= 100;
                growthRocketAfrica++;
                counterShop++;
            }
            if (counterShop == 3 && moneyAfrica >= 150)
            {
                moneyAfrica -= 150;
                growthProAfrica++;
                counterShop++;
            }
            if (counterShop == 4 && moneyAfrica >= 200)
            {
                moneyAfrica -= 200;
                growthFactoryAfrica++;
                counterShop = 0;
            }
        }
        if (RandNomder == 1)
        {
            if (counterShop == 0 && moneyAfrica >= 100)
            {
                moneyAfrica -= 100;
                growthRocketAfrica++;
                counterShop++;
            }
            if (counterShop == 1 && moneyAfrica >= 150)
            {
                moneyAfrica -= 150;
                growthProAfrica++;
                counterShop++;
            }
            if (counterShop == 2 && moneyAfrica >= 200)
            {
                moneyAfrica -= 200;
                growthFactoryAfrica++;
                counterShop++;
            }
            if (counterShop == 3 && moneyAfrica >= 200)
            {
                moneyAfrica -= 200;
                growthFactoryAfrica++;
                counterShop++;
            }
            if (counterShop == 4 && moneyAfrica >= 200)
            {
                moneyAfrica -= 200;
                growthFactoryAfrica++;
                counterShop = 0;
            }
        }
        if (RandNomder == 2)
        {
            if (counterShop == 0 && moneyAfrica >= 100)
            {
                moneyAfrica -= 100;
                growthRocketAfrica++;
                counterShop++;
            }
            if (counterShop == 1 && moneyAfrica >= 150)
            {
                moneyAfrica -= 150;
                growthProAfrica++;
                counterShop++;
            }
            if (counterShop == 2 && moneyAfrica >= 150)
            {
                moneyAfrica -= 150;
                growthProAfrica++;
                counterShop++;
            }
            if (counterShop == 3 && moneyAfrica >= 150)
            {
                moneyAfrica -= 150;
                growthProAfrica++;
                counterShop++;
            }
            if (counterShop == 4 && moneyAfrica >= 200)
            {
                moneyAfrica -= 200;
                growthFactoryAfrica++;
                counterShop = 0;
            }
        }
        //атака 
        if (rocketAfrica > MainSrcipt.Rocket && rocketAfrica > usaScript.rocketUsa && rocketAfrica > chinaScript.rocketChina && rocketAfrica > britScript.rocketBrit && rocketAfrica > franchScript.rocketFranch && rocketAfrica >= 1000)
        {
            ImageAfricaAttack.SetActive(true);
            attakButton.AttacStart();
        }
        if (factoryAfrica <= 0)
        {
            moneyAfrica = 0;
            proAfrica = 0;
            rocketAfrica = 0;
            factoryAfrica = 0;
            growthProAfrica = 0;
            growthRocketAfrica = 0;
            growthFactoryAfrica = 0;
            ImageFone.color = new Color(0, 0, 0);
        }
        textRosketAfrica.text = rocketAfrica.ToString();
        textProAfrica.text = proAfrica.ToString();
        textFabricAfrica.text = factoryAfrica.ToString();
    }
}
