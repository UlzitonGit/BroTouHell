using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class StatusEffectsInstaller : MonoInstaller
{
    [SerializeField] private List<StatusEffect> _statusEffects;
    public override void InstallBindings()
    {
        Container.Bind<List<StatusEffect>>().FromInstance(_statusEffects).AsSingle();
    }
}
