using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUpgrads : MonoBehaviour
{
    [SerializeField] private test _mainScripts;
    public void ClickButtonUpgradeRocket()
    {
        if (_mainScripts.Money >= 100 * _mainScripts.CountBuild)
        {
            _mainScripts.Money -= 100 * _mainScripts.CountBuild;
            _mainScripts.GrowthRocket += 1 * _mainScripts.CountBuild;
        }
    }
    public void ClickButtonUpgradePro()
    {
        if (_mainScripts.Money >= 150 * _mainScripts.CountBuild)
        {
            _mainScripts.Money -= 150 * _mainScripts.CountBuild;
            _mainScripts.GrowthPro += 1 * _mainScripts.CountBuild;
        }
    }
    public void ClickButtonUpgradeFactory()
    {
        if (_mainScripts.Money >= 200 * _mainScripts.CountBuild)
        {
            _mainScripts.Money -= 200 * _mainScripts.CountBuild;
            _mainScripts.GrowthFactory += 1 * _mainScripts.CountBuild;
        }
    }
}
