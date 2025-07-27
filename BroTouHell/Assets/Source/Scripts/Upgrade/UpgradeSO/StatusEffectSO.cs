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
    public bool CanStack = false;
}
public enum StatusEffectUpgradeType
{
    Poison,
    Bleeding
}
