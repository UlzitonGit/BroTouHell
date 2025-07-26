using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class AddStatusEffect : MonoBehaviour
{
    public void DebuffTarget(ScriptableObject debuff, HealthGeneral target)
    {
        AddEffect((StatusEffectSO)debuff, target.GetComponent<StatusEffectPipeline>());
    }

    public void AddEffect(StatusEffectSO debuff, StatusEffectPipeline target)
    {
        target.AddStatusEffect(debuff, gameObject.GetComponent<PlayerStats>());
    }
}
