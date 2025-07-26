using UnityEngine;
using Zenject;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float _playerDamage;
    [SerializeField] private float _playerHealth;
    [SerializeField] private int _projectileAmount;
    [SerializeField] private float _bleedingDamage;


    public float GetPlayerDamage()
    {
        return _playerDamage;
    }
    public void IncreasePlayerDamage(float additionalDamage)
    {
        _playerDamage += additionalDamage;
        print("AAA" + _playerDamage);
    }


    public float GetPlayerHealth()
    {
        return _playerHealth;
    }
    public void IncreasePlayerHealth(float additionalHealth)
    {
        _playerHealth += additionalHealth;
        print("AAA" + _playerHealth);
    }


    public int GetProjectileAmount()
    {
        return _projectileAmount;
    }
    public void IncreaseProjectileAmount(int additionalAmount)
    {
        _projectileAmount += additionalAmount;
        print("AAA" + _projectileAmount);
    }


    public float GetBleedingDamage()
    {
        return _bleedingDamage;
    }
    public void IncreaseBleedingDamage(float additionalDamage)
    {
        _bleedingDamage += additionalDamage;
        print("AAA" + _bleedingDamage);
    }
}
