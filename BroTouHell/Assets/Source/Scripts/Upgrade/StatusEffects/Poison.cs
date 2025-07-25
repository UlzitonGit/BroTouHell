using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class AddStatusEffect : Upgrade
{
    [SerializeField] private List<StatusEffectSO> _statusEffectsList;
    public override void UpgradeTarget(ScriptableObject upgrade, GameObject target)
    {
        AddEffect((StatusEffectSO)upgrade, target.GetComponent<PlayerWeaponModifier>());
    }

    public void AddEffect(StatusEffectSO upgrade, PlayerWeaponModifier target)
    {
        switch (upgrade.Type)
        {
            
        }
    }
}
