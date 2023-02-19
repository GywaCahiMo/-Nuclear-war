using System.Collections;
using UnityEngine;
using TMPro;

public class FabricMenu : MonoBehaviour
{
    public test MainScript;

    [Header("Текста")]
    [SerializeField] private TMP_Text CounterFactory;
    [SerializeField] private TMP_Text CounterFactoryGrowth;

    private void Start()
    {
        StartCoroutine(Factory());
    }
    private IEnumerator Factory()
    {
        yield return new WaitForSeconds(20);
        MainScript.Factory += MainScript.GrowthFactory;
        CounterFactory.text = MainScript.Factory.ToString();
        CounterFactoryGrowth.text = "+" + MainScript.GrowthFactory.ToString();
        StartCoroutine(Factory());
    }
}
