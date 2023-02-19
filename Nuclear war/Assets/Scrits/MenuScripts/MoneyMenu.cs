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
    }
    private IEnumerator Money()
    {
        yield return new WaitForSeconds(1);
        MainScript.Money += MainScript.Factory * 200;
        CounterMoney.text = MainScript.Money.ToString();
        StartCoroutine(Money());
    }
}
