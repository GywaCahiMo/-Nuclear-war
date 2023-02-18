using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUpgradeRocker : MonoBehaviour
{
    [SerializeField] private test _mainScripts;

    public void ClickButtonUpgradeRocket(int money)
    {
        if(_mainScripts.Money >= money)
        {
            _mainScripts.Money -= money;
            _mainScripts.GrowthRocket++;
        }
    }
}
