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
    [SerializeField] private WeaponBuildsList _weaponBuildsById;
    [SerializeField] private BuildList _builds;
    [SerializeField] private float _minimalPowerUps = 0.7f;
    [SerializeField] private float _maximalPowerUps = 1.1f;
    private int _playerStatsCount;

    private HealthGeneral _enemyHealth;

    private StatsUpgrade _upgrade;

    private int _weaponId;


    [Inject]

    private void Constructor(PlayerMovement player, StatsUpgrade upgrade)
    {
        _player = player;
        _upgrade = upgrade;
    }
    public void GenerateEnemy(Transform spawnPosition)
    {
        GameObject _newEnemy = Instantiate(_enemyPrefab, spawnPosition.position, Quaternion.identity, _enemyParent.transform);
        _playerStatsCount = _player.GetComponent<PlayerStats>().GetPowerUpsCount();
        _characterStats = _newEnemy.GetComponent<PlayerStats>();
        _enemyHealth = _newEnemy.GetComponent<HealthGeneral>();
        print(_newEnemy.transform.position + " " + _newEnemy.gameObject.transform.parent);
        _weaponsArray = _newEnemy.GetComponentsInChildren<WeaponGeneral>(true);
        print(_weaponsArray);
        _weaponId = UnityEngine.Random.Range(0, _weaponsArray.Length);
        _weaponsArray[_weaponId].gameObject.SetActive(true);

        int _enemiesPowerUps = Mathf.RoundToInt(UnityEngine.Random.Range((float)_playerStatsCount * _minimalPowerUps, (float)_playerStatsCount * _maximalPowerUps));

        print($"Количесто моих паверапов - {_playerStatsCount}, Количество паверапов противника - {_enemiesPowerUps}");

        for (int i = 0; i <= _enemiesPowerUps; i++)
        {
            print("Цикл работает!");
            if (UnityEngine.Random.Range(0f, 100f) < _buildStatChances)
            {
                _upgrade.UpgradeTarget(_builds.GetListById(_weaponBuildsById.GetRandomId(_weaponId)).GetStatsUpgradeById(UnityEngine.Random.Range(0, _builds.GetListCountById(_weaponId))), _enemyHealth);
                print("Противник стал сильнее!");
            }
            else
            {
                _characterStats.IncreasePlayerHealth(i * 2);
            }
        }
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