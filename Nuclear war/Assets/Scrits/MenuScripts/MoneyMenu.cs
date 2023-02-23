using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyMenu : MonoBehaviour
{
    public test MainScript;

    [Header("Текста")]
    [SerializeField] private TMP_Text CounterMoney;

    private void Start()
    {
        StartCoroutine(Money());
        MainScript.Money = Random.Range(20000, 50000);
    }
    private IEnumerator Money()
    {
        yield return new WaitForSeconds(2);
        MainScript.Money += MainScript.Factory * 100;        
        StartCoroutine(Money());
    }
    private void Update()
    {
        if(MainScript.Money >= 0 && MainScript.Money < 10000)
        {
            CounterMoney.text = "<size=36>" + MainScript.Money.ToString() + "</size>";
        }
        if (MainScript.Money >= 10000 && MainScript.Money < 100000)
        {
            CounterMoney.text = "<size=31>" + MainScript.Money.ToString() + "</size>";
        }
        if (MainScript.Money >= 100000 && MainScript.Money < 1000000)
        {
            CounterMoney.text = "<size=26>" + MainScript.Money.ToString() + "</size>";
        }
    }
}
