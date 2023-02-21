using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUpgrads : MonoBehaviour
{
    [SerializeField] private test _mainScripts;
    public void ClickButtonUpgradeRocket()
    {
        if (_mainScripts.Money >= 10000)
        {
            _mainScripts.Money -= 10000;
            _mainScripts.GrowthRocket++;
        }
    }
    public void ClickButtonUpgradePro()
    {
        if (_mainScripts.Money >= 15000)
        {
            _mainScripts.Money -= 15000;
            _mainScripts.GrowthPro++;
        }
    }
    public void ClickButtonUpgradeFactory()
    {
        if (_mainScripts.Money >= 20000)
        {
            _mainScripts.Money -= 20000;
            _mainScripts.GrowthFactory++;
        }
    }
}
