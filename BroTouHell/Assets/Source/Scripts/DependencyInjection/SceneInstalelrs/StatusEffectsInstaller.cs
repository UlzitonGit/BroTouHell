using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class StatusEffectsInstaller : MonoInstaller
{
    [SerializeField] private List<StatusEffect> _statusEffects;
    [SerializeField] private AddStatusEffect _addStatusEffects;
    public override void InstallBindings()
    {
        Container.Bind<List<StatusEffect>>().FromInstance(_statusEffects).AsSingle();
        Container.Bind<AddStatusEffect>().FromInstance(_addStatusEffects).AsSingle();
    }
}
