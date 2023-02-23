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
        MainScript.Factory = Random.Range(3, 7);
    }
    private IEnumerator Factory()
    {
        yield return new WaitForSeconds(10);
        MainScript.Factory += MainScript.GrowthFactory;
        
        StartCoroutine(Factory());
    }
    private void Update()
    {
        CounterFactoryGrowth.text = "+" + MainScript.GrowthFactory.ToString(); 
        if (MainScript.Factory >= 0 && MainScript.Factory < 1000)
        {
            CounterFactory.text = "<size=36>" + MainScript.Factory.ToString() + "</size>";
        }
        if (MainScript.Factory >= 1000 && MainScript.Factory < 10000)
        {
            CounterFactory.text = "<size=31>" + MainScript.Factory.ToString() + "</size>";
        }
        if (MainScript.Factory >= 10000 && MainScript.Factory < 100000)
        {
            CounterFactory.text = "<size=26>" + MainScript.Factory.ToString() + "</size>";
        }   
    }
}
