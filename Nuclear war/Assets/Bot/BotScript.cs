using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class BotScript : MonoBehaviour
{
    public test MainScript;
    public ButtonAttak attakButton;
    [SerializeField] public int moneyBot, proBot, rocketBot, factoryBot, growthProBot = 1, growthRocketBot = 1, growthFactoryBot = 1;
    [SerializeField] private TMP_Text textRosketBot, textProBot;
    [SerializeField] private int RandNomder, counterShop = 0;
    [SerializeField] public bool BotDead = false;
    public GameObject BotAcctivity;

    private void Start()
    {
        StartCoroutine(RocketBot());
        StartCoroutine(ProBot());
        StartCoroutine(FactoryBot());
        StartCoroutine(MoneyBot());

        RandNomder = Random.Range(0, 3);
    }
    private IEnumerator RocketBot()
    {
        yield return new WaitForSeconds(1);
        rocketBot += growthRocketBot;
        textRosketBot.text = rocketBot.ToString();
        StartCoroutine(RocketBot());
    }
    private IEnumerator ProBot()
    {
        yield return new WaitForSeconds(1.5f);
        proBot += growthProBot;
        textProBot.text = proBot.ToString();
        StartCoroutine(ProBot());
    }
    private IEnumerator FactoryBot()
    {
        yield return new WaitForSeconds(20);
        factoryBot += growthFactoryBot;
        StartCoroutine(FactoryBot());
    }
    private IEnumerator MoneyBot()
    {
        yield return new WaitForSeconds(2);
        moneyBot += factoryBot * 200;
        StartCoroutine(MoneyBot());
    }
    private void Update()
    {
        if (RandNomder == 0)
        {
            if (counterShop == 0 && moneyBot >= 10000)
            {
                moneyBot -= 10000;
                growthRocketBot++;
                counterShop++;
            }
            if (counterShop == 1 && moneyBot >= 10000)
            {
                moneyBot -= 10000;
                growthRocketBot++;
                counterShop++;
            }
            if (counterShop == 2 && moneyBot >= 10000)
            {
                moneyBot -= 10000;
                growthRocketBot++;
                counterShop++;
            }
            if (counterShop == 3 && moneyBot >= 15000)
            {
                moneyBot -= 15000;
                growthProBot++;
                counterShop++;
            }
            if (counterShop == 4 && moneyBot >= 20000)
            {
                moneyBot -= 20000;
                growthFactoryBot++;
                counterShop = 0;
            }
        }
        if (RandNomder == 1)
        {
            if (counterShop == 0 && moneyBot >= 10000)
            {
                moneyBot -= 10000;
                growthRocketBot++;
                counterShop++;
            }
            if (counterShop == 1 && moneyBot >= 15000)
            {
                moneyBot -= 15000;
                growthProBot++;
                counterShop++;
            }
            if (counterShop == 2 && moneyBot >= 20000)
            {
                moneyBot -= 20000;
                growthFactoryBot++;
                counterShop++;
            }
            if (counterShop == 3 && moneyBot >= 20000)
            {
                moneyBot -= 20000;
                growthFactoryBot++;
                counterShop++;
            }
            if (counterShop == 4 && moneyBot >= 20000)
            {
                moneyBot -= 20000;
                growthFactoryBot++;
                counterShop = 0;
            }
        }
        if (RandNomder == 2)
        {
            if (counterShop == 0 && moneyBot >= 10000)
            {
                moneyBot -= 10000;
                growthRocketBot++;
                counterShop++;
            }
            if (counterShop == 1 && moneyBot >= 15000)
            {
                moneyBot -= 15000;
                growthProBot++;
                counterShop++;
            }
            if (counterShop == 2 && moneyBot >= 15000)
            {
                moneyBot -= 15000;
                growthProBot++;
                counterShop++;
            }
            if (counterShop == 3 && moneyBot >= 15000)
            {
                moneyBot -= 15000;
                growthProBot++;
                counterShop++;
            }
            if (counterShop == 4 && moneyBot >= 20000)
            {
                moneyBot -= 20000;
                growthFactoryBot++;
                counterShop = 0;
            }
        }
        if(MainScript.Rocket < rocketBot * 1.2f && rocketBot >= 1000)
        {
            attakButton.AttacStart();
        }
        if(BotDead == true)
        {
            Destroy(BotAcctivity);
        }
    }           
}
