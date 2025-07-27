using UnityEngine;
using Zenject;

public class PlayerStatisticsInstaller : MonoInstaller
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private StatsUI _statsUI;
    public override void InstallBindings()
    {
        Container.Bind<PlayerStats>().FromInstance(_playerStats).AsSingle();
        Container.Bind<StatsUI>().FromInstance(_statsUI).AsSingle();
    }
}
