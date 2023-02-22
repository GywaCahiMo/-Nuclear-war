using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    public BotScript UsaScript;
    public ChinaScript ChinaScript;

    [SerializeField] public int Money, Pro, Rocket, Factory, GrowthPro = 1, GrowthRocket = 1, GrowthFactory = 1,nomderCounry = 0;
    [SerializeField] public bool Restert = false;
    private int remainderRocket;
    public GameObject ScreanDead;
    private Slider SlidersUsa;
    private Slider SlidersChina;

    private void Start()
    {
        Time.timeScale = 1;
        SlidersUsa = GameObject.Find("SliderUsa").GetComponent<Slider>();
        SlidersChina = GameObject.Find("SliderChina").GetComponent<Slider>();
    }
    public void ButtonRestart()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);       
    }
    public void AttckPleer()
    {

        Rocket -= Convert.ToInt32(SlidersUsa.value);
        remainderRocket = Convert.ToInt32(SlidersUsa.value) - (UsaScript.proUsa * 2);
        UsaScript.proUsa -= Convert.ToInt32(SlidersUsa.value) / 2;
        UsaScript.factoryUsa -= remainderRocket / 10;
        if (UsaScript.proUsa < 0)
        {
            UsaScript.proUsa = 0;
        }
        if (UsaScript.factoryUsa <= 0)
        {
            Destroy(SlidersUsa);
        }

        Rocket -= Convert.ToInt32(SlidersChina.value);
        remainderRocket = Convert.ToInt32(SlidersChina.value) - (ChinaScript.proChina * 2);
        ChinaScript.proChina -= Convert.ToInt32(SlidersChina.value) / 2;
        ChinaScript.factoryChina -= remainderRocket / 10;
        if (ChinaScript.proChina < 0)
        {
            ChinaScript.proChina = 0;
        }
        if (ChinaScript.proChina <= 0)
        {
            Destroy(SlidersChina);
        }

    }
    private void Update()
    {
        if(Factory <= 0)
        {
            ScreanDead.SetActive(true);
            Time.timeScale = 0;
        }
        SlidersUsa.maxValue = Rocket - SlidersChina.value;
        SlidersChina.maxValue = Rocket - SlidersUsa.value;
    }
}
