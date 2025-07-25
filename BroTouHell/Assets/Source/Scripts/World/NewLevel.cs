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

    [Inject]
    private void Constructor(PlayerMovement player, EnemyGenerator enemyGenerator)
    {
        _player = player;
        _enemyGenerator = enemyGenerator;
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
        _enemyGenerator.GenerateEnemy(_enemySpawnPoint1);// здесь рандомится враг
        if (_level % _levelsInStage == 0)
        {
            _enemyGenerator.GenerateEnemy(_enemySpawnPoint2);
        }
        _defeatedEnemies = 0;
    }

    public void IncreaseDefeatedEnemies()
    {
        _defeatedEnemies++;
    }
}
