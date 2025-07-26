using UnityEngine;
using Zenject;

public class GenerationInstaller : MonoInstaller
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private EnemyGenerator _enemyGenerator;
    [SerializeField] private NewLevel _newLevel;
    [SerializeField] private StageCounterUI _stageCounterUI;
    public override void InstallBindings()
    {
        Container.Bind<PlayerMovement>().FromInstance(_player).AsSingle();
        Container.Bind<EnemyGenerator>().FromInstance(_enemyGenerator).AsSingle();
        Container.Bind<StageCounterUI>().FromInstance(_stageCounterUI).AsSingle();
    }
}
