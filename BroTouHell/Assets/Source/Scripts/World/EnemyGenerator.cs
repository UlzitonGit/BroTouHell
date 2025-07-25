using NUnit.Framework;
using UnityEngine;
using Zenject;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _enemyParent;
    // � ���� ���� 2 ����������������� ��������� - �������� � ������
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
