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
    private void Start()
    {
        _enemyGenerator.GenerateEnemy(_enemySpawnPoint1);
    }
    public void NextLevel()
    {
        if (_level % _levelsInStage == 0 && _level != 0)
        {
            if (_defeatedEnemies == _enemiesDuringBossFight)
            {
                LevelSwap();
            }
        }
        else
        {
            LevelSwap();
        }
    }
    public void LevelSwap()
    {
        _level++;
        _player.transform.position = _playerSpawnPoint.position;
        _enemyGenerator.GenerateEnemy(_enemySpawnPoint1);// ����� ���������� ����
        if (_level % _levelsInStage == 0)
        {
            _enemyGenerator.GenerateEnemy(_enemySpawnPoint2);
        }
        _defeatedEnemies = 0;
        _stageCounterUI.NextStage(_level + 1);
    }

    public void IncreaseDefeatedEnemies()
    {
        _defeatedEnemies++;
    }
}
