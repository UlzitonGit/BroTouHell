using UnityEngine;

[CreateAssetMenu(fileName = "New status effect upgrade")]
public class StatusEffectSO : ScriptableObject
{
    public StatusEffectUpgradeType Type;
    public bool IsStacking;
    public bool IsPermanent;
    public string Description;
}
public enum StatusEffectUpgradeType
{
    Poison,
    Bleeding
}
