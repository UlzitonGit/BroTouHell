using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthGeneral))]
public class StatusEffectPipeline : MonoBehaviour
{
    private List<StatusEffectSO> _statusEffects = new List<StatusEffectSO>();
    private List<PlayerStats> _users;

    private void Update()
    {
        for (int i = 0;  i < _statusEffects.Count; i++)
        {
            print($"������ ������ {_statusEffects[i]} ������!");
            if(_statusEffects[i].StatusEffect.CreateEffect(gameObject.GetComponent<HealthGeneral>(), _users[i]) == false)
            {
                print($"������ ������ {_statusEffects[i]} ��������!");
                _statusEffects.RemoveAt(i);
                _users.RemoveAt(i);
                i--;
            }
        }
    }

    public void DispellAll()
    {
        for (int i = 0; i < _statusEffects.Count; i++)
        {
            _statusEffects.RemoveAt(i);
            _users.RemoveAt(i);
            i--;
        }
    }

    public List<StatusEffectSO> GetStatusEffects()
    {
        return _statusEffects;
    }

    public void AddStatusEffect(StatusEffectSO statusEffect, PlayerStats user)
    {
        _statusEffects.Add(statusEffect);
        print($"������ ������ {statusEffect} �������� � ��������!");
    }
}
