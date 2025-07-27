using UnityEngine;
using Zenject;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float _playerDamage;

    [SerializeField] private float _playerHealth;

    [SerializeField] private float _bleedingDamage;

    [SerializeField] private float _bleedingChance;

    [SerializeField] private float _poisonDamage;

    [SerializeField] private float _rotationSpeed;

    [SerializeField] private float _parryDamageInPercents;

    [SerializeField] private float _critChance;

    [SerializeField] private float _critDamage;

    private int _powerUpsCount;


    public float GetPlayerDamage()
    {
        return _playerDamage;
    }
    public void IncreasePlayerDamage(float additionalDamage)
    {
        _playerDamage += additionalDamage;
        _powerUpsCount++;
        //print(_playerDamage);
    }


    public float GetPlayerHealth()
    {
        return _playerHealth;
    }
    public void IncreasePlayerHealth(float additionalHealth)
    {
        _playerHealth += additionalHealth;
        _powerUpsCount++;
        print(_playerHealth);
    }


    public float GetBleedingDamage()
    {
        return _bleedingDamage;
    }
    public void IncreaseBleedingDamage(float additionalDamage)
    {
        _bleedingDamage += additionalDamage;
        _powerUpsCount++;
        print(_bleedingDamage);
    }


    public float GetBleedingChance()
    {
        return _bleedingChance;
    }
    public void IncreaseBleedingChance(float additionalChance)
    {
        _bleedingChance += additionalChance;
        _powerUpsCount++;
        print(_bleedingChance);
    }


    public float GetPoisonDamage()
    {
        return _poisonDamage;
    }
    public void IncreasePoisonDamage(float additionalDamage)
    {
        _poisonDamage += additionalDamage;
        _powerUpsCount++;
        print(_poisonDamage);
    }


    public float GetRotationSpeed()
    {
        return _rotationSpeed;
    }
    public void IncreaseRotationSpeed(float additionalSpeed)
    {
        _rotationSpeed += additionalSpeed;
        _powerUpsCount++;
        print(_rotationSpeed);
    }


    public float GetParryDamage()
    {
        return _parryDamageInPercents;
    }
    public void IncreaseParryDamage(float additionalDamageInPercents)
    {
        _parryDamageInPercents += additionalDamageInPercents;
        _powerUpsCount++;
        print(_parryDamageInPercents);
    }


    public float GetCritChance()
    {
        return _critChance;
    }
    public void IncreaseCritChance(float additionalChance)
    {
        _critChance += additionalChance;
        _powerUpsCount++;
        print(_critChance);
    }


    public float GetCritDamage()
    {
        return _critDamage;
    }
    public void IncreaseCritDamage(float additionalDamage)
    {
        _critDamage += additionalDamage;
        _powerUpsCount++;
        print(_critDamage);
    }

    public int GetPowerUpsCount()
    {
        return _powerUpsCount;
    }
}
