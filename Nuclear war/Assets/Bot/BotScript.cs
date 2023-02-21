using System.Collections;
using UnityEngine;
using TMPro;

public class BotScript : MonoBehaviour
{
    public test MainSrcipt;
    public ButtonAttak attakButton;

    [SerializeField] public int moneyUsa, proUsa, rocketUsa, factoryUsa, growthProUsa = 1, growthRocketUsa = 1, growthFactoryUsa = 1;
    [SerializeField] private TMP_Text textRosketUsa, textProUsa;
    [SerializeField] private int RandNomder, counterShop = 0;
    private int remainderRocketUsa;
    public GameObject UsaAcctivity;

    private void Start()
    {
        StartCoroutine(RocketUsa());
        StartCoroutine(ProUsa());
        StartCoroutine(FactoryUsa());
        StartCoroutine(MoneyUsa());

        RandNomder = Random.Range(0, 3);
    }
    public void AttackUsa()
    {
        remainderRocketUsa = rocketUsa - (MainSrcipt.Pro * 2);
        MainSrcipt.Pro -= rocketUsa / 2;
        MainSrcipt.Factory -= remainderRocketUsa / 10;
        rocketUsa = 0;
        if (MainSrcipt.Pro < 0)
        {
            MainSrcipt.Pro = 0;
        }
    }
    private IEnumerator RocketUsa()
    {
        yield return new WaitForSeconds(1);
        rocketUsa += growthRocketUsa;
        textRosketUsa.text = rocketUsa.ToString();
        StartCoroutine(RocketUsa());
    }
    private IEnumerator ProUsa()
    {
        yield return new WaitForSeconds(1.5f);
        proUsa += growthProUsa;
        textProUsa.text = proUsa.ToString();
        StartCoroutine(ProUsa());
    }
    private IEnumerator FactoryUsa()
    {
        yield return new WaitForSeconds(20);
        factoryUsa += growthFactoryUsa;
        StartCoroutine(FactoryUsa());
    }
    private IEnumerator MoneyUsa()
    {
        yield return new WaitForSeconds(2);
        moneyUsa += factoryUsa * 200;
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
        if(MainSrcipt.Rocket < rocketUsa * 1.2f && rocketUsa >= 1000)
        {
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
    }           
}
