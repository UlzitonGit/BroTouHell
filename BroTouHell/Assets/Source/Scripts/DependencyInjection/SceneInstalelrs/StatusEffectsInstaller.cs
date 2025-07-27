using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class StatusEffectsInstaller : MonoInstaller
{
    [SerializeField] private List<StatusEffect> _statusEffects;
    [SerializeField] private List<StatusEffectSO> _statusEffectsSO;
    [SerializeField] private AddStatusEffect _addStatusEffects;

    public override void InstallBindings()
    {
        Container.Bind<List<StatusEffect>>().FromInstance(_statusEffects).AsSingle();
        Container.Bind<List<StatusEffectSO>>().FromInstance(_statusEffectsSO).AsSingle();
        Container.Bind<AddStatusEffect>().FromInstance(_addStatusEffects).AsSingle();
    }
}
