using System.Collections;
using UnityEngine;
using TMPro;

public class BotScript : MonoBehaviour
{
    public test MainSrcipt;
    public ButtonAttak attakButton;
    public ChinaScript chinaScript;
    public BritScript britScript;

    [SerializeField] public int moneyUsa, proUsa, rocketUsa, factoryUsa, growthProUsa = 1, growthRocketUsa = 1, growthFactoryUsa = 1;
    [SerializeField] private TMP_Text textRosketUsa, textProUsa, textFabricUsa;
    [SerializeField] private int RandNomder, counterShop = 0;
    private int remainderRocketUsa;
    public GameObject ImageUsaAttack;

    private void Start()
    {
        StartCoroutine(RocketUsa());
        StartCoroutine(ProUsa());
        StartCoroutine(FactoryUsa());
        StartCoroutine(MoneyUsa());

        RandNomder = Random.Range(0, 3);
        moneyUsa = Random.Range(10000, 70000);
        factoryUsa = Random.Range(3, 7);
    }
    public void AttackUsa()
    {
        remainderRocketUsa = rocketUsa / MainSrcipt.nomderCounry;
        //атака на игрока
        MainSrcipt.Pro -= remainderRocketUsa;
        if(MainSrcipt.Pro < 0)
        {
            MainSrcipt.Factory += MainSrcipt.Pro / 5;
            MainSrcipt.Pro = 0;
        }
        //атака на китай
        chinaScript.proChina -= remainderRocketUsa;
        if(chinaScript.proChina < 0)
        {
            chinaScript.factoryChina += chinaScript.proChina / 5;
            chinaScript.proChina = 0;
        }
        //атака на англию
        britScript.proBrit -= remainderRocketUsa;
        if(britScript.proBrit< 0)
        {
            britScript.factoryBrit += britScript.proBrit / 5;
            britScript.proBrit = 0;
        }
        rocketUsa = 0;
        remainderRocketUsa = 0;
    }
    private IEnumerator RocketUsa()
    {
        yield return new WaitForSeconds(1);
        rocketUsa += growthRocketUsa;      
        StartCoroutine(RocketUsa());
    }
    private IEnumerator ProUsa()
    {
        yield return new WaitForSeconds(1.5f);
        proUsa += growthProUsa; 
        StartCoroutine(ProUsa());
    }
    private IEnumerator FactoryUsa()
    {
        yield return new WaitForSeconds(10);
        factoryUsa += growthFactoryUsa;    
        StartCoroutine(FactoryUsa());
    }
    private IEnumerator MoneyUsa()
    {
        yield return new WaitForSeconds(2);
        moneyUsa += factoryUsa * 100;
        StartCoroutine(MoneyUsa());
    }
    private void Update()
    {
        if (RandNomder == 0)
        {
            if (counterShop == 0 && moneyUsa >= 10000)
            {
                moneyUsa -= 10000;
                growthRocketUsa++;
                counterShop++;
            }
            if (counterShop == 1 && moneyUsa >= 10000)
            {
                moneyUsa -= 10000;
                growthRocketUsa++;
                counterShop++;
            }
            if (counterShop == 2 && moneyUsa >= 10000)
            {
                moneyUsa -= 10000;
                growthRocketUsa++;
                counterShop++;
            }
            if (counterShop == 3 && moneyUsa >= 15000)
            {
                moneyUsa -= 15000;
                growthProUsa++;
                counterShop++;
            }
            if (counterShop == 4 && moneyUsa >= 20000)
            {
                moneyUsa -= 20000;
                growthFactoryUsa++;
                counterShop = 0;
            }
        }
        if (RandNomder == 1)
        {
            if (counterShop == 0 && moneyUsa >= 10000)
            {
                moneyUsa -= 10000;
                growthRocketUsa++;
                counterShop++;
            }
            if (counterShop == 1 && moneyUsa >= 15000)
            {
                moneyUsa -= 15000;
                growthProUsa++;
                counterShop++;
            }
            if (counterShop == 2 && moneyUsa >= 20000)
            {
                moneyUsa -= 20000;
                growthFactoryUsa++;
                counterShop++;
            }
            if (counterShop == 3 && moneyUsa >= 20000)
            {
                moneyUsa -= 20000;
                growthFactoryUsa++;
                counterShop++;
            }
            if (counterShop == 4 && moneyUsa >= 20000)
            {
                moneyUsa -= 20000;
                growthFactoryUsa++;
                counterShop = 0;
            }
        }
        if (RandNomder == 2)
        {
            if (counterShop == 0 && moneyUsa >= 10000)
            {
                moneyUsa -= 10000;
                growthRocketUsa++;
                counterShop++;
            }
            if (counterShop == 1 && moneyUsa >= 15000)
            {
                moneyUsa -= 15000;
                growthProUsa++;
                counterShop++;
            }
            if (counterShop == 2 && moneyUsa >= 15000)
            {
                moneyUsa -= 15000;
                growthProUsa++;
                counterShop++;
            }
            if (counterShop == 3 && moneyUsa >= 15000)
            {
                moneyUsa -= 15000;
                growthProUsa++;
                counterShop++;
            }
            if (counterShop == 4 && moneyUsa >= 20000)
            {
                moneyUsa -= 20000;
                growthFactoryUsa++;
                counterShop = 0;
            }
        }
        if(rocketUsa > MainSrcipt.Rocket && rocketUsa > chinaScript.rocketChina && rocketUsa >= 1000)
        {   
            ImageUsaAttack.SetActive(true);
            attakButton.AttacStart();          
        }
        if(factoryUsa <= 0)
        {
            moneyUsa = 0;
            proUsa = 0;
            rocketUsa = 0;
            factoryUsa = 0;
            growthProUsa = 0;
            growthRocketUsa = 0;
            growthFactoryUsa = 0;
        }
        textRosketUsa.text = rocketUsa.ToString();
        textProUsa.text = proUsa.ToString();
        textFabricUsa.text = factoryUsa.ToString();
    }           
}
