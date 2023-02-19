using System.Collections;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RocketMenu : MonoBehaviour
{
    public test MainScript;
    
    [Header("Текста")]
    [SerializeField] private TMP_Text CounterRocket;
    [SerializeField] private TMP_Text CounterRocketGrowth;

    private void Start()
    {
        StartCoroutine(Rocket()); 
    }  
    private IEnumerator Rocket()
    {
        yield return new WaitForSeconds(1);
        MainScript.Rocket += MainScript.GrowthRocket;
        if (MainScript.Rocket >= 0 && MainScript.Rocket < 1000)
        {
            CounterRocket.text = "<size=36>" + MainScript.Rocket.ToString() + "</size>";
        }
        if (MainScript.Rocket >= 1000 && MainScript.Rocket < 10000)
        {
            CounterRocket.text = "<size=31>" + MainScript.Rocket.ToString() + "</size>";
        }
        if (MainScript.Rocket >= 10000 && MainScript.Rocket < 100000)
        {
            CounterRocket.text = "<size=26>" + MainScript.Rocket.ToString() + "</size>";
        }
        StartCoroutine(Rocket());
    }
    private void Update()
    {
        CounterRocketGrowth.text = "+" + MainScript.GrowthRocket.ToString();
    }
}
