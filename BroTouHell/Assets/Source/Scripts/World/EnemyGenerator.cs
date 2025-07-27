using NUnit.Framework;
using System.Collections.Generic;
using System;
using UnityEngine;
using Zenject;
using System;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyParent;
    private PlayerMovement _player;
    private WeaponGeneral[] _weaponsArray;
    private PlayerStats _characterStats;

    [SerializeField] private float _buildStatChances;
    [SerializeField] private float _buildStatChancesProgression = 3f;
    [SerializeField] private WeaponBuildsList _weaponBuildsById;
    [SerializeField] private BuildList _builds;
    [SerializeField] private float _minimalPowerUps = 0.7f;
    [SerializeField] private float _minimalPowerUpsProgression = 0.2f;
    [SerializeField] private float _maximalPowerUps = 1.1f;
    [SerializeField] private float _maximalPowerUpsProgression = 0.2f;
    private NewLevel _levelSystem;

    private int _playerStatsCount;
    private int _playerWeaponStacks;

    private HealthGeneral _enemyHealth;

    private StatsUpgrade _upgrade;

    private int _weaponId;


    [Inject]

    private void Constructor(PlayerMovement player, StatsUpgrade upgrade, NewLevel levelSystem)
    {
        _player = player;
        _upgrade = upgrade;
        _levelSystem = levelSystem;
    }
    public void GenerateEnemy(Transform spawnPosition)
    {
        GameObject _newEnemy = Instantiate(_enemyPrefab, spawnPosition.position, Quaternion.identity, _enemyParent.transform);
        GetInfo(_newEnemy);
        PickWeapon(_newEnemy);
        BuffEnemy();
    }
    private void BuffEnemy()
    {
        int _enemiesPowerUps = Mathf.RoundToInt(UnityEngine.Random.Range((float)_playerStatsCount * _minimalPowerUps, (float)_playerStatsCount * _maximalPowerUps));
        int _enemiesWeaponStacks = Mathf.RoundToInt(UnityEngine.Random.Range((float)_playerWeaponStacks * _minimalPowerUps, (float)_playerWeaponStacks * _maximalPowerUps));

        for (int i = 0; i < _enemiesWeaponStacks; i++)
        {
            print($"Базовый скейл произведен! Итерация - {i}");
            _weaponsArray[_weaponId].GetComponent<WeaponGeneral>().ScaleStats();
        }

        print($"Количесто моих паверапов - {_playerStatsCount}, Количество паверапов противника - {_enemiesPowerUps}");

        for (int i = 0; i < _enemiesPowerUps; i++)
        {
            print("Цикл работает!");
            float _randomNumber = UnityEngine.Random.Range(0f, 100f);
            print(_randomNumber);
            if (_randomNumber < _buildStatChances)
            {
                int _randomWeaponBuild = _weaponBuildsById.GetRandomId(_weaponId);
                int _randomPowerUpId = UnityEngine.Random.Range(0, _builds.GetListCountById(_weaponId));
                _upgrade.UpgradeTarget(_builds.GetListById(_randomWeaponBuild).GetStatsUpgradeById(_randomPowerUpId), _enemyHealth);
                print($"Противник стал сильнее!, на него было применено улучшение: {_builds.GetListById(_randomWeaponBuild).GetStatsUpgradeById(_randomPowerUpId)} из билда {_randomWeaponBuild}, id улучшения в билде - {_randomPowerUpId}");
            }
            else
            {
                print("Противник получил бафф вне билда (повысил хп)");
                _characterStats.IncreasePlayerHealth(i * 2, true);
            }
        }
    }
    private void GetInfo(GameObject _newEnemy)
    {
        if (_levelSystem.GetLevel() % _levelSystem.GetLevelsInStage() == 0 && _levelSystem.GetLevel() == 1)
        {
            _playerStatsCount = _player.GetComponent<PlayerStats>().GetPowerUpsCount();
            _playerWeaponStacks = _player.GetComponent<PlayerStats>().GetWeaponStacksCount();
            _minimalPowerUps += _minimalPowerUpsProgression;
            _maximalPowerUps += _maximalPowerUpsProgression;
            if(_buildStatChances < 90)
            {
                _buildStatChances += _buildStatChancesProgression;
            }
        }
        _characterStats = _newEnemy.GetComponent<PlayerStats>();
        _enemyHealth = _newEnemy.GetComponent<HealthGeneral>();
    }

    private void PickWeapon(GameObject _newEnemy)
    {
        print(_newEnemy.transform.position + " " + _newEnemy.gameObject.transform.parent);
        _weaponsArray = _newEnemy.GetComponentsInChildren<WeaponGeneral>(true);
        print(_weaponsArray);
        _weaponId = UnityEngine.Random.Range(0, _weaponsArray.Length);
        _weaponsArray[_weaponId].gameObject.SetActive(true);
    }
}

[Serializable]
public class UpgradesList
{
    [SerializeField] StatsUpgradeSO[] _upgrades;

    public StatsUpgradeSO GetStatsUpgradeById(int id)
    {
        return _upgrades[id];
    }
}

[Serializable]
public class BuildList
{
    [SerializeField] private UpgradesList[] _build;

    public UpgradesList GetListById(int id)
    {
        return _build[id];
    }

    public int GetListCountById(int id)
    {
        return _build.Length;
    }
}


[Serializable]
public class ListOfBuilds
{
    [SerializeField] int[] _ids;

    public int[] GetAllBuilds()
    {
        return _ids;
    }
    public int GetListLenght(int id)
    {
        return _ids.Length;
    }

    public int GetRandomId(int id)
    {
        return _ids[UnityEngine.Random.Range(0, GetListLenght(id))];
    }
}

[Serializable]
public class WeaponBuildsList
{
    [SerializeField] private ListOfBuilds[] _listofBuilds;

    public ListOfBuilds GetListById(int id)
    {
        return _listofBuilds[id];
    }

    public int GetListCountById(int id)
    {
        return _listofBuilds[id].GetListLenght(id);
    }
    
    public int GetRandomId(int id)
    {
        return _listofBuilds[id].GetRandomId(id);
    }
}