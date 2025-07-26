using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthGeneral))]
public class StatusEffectPipeline : MonoBehaviour
{
    [SerializeField] private List<StatusEffectSO> _statusEffects;

    private void Update()
    {
        for (int i = 0;  i < _statusEffects.Count; i++)
        {
            if(_statusEffects[i].StatusEffect.CreateEffect(gameObject.GetComponent<HealthGeneral>()) == false)
            {
                _statusEffects.RemoveAt(i);
                i--;
            }
        }
    }

    public List<StatusEffectSO> GetStatusEffects()
    {
        return _statusEffects;
    }

    public void AddStatusEffect(StatusEffectSO statusEffect)
    {
        _statusEffects.Add(statusEffect);
    }
}
