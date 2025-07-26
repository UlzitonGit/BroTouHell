using NUnit.Framework;
using UnityEngine;
using Zenject;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyParent;
    // В игре есть 2 рандомизированных параметра - апгрейды и оружие
    private WeaponGeneral[] _weaponsArray;
    public void GenerateEnemy(Transform spawnPosition)
    {
        GameObject _newEnemy = Instantiate(_enemyPrefab, spawnPosition.position, Quaternion.identity, _enemyParent.transform);
        print(_newEnemy.transform.position + " " + _newEnemy.gameObject.transform.parent);
        _weaponsArray = _newEnemy.GetComponentsInChildren<WeaponGeneral>(true);
        print(_weaponsArray);
        _weaponsArray[Random.Range(0, _weaponsArray.Length)].gameObject.SetActive(true);
    }
}
