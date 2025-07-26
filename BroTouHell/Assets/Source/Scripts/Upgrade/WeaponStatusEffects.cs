using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatusEffects : MonoBehaviour
{
    private List<StatusEffect> _statusEffects;

    public void AddNewEffect(StatusEffect newEffect)
    {
        if (_statusEffects.Contains(newEffect) == false)
        {
            _statusEffects.Add(newEffect);
        }
    }

    public List<StatusEffect> GetStatusEffects()
    {
        return _statusEffects;
    }
}
