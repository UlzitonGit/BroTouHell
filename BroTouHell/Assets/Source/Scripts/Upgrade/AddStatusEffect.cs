using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class AddStatusEffect : Upgrade
{
    [SerializeField] private List<StatusEffectSO> _statusEffectsList;
    public override void UpgradeTarget(ScriptableObject upgrade, HealthGeneral target)
    {
        AddEffect((StatusEffectSO)upgrade, target.GetComponent<StatusEffectPipeline>());
    }

    public void AddEffect(StatusEffectSO upgrade, StatusEffectPipeline target)
    {
        target.AddStatusEffect(upgrade);
    }
}
