using System.Collections;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class RocketMenu : MonoBehaviour
{
    public Main MainScript;

    public Text CounterRocket;
    public Text CounterRocketGrowth;

    void Start()
    {
        StartCoroutine(Rocket()); 
    }  
    IEnumerator Rocket()
    {
        yield return new WaitForSeconds(1);
        MainScript.Rocket += MainScript.GrowthRocket;
        CounterRocket.text = MainScript.Rocket.ToString();
        CounterRocketGrowth.text = "+" + MainScript.GrowthRocket.ToString();
        StartCoroutine(Rocket());
    }
}
