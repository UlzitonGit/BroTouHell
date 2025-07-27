using UnityEngine;
using Zenject;

public class NewLevel : MonoBehaviour
{
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private Transform _enemySpawnPoint1;
    [SerializeField] private Transform _enemySpawnPoint2;
    [SerializeField] private int _levelsInStage;
    private PlayerMovement _player;
    private EnemyGenerator _enemyGenerator;
    private int _level = 0;
    private int _enemiesDuringBossFight = 2;
    private int _defeatedEnemies;
    private StageCounterUI _stageCounterUI;

    [Inject]
    private void Constructor(PlayerMovement player, EnemyGenerator enemyGenerator, StageCounterUI stageCounterUI)
    {
        _player = player;
        _enemyGenerator = enemyGenerator;
        _stageCounterUI = stageCounterUI;
    }
    public void NextLevel()
    {
        if (_level % _levelsInStage == 0 && _level != 0)
        {
            if (_defeatedEnemies == _enemiesDuringBossFight)
            {
                _player.GetComponent<HealthGeneral>().Heal(0, true);
                _player.GetComponent<StatusEffectPipeline>().DispellAll();
                LevelSwap();
            }
        }
        else
        {
            _player.GetComponent<HealthGeneral>().Heal(0, true);
            _player.GetComponent<StatusEffectPipeline>().DispellAll();
            LevelSwap();
        }
    }
    public void LevelSwap()
    {
        _level++;
        _stageCounterUI.NextStage(_level + 1);
    }

    public void SpawnCharacters()
    {
        _player.transform.position = _playerSpawnPoint.position;
        _enemyGenerator.GenerateEnemy(_enemySpawnPoint1);
        if (_level % _levelsInStage == 0 && _level != 0)
        {
            _enemyGenerator.GenerateEnemy(_enemySpawnPoint2);
        }
        _defeatedEnemies = 0;
    }

    public void IncreaseDefeatedEnemies()
    {
        _defeatedEnemies++;
    }
    public int GetLevel()
    {
        return _level;
    }
    public int GetLevelsInStage()
    {
        return _levelsInStage;
    }
}
