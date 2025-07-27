using UnityEngine;
using Zenject;

public class GenerationInstaller : MonoInstaller
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private EnemyGenerator _enemyGenerator;
    [SerializeField] private NewLevel _newLevel;
    [SerializeField] private StageCounterUI _stageCounterUI;
    [SerializeField] private SoundsPlayer _soundsPlayer;
    [SerializeField] private StatsUpgrade _statsUpgrade;
    public override void InstallBindings()
    {
        Container.Bind<PlayerMovement>().FromInstance(_player).AsSingle();
        Container.Bind<EnemyGenerator>().FromInstance(_enemyGenerator).AsSingle();
        Container.Bind<NewLevel>().FromInstance(_newLevel).AsSingle();
        Container.Bind<StageCounterUI>().FromInstance(_stageCounterUI).AsSingle();
        Container.Bind<SoundsPlayer>().FromInstance(_soundsPlayer).AsSingle();
        Container.Bind<StatsUpgrade>().FromInstance(_statsUpgrade).AsSingle();
    }
}
