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
        if (MainScript.Pro >= 0 && MainScript.Pro < 1000)
        {
            CounterPro.text = "<size=36>" + MainScript.Pro.ToString() + "</size>";
        }
        if (MainScript.Pro >= 1000 && MainScript.Pro < 10000)
        {
            CounterPro.text = "<size=31>" + MainScript.Pro.ToString() + "</size>";
        }
        if (MainScript.Pro >= 10000 && MainScript.Rocket < 100000)
        {
            CounterPro.text = "<size=26>" + MainScript.Pro.ToString() + "</size>";
        }   
        StartCoroutine(Pro());
    }
    private void Update()
    {
        CounterProGrowth.text = "+" + MainScript.GrowthPro.ToString();
    }
}
