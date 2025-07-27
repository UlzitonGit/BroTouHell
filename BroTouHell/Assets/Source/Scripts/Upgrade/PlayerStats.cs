using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private bool _isPlayer;

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

    private int _weaponStacksCount;

    private StatsUI _statsUI;

    [Inject]

    private void Constructor(StatsUI statsUI)
    {
        _statsUI = statsUI;
    }
    public float GetPlayerDamage()
    {
        return _playerDamage;
    }
    public void IncreasePlayerDamage(float additionalDamage, bool needUp)
    {
        _playerDamage += additionalDamage;
        if (needUp) _powerUpsCount++;
        else _weaponStacksCount++;
        print(_playerDamage);
        if (_isPlayer)
        {
            _statsUI.UpdateUI();
        }
    }


    public float GetPlayerHealth()
    {
        return _playerHealth;
    }
    public void IncreasePlayerHealth(float additionalHealth, bool needUp)
    {
        _playerHealth += additionalHealth;
        if (needUp) _powerUpsCount++;         
        else _weaponStacksCount++;
        print(_playerHealth);
        if (_isPlayer)
        {
            _statsUI.UpdateUI();
        }
    }


    public float GetBleedingDamage()
    {
        return _bleedingDamage;
    }
    public void IncreaseBleedingDamage(float additionalDamage, bool needUp)
    {
        _bleedingDamage += additionalDamage;
        if (needUp) _powerUpsCount++;         
        else _weaponStacksCount++;
        print(_bleedingDamage);
        if (_isPlayer)
        {
            _statsUI.UpdateUI();
        }
    }


    public float GetBleedingChance()
    {
        return _bleedingChance;
    }
    public void IncreaseBleedingChance(float additionalChance, bool needUp)
    {
        _bleedingChance += additionalChance;
        if (needUp) _powerUpsCount++;         
        else _weaponStacksCount++;
        print(_bleedingChance);
        if (_isPlayer)
        {
            _statsUI.UpdateUI();
        }
    }


    public float GetPoisonDamage()
    {
        return _poisonDamage;
    }
    public void IncreasePoisonDamage(float additionalDamage, bool needUp)
    {
        _poisonDamage += additionalDamage;
        if (needUp) _powerUpsCount++;         
        else _weaponStacksCount++;
        print(_poisonDamage);
        if (_isPlayer)
        {
            _statsUI.UpdateUI();
        }
    }


    public float GetRotationSpeed()
    {
        return _rotationSpeed;
    }
    public void IncreaseRotationSpeed(float additionalSpeed, bool needUp)
    {
        _rotationSpeed += additionalSpeed;
        if (needUp) _powerUpsCount++;         
        else _weaponStacksCount++;
        print(_rotationSpeed);
        if (_isPlayer)
        {
            _statsUI.UpdateUI();
        }
    }


    public float GetParryDamage()
    {
        return _parryDamageInPercents;
    }
    public void IncreaseParryDamage(float additionalDamageInPercents, bool needUp)
    {
        _parryDamageInPercents += additionalDamageInPercents;
        if (needUp) _powerUpsCount++;         
        else _weaponStacksCount++;
        print(_parryDamageInPercents);
        if (_isPlayer)
        {
            _statsUI.UpdateUI();
        }
    }


    public float GetCritChance()
    {
        return _critChance;
    }
    public void IncreaseCritChance(float additionalChance, bool needUp)
    {
        _critChance += additionalChance;
        if (needUp) _powerUpsCount++;         
        else _weaponStacksCount++;
        print(_critChance);
        if (_isPlayer)
        {
            _statsUI.UpdateUI();
        }
    }


    public float GetCritDamage()
    {
        return _critDamage;
    }
    public void IncreaseCritDamage(float additionalDamage, bool needUp)
    {
        _critDamage += additionalDamage;
        if (needUp) _powerUpsCount++;         
        else _weaponStacksCount++;
        print(_critDamage);
        if (_isPlayer)
        {
            _statsUI.UpdateUI();
        }
    }

    public int GetPowerUpsCount()
    {
        return _powerUpsCount;
    }

    public int GetWeaponStacksCount()
    {
        return _weaponStacksCount;
    }
}
