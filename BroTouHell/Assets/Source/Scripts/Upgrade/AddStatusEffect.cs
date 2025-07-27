using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class AddStatusEffect : MonoBehaviour
{
    public void DebuffTarget(ScriptableObject debuff, HealthGeneral target, PlayerStats user)
    {
        AddEffect((StatusEffectSO)debuff, target.GetComponent<StatusEffectPipeline>(), user);
    }

    public void AddEffect(StatusEffectSO debuff, StatusEffectPipeline target, PlayerStats user)
    {
        target.AddStatusEffect(debuff, user);
    }
}
