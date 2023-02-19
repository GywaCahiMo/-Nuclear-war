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
        CounterRocket.text = MainScript.Rocket.ToString();
        CounterRocketGrowth.text = "+" + MainScript.GrowthRocket.ToString();
        StartCoroutine(Rocket());
    }
}
