using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using System.Collections.Generic;
public class StatsUpgrade : Upgrade
{
    [SerializeField] private StatsUpgradeSO _upgrade;
    [SerializeField] private PlayerStats _target;
    private PlayerStats _playerStats;

    [Inject]
    private void Constructor(PlayerStats playerStats)
    {
        _playerStats = playerStats;
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
                _playerStats.IncreasePlayerDamage(upgrade.UpgradingValue);
                break;
            case StatsUpgradeType.Health:
                _playerStats.IncreasePlayerHealth(upgrade.UpgradingValue);
                break;
            case StatsUpgradeType.ProjectileAmount:
                _playerStats.IncreaseProjectileAmount(upgrade.UpgradingValue);
                break;
            case StatsUpgradeType.BleedingDamage:
                _playerStats.IncreaseBleedingDamage(upgrade.UpgradingValue);
                break;
        }
    }
}