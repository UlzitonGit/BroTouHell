using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SOEffects : MonoBehaviour
{
    private List<StatusEffect> _statusEffectsForSO = new List<StatusEffect>();
    private List<StatusEffectSO> _statusEffectsSO = new List<StatusEffectSO>();

    [Inject]
    private void Constructor(List<StatusEffect> statusEffects, List<StatusEffectSO> statusEffectsSO)
    {
        _statusEffectsForSO = statusEffects;
        _statusEffectsSO = statusEffectsSO;
    }
    private void Start()
    {
        for (int i = 0; i < _statusEffectsForSO.Count; i++)
        {
            print(i);
            switch (_statusEffectsSO[i].Type)
            {
                case StatusEffectUpgradeType.Poison:
                    _statusEffectsSO[i].StatusEffect = _statusEffectsForSO[0];
                    break;
                case StatusEffectUpgradeType.Bleeding:
                    _statusEffectsSO[i].StatusEffect = _statusEffectsForSO[1];
                    break;
            }
        }
    }
}
