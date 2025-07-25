using UnityEngine;
using Zenject;

public class PlayerStatisticsInstaller : MonoInstaller
{
    [SerializeField] private PlayerStats _playerStats;
    public override void InstallBindings()
    {
        Container.Bind<PlayerStats>().FromInstance(_playerStats).AsSingle();
    }
}
