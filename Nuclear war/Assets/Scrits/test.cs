using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] public int Money, Pro, Rocket, Factory, GrowthPro = 1, GrowthRocket = 1, GrowthFactory = 1;
    [SerializeField] public bool DeadPrear = false;
    public GameObject ScreanDead;
    private void Update()
    {
        if(DeadPrear == true)
        {
            ScreanDead.SetActive(true);
        }
    }
}
