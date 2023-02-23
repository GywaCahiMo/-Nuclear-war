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
    public GameObject ScreanDead, ScreanVictory, ImagePleerAttack;
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
    public void AttckPleerImage()
    {
        ImagePleerAttack.SetActive(true);
    }
    public void AttckPleer()
    {
        //атака на сша
        UsaScript.proUsa -= Convert.ToInt32(SlidersUsa.value);
        if(UsaScript.proUsa < 0)
        {
            UsaScript.factoryUsa += UsaScript.proUsa / 5;
            UsaScript.proUsa = 0;
        }
        Rocket -= Convert.ToInt32(SlidersUsa.value);
        if (UsaScript.factoryUsa <= 0)
        {
            Destroy(SlidersUsa);
        }
        //атака на китай
        ChinaScript.proChina -= Convert.ToInt32(SlidersChina.value);
        if (ChinaScript.proChina < 0)
        {
            ChinaScript.factoryChina += ChinaScript.proChina / 5;
            ChinaScript.proChina = 0;
        }
        Rocket -= Convert.ToInt32(SlidersChina.value);
        if (ChinaScript.factoryChina <= 0)
        {
            Destroy(SlidersChina);
        }
    }
    private void Update()
    {
        if (Factory <= 0)
        {
            ScreanDead.SetActive(true);       
            Time.timeScale = 0;
        }
        SlidersUsa.maxValue = Rocket - SlidersChina.value;
        SlidersChina.maxValue = Rocket - SlidersUsa.value;
        if(UsaScript.factoryUsa == 0 && ChinaScript.factoryChina == 0 && Factory > 0)
        {
            ScreanVictory.SetActive(true);
        }
    }
}
