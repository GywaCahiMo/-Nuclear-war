using System.Collections;
using UnityEngine;
using TMPro;

public class ProMenu : MonoBehaviour
{
    public test MainScript;

    [Header("Текста")]
    [SerializeField] private TMP_Text CounterPro;
    [SerializeField] private TMP_Text CounterProGrowth;

    private void Start()
    {
        StartCoroutine(Pro());
    }
    private IEnumerator Pro()
    {
        yield return new WaitForSeconds(1.5f);
        MainScript.Pro += MainScript.GrowthPro;
        CounterPro.text = MainScript.Pro.ToString();
        CounterProGrowth.text = "+" + MainScript.GrowthPro.ToString();
        StartCoroutine(Pro());
    }
}
