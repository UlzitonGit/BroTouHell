using UnityEngine;
using Zenject;

public class VFXInstaller : MonoInstaller
{
    [SerializeField] private TimeDilation _timeDilationVFX;
    public override void InstallBindings()
    {
        Container.Bind<TimeDilation>().FromInstance(_timeDilationVFX).AsSingle();
    }
}
