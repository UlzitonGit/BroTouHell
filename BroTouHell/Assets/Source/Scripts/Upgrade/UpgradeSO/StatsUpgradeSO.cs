using UnityEngine;

[CreateAssetMenu(fileName = "New stats upgrade")]
public class StatsUpgradeSO : ScriptableObject
{
    public StatsUpgradeType Type;
    public int UpgradingValue;
    public string Description;
}
public enum StatsUpgradeType
{
    Damage,
    Health,
    ProjectileAmount,
    BleedingDamage
}