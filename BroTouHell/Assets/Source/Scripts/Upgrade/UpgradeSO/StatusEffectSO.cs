using UnityEngine;

[CreateAssetMenu(fileName = "New status effect upgrade")]
public class StatusEffectSO : ScriptableObject
{
    public StatusEffectUpgradeType Type;
    public StatusEffect StatusEffect;
    public string Description;
}
public enum StatusEffectUpgradeType
{
    Poison,
    Bleeding
}
