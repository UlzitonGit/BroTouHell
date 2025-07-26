using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatusEffects : MonoBehaviour
{
    private List<StatusEffectSO> _statusEffects;

    public void AddNewEffect(StatusEffectSO newEffect)
    {
        if (_statusEffects.Contains(newEffect) == false)
        {
            _statusEffects.Add(newEffect);
        }
    }

    public List<StatusEffectSO> GetStatusEffects()
    {
        return _statusEffects;
    }
}
