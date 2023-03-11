using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BotScript : MonoBehaviour
{
    public test MainSrcipt;
    public ButtonAttak attakButton;
    public ChinaScript chinaScript;
    public BritScript britScript;
    public FranchScript franchScript;
    public AfricaScript africaScript;

    [SerializeField] public int moneyUsa, proUsa, rocketUsa, factoryUsa, growthProUsa = 1, growthRocketUsa = 1, growthFactoryUsa = 1;
    [SerializeField] private TMP_Text textRosketUsa, textProUsa, textFabricUsa;
    [SerializeField] private int RandNomder, counterShop = 0;
    private int remainderRocketUsa;
    public GameObject ImageUsaAttack;
    public Image ImageFone;

    private void Start()
    {
        StartCoroutine(RocketUsa());
        StartCoroutine(ProUsa());
        StartCoroutine(FactoryUsa());
        StartCoroutine(MoneyUsa());

        RandNomder = Random.Range(0, 3);
        moneyUsa = Random.Range(100, 700);
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
        //атака на францию
        franchScript.proFranch -= remainderRocketUsa;
        if (franchScript.proFranch < 0)
        {
            franchScript.factoryFranch += franchScript.proFranch / 5;
            franchScript.proFranch = 0;
        }
        //атака на ЮАР
        africaScript.proAfrica -= remainderRocketUsa;
        if (africaScript.proAfrica < 0)
        {
            africaScript.factoryAfrica += africaScript.proAfrica / 5;
            africaScript.proAfrica = 0;
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
        moneyUsa += factoryUsa * 1;
        StartCoroutine(MoneyUsa());
    }
    private void Update()
    {
        if (RandNomder == 0)
        {
            if (counterShop == 0 && moneyUsa >= 100)
            {
                moneyUsa -= 100;
                growthRocketUsa++;
                counterShop++;
            }
            if (counterShop == 1 && moneyUsa >= 100)
            {
                moneyUsa -= 100;
                growthRocketUsa++;
                counterShop++;
            }
            if (counterShop == 2 && moneyUsa >= 100)
            {
                moneyUsa -= 100;
                growthRocketUsa++;
                counterShop++;
            }
            if (counterShop == 3 && moneyUsa >= 150)
            {
                moneyUsa -= 150;
                growthProUsa++;
                counterShop++;
            }
            if (counterShop == 4 && moneyUsa >= 200)
            {
                moneyUsa -= 200;
                growthFactoryUsa++;
                counterShop = 0;
            }
        }
        if (RandNomder == 1)
        {
            if (counterShop == 0 && moneyUsa >= 100)
            {
                moneyUsa -= 100;
                growthRocketUsa++;
                counterShop++;
            }
            if (counterShop == 1 && moneyUsa >= 150)
            {
                moneyUsa -= 150;
                growthProUsa++;
                counterShop++;
            }
            if (counterShop == 2 && moneyUsa >= 200)
            {
                moneyUsa -= 200;
                growthFactoryUsa++;
                counterShop++;
            }
            if (counterShop == 3 && moneyUsa >= 200)
            {
                moneyUsa -= 200;
                growthFactoryUsa++;
                counterShop++;
            }
            if (counterShop == 4 && moneyUsa >= 200)
            {
                moneyUsa -= 200;
                growthFactoryUsa++;
                counterShop = 0;
            }
        }
        if (RandNomder == 2)
        {
            if (counterShop == 0 && moneyUsa >= 100)
            {
                moneyUsa -= 100;
                growthRocketUsa++;
                counterShop++;
            }
            if (counterShop == 1 && moneyUsa >= 150)
            {
                moneyUsa -= 150;
                growthProUsa++;
                counterShop++;
            }
            if (counterShop == 2 && moneyUsa >= 150)
            {
                moneyUsa -= 150;
                growthProUsa++;
                counterShop++;
            }
            if (counterShop == 3 && moneyUsa >= 150)
            {
                moneyUsa -= 150;
                growthProUsa++;
                counterShop++;
            }
            if (counterShop == 4 && moneyUsa >= 200)
            {
                moneyUsa -= 200;
                growthFactoryUsa++;
                counterShop = 0;
            }
        }
        //атака 
        if (rocketUsa > MainSrcipt.Rocket && rocketUsa > chinaScript.rocketChina && rocketUsa > britScript.rocketBrit && rocketUsa > franchScript.rocketFranch && rocketUsa > africaScript.rocketAfrica && rocketUsa >= 1000)
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
            ImageFone.color = new Color(0, 0, 0);
        }
        textRosketUsa.text = rocketUsa.ToString();
        textProUsa.text = proUsa.ToString();
        textFabricUsa.text = factoryUsa.ToString();
    }           
}
