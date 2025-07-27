using System;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using System.Collections.Generic;
using TMPro;

public class StatsUpgrade : Upgrade
{
    [SerializeField] public StatsUpgradeSO _upgrade;
    [SerializeField] private PlayerStats _target;
    private PlayerStats _playerStats;
    [SerializeField] private bool _forCharacter;

    [Inject]
    private void Constructor(PlayerStats playerStats)
    {
        _playerStats = playerStats;
    }

    private void Start()
    {
        if (_forCharacter == false)
        {
            GetComponentInChildren<TextMeshProUGUI>().text = _upgrade.Description;
        }
    }

    public void ButtonUpgrade()
    {
        print("power up");
        ChangeStats(_upgrade, _target);
    }
    public override void UpgradeTarget(ScriptableObject upgrade, HealthGeneral target)
    {
            ChangeStats((StatsUpgradeSO)upgrade, target.GetComponent<PlayerStats>());
    }

    public void ChangeStats(StatsUpgradeSO upgrade, PlayerStats target)
    {
        switch (upgrade.Type)
        {
            case StatsUpgradeType.Damage:
                _playerStats.IncreasePlayerDamage(upgrade.UpgradingValue, true);
                break;
            case StatsUpgradeType.Health:
                _playerStats.IncreasePlayerHealth(upgrade.UpgradingValue, true);
                break;
            case StatsUpgradeType.BleedingDamage:
                _playerStats.IncreaseBleedingDamage(upgrade.UpgradingValue, true);
                break;
            case StatsUpgradeType.BleedingChance:
                _playerStats.IncreaseBleedingChance(upgrade.UpgradingValue, true);
                break;
            case StatsUpgradeType.PoisonDamage:
                _playerStats.IncreasePoisonDamage(upgrade.UpgradingValue, true);
                break;
            case StatsUpgradeType.RotationSpeed:
                _playerStats.IncreaseRotationSpeed(upgrade.UpgradingValue, true);
                break;
            case StatsUpgradeType.ParryDamageInPercents:
                _playerStats.IncreaseParryDamage(upgrade.UpgradingValue, true);
                break;
            case StatsUpgradeType.CritDamage:
                _playerStats.IncreaseCritDamage(upgrade.UpgradingValue, true);
                break;
            case StatsUpgradeType.CritChance:
                _playerStats.IncreaseCritChance(upgrade.UpgradingValue, true);
                break;
        }
    }


    public StatsUpgradeSO GetUpgradeSO()
    {
        return _upgrade;
    }

}