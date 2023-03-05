using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class test : MonoBehaviour
{
    public BotScript UsaScript;
    public ChinaScript ChinaScript;
    public BritScript BritScript;

    [SerializeField] public int Money, Pro, Rocket, Factory, GrowthPro = 1, GrowthRocket = 1, GrowthFactory = 1,nomderCounry = 0, CountBuild = 1;
    [SerializeField] public bool Restert = false;
    public GameObject ScreanDead, ScreanVictory, ImagePleerAttack;
    public GameObject UsaInfo, ChinaInfo, BritInfo;
    private Slider SlidersUsa;
    private Slider SlidersChina;
    private Slider SlidersBrit;
    [SerializeField] private TMP_Text textCountBuild, TextSliderUsa, TextSliderChina, TextSliderBrit;

    private void Start()
    {
        Time.timeScale = 1;
        SlidersUsa = GameObject.Find("SliderUsa").GetComponent<Slider>();
        SlidersChina = GameObject.Find("SliderChina").GetComponent<Slider>();
        SlidersBrit = GameObject.Find("SlidersBrit").GetComponent<Slider>();

        UsaInfo.SetActive(false);
        ChinaInfo.SetActive(false);
        BritInfo.SetActive(false);
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
        //атака на англию
        BritScript.proBrit -= Convert.ToInt32(SlidersBrit.value);
        if(BritScript.proBrit < 0)
        {
            BritScript.factoryBrit += BritScript.proBrit / 5;
            BritScript.proBrit = 0;
        }
        Rocket -= Convert.ToInt32(SlidersBrit.value);
        if(BritScript.factoryBrit <= 0)
        {
            Destroy(SlidersBrit);
        }
        SlidersUsa.value = 0;
        SlidersChina.value = 0;
        SlidersBrit.value = 0;
    }
    public void CounetrBuildUp()
    {
        CountBuild++;
    }
    public void CounetrBuildDown()
    {
        if(CountBuild > 1)
        {
            CountBuild--;
        }      
    }
    private void Update()
    {
        textCountBuild.text = CountBuild.ToString();
        if (Factory <= 0)
        {
            ScreanDead.SetActive(true);       
            Time.timeScale = 0;
        }
        SlidersUsa.maxValue = Rocket - SlidersChina.value - SlidersBrit.value;
        SlidersChina.maxValue = Rocket - SlidersUsa.value - SlidersBrit.value;
        SlidersBrit.maxValue = Rocket - SlidersUsa.value - SlidersChina.value;
        if (UsaScript.factoryUsa == 0 && ChinaScript.factoryChina == 0 && Factory > 0 && BritScript.factoryBrit == 0)
        {
            ScreanVictory.SetActive(true);
        }
        TextSliderUsa.text = SlidersUsa.value.ToString();
        TextSliderChina.text = SlidersChina.value.ToString();
        TextSliderBrit.text = SlidersBrit.value.ToString();
    }
}
