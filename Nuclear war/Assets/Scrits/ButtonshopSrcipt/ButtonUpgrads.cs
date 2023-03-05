using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUpgrads : MonoBehaviour
{
    [SerializeField] private test _mainScripts;
    public void ClickButtonUpgradeRocket()
    {
        if (_mainScripts.Money >= 10000 * _mainScripts.CountBuild)
        {
            _mainScripts.Money -= 10000 * _mainScripts.CountBuild;
            _mainScripts.GrowthRocket += 1 * _mainScripts.CountBuild;
        }
    }
    public void ClickButtonUpgradePro()
    {
        if (_mainScripts.Money >= 15000 * _mainScripts.CountBuild)
        {
            _mainScripts.Money -= 15000 * _mainScripts.CountBuild;
            _mainScripts.GrowthPro += 1 * _mainScripts.CountBuild;
        }
    }
    public void ClickButtonUpgradeFactory()
    {
        if (_mainScripts.Money >= 20000 * _mainScripts.CountBuild)
        {
            _mainScripts.Money -= 20000 * _mainScripts.CountBuild;
            _mainScripts.GrowthFactory += 1 * _mainScripts.CountBuild;
        }
    }
}
