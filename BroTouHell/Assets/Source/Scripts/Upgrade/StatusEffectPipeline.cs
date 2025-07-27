using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(HealthGeneral))]
public class StatusEffectPipeline : MonoBehaviour
{
    private List<StatusEffectSO> _statusEffects = new List<StatusEffectSO>();
    private List<PlayerStats> _users = new List<PlayerStats>();
    private void Update()
    {
        for (int i = 0;  i < _statusEffects.Count; i++)
        {
            print($"Статус эффект {_statusEffects[i]} вызван!, количество эффектов {_statusEffects.Count}, количество юзеров {_users.Count}, user - {_users[i]}");
            print($"{gameObject.GetComponent<HealthGeneral>()}");
            print($"{_statusEffects[i].StatusEffect}");
            if (_statusEffects[i].StatusEffect.CreateEffect(gameObject.GetComponent<HealthGeneral>(), _users[i]) == false)
            {
                print($"Статус эффект {_statusEffects[i]} сработал!, user - {_users[i]}");
                _statusEffects.RemoveAt(i);
                _users.RemoveAt(i);
            }
        }
    }

    public void DispellAll()
    {
        for (int i = 0; i < _statusEffects.Count; i++)
        {
            _statusEffects.RemoveAt(i);
            _users.RemoveAt(i);
        }
    }

    public List<StatusEffectSO> GetStatusEffects()
    {
        return _statusEffects;
    }

    public void AddStatusEffect(StatusEffectSO statusEffect, PlayerStats user)
    {
        if (statusEffect.CanStack == false && _statusEffects.Contains(statusEffect) == false)
        {
            _statusEffects.Add(statusEffect);
            _users.Add(user);
            print($"Статус эффект {statusEffect} добавлен в пайплайн!");
        }
        else if (statusEffect.CanStack == true)
        {
            _statusEffects.Add(statusEffect);
            _users.Add(user);
            print($"Статус эффект {statusEffect} добавлен в пайплайн!");
        }
    }
}
