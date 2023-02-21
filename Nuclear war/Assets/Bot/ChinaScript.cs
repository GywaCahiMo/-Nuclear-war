using System.Collections;
using UnityEngine;
using TMPro;

public class ChinaScript : MonoBehaviour
{
    public test MainSrcipt;
    public ButtonAttak attakButton;

    [SerializeField] public int moneyChina, proChina, rocketChina, factoryChina, growthProChina = 1, growthRocketChina = 1, growthFactoryChina = 1;
    [SerializeField] private TMP_Text textRosketChina, textProChina;
    [SerializeField] private int RandNomder, counterShop = 0;
    private int remainderRocketChina;
    public GameObject ChinaAcctivity;

    private void Start()
    {
        StartCoroutine(RocketChina());
        StartCoroutine(ProChina());
        StartCoroutine(FactoryChina());
        StartCoroutine(MoneyChina());

        RandNomder = Random.Range(0, 3);
    }
    public void AttackChina()
    {
        remainderRocketChina = rocketChina - (MainSrcipt.Pro * 2);
        MainSrcipt.Pro -= rocketChina / 2;
        MainSrcipt.Factory -= remainderRocketChina / 10;
        rocketChina = 0;
        if (MainSrcipt.Pro < 0)
        {
            MainSrcipt.Pro = 0;
        }
    }
    private IEnumerator RocketChina()
    {
        yield return new WaitForSeconds(1);
        rocketChina += growthRocketChina;
        textRosketChina.text = rocketChina.ToString();
        StartCoroutine(RocketChina());
    }
    private IEnumerator ProChina()
    {
        yield return new WaitForSeconds(1.5f);
        proChina += growthProChina;
        textProChina.text = proChina.ToString();
        StartCoroutine(ProChina());
    }
    private IEnumerator FactoryChina()
    {
        yield return new WaitForSeconds(20);
        factoryChina += growthFactoryChina;
        StartCoroutine(FactoryChina());
    }
    private IEnumerator MoneyChina()
    {
        yield return new WaitForSeconds(2);
        moneyChina += factoryChina * 200;
        StartCoroutine(MoneyChina());
    }
    private void Update()
    {
        if (RandNomder == 0)
        {
            if (counterShop == 0 && moneyChina >= 10000)
            {
                moneyChina -= 10000;
                growthRocketChina++;
                counterShop++;
            }
            if (counterShop == 1 && moneyChina >= 10000)
            {
                moneyChina -= 10000;
                growthRocketChina++;
                counterShop++;
            }
            if (counterShop == 2 && moneyChina >= 10000)
            {
                moneyChina -= 10000;
                growthRocketChina++;
                counterShop++;
            }
            if (counterShop == 3 && moneyChina >= 15000)
            {
                moneyChina -= 15000;
                growthProChina++;
                counterShop++;
            }
            if (counterShop == 4 && moneyChina >= 20000)
            {
                moneyChina -= 20000;
                growthFactoryChina++;
                counterShop = 0;
            }
        }
        if (RandNomder == 1)
        {
            if (counterShop == 0 && moneyChina >= 10000)
            {
                moneyChina -= 10000;
                growthRocketChina++;
                counterShop++;
            }
            if (counterShop == 1 && moneyChina >= 15000)
            {
                moneyChina -= 15000;
                growthProChina++;
                counterShop++;
            }
            if (counterShop == 2 && moneyChina >= 20000)
            {
                moneyChina -= 20000;
                growthFactoryChina++;
                counterShop++;
            }
            if (counterShop == 3 && moneyChina >= 20000)
            {
                moneyChina -= 20000;
                growthFactoryChina++;
                counterShop++;
            }
            if (counterShop == 4 && moneyChina >= 20000)
            {
                moneyChina -= 20000;
                growthFactoryChina++;
                counterShop = 0;
            }
        }
        if (RandNomder == 2)
        {
            if (counterShop == 0 && moneyChina >= 10000)
            {
                moneyChina -= 10000;
                growthRocketChina++;
                counterShop++;
            }
            if (counterShop == 1 && moneyChina >= 15000)
            {
                moneyChina -= 15000;
                growthProChina++;
                counterShop++;
            }
            if (counterShop == 2 && moneyChina >= 15000)
            {
                moneyChina -= 15000;
                growthProChina++;
                counterShop++;
            }
            if (counterShop == 3 && moneyChina >= 15000)
            {
                moneyChina -= 15000;
                growthProChina++;
                counterShop++;
            }
            if (counterShop == 4 && moneyChina >= 20000)
            {
                moneyChina -= 20000;
                growthFactoryChina++;
                counterShop = 0;
            }
        }
        if (MainSrcipt.Rocket < rocketChina * 1.2f && rocketChina >= 1000)
        {
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
        }
    }
}