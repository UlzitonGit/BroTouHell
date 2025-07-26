using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static UnityEditor.Experimental.GraphView.GraphView;

[CreateAssetMenu(fileName = "New status effect upgrade")]
public class StatusEffectSO : ScriptableObject
{
    public StatusEffectUpgradeType Type;
    public StatusEffect StatusEffect;
    public string Description;

    [Inject]
    private void Constructor(List<StatusEffect> statusEffects)
    {
        switch (Type)
        {
            case StatusEffectUpgradeType.Poison:
                StatusEffect = statusEffects[0];
                break;
            case StatusEffectUpgradeType.Bleeding:
                StatusEffect = statusEffects[1];
                break;
        }
    }
}
public enum StatusEffectUpgradeType
{
    Poison,
    Bleeding
}
