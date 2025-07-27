using System;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

public abstract class WeaponGeneral : MonoBehaviour
{
     [SerializeField] protected Transform _rotationPoint;
     [SerializeField] protected string _enemyTag;
     [SerializeField] protected string _enemyWeaponTag;
     [SerializeField] protected GameObject _hitVfx;
     protected TimeDilation _timeDilation;
     protected GameObject _enemy;
     protected HealthGeneral _enemyHealth;
     private SoundsPlayer _soundsPlayer;
     protected PlayerStats _playerStats;
     private int _rotateInverse = 1;
     private AddStatusEffect _addStatusEffect;
     protected WeaponStatusEffects _weaponStatusEffects;

    private void Awake()
    {
        _soundsPlayer = FindAnyObjectByType<SoundsPlayer>();
        _timeDilation = FindAnyObjectByType<TimeDilation>();
        _playerStats = gameObject.transform.parent.parent.GetComponent<PlayerStats>();
        _addStatusEffect = FindAnyObjectByType<AddStatusEffect>();
        print(_playerStats + " Меню статов определено");
        _weaponStatusEffects = gameObject.transform.parent.parent.GetComponent<WeaponStatusEffects>();
        print(_weaponStatusEffects + " Оружие определено");
    }
    protected virtual void Update()
     {
          Rotating();
     }
     protected virtual void Rotating()
     {
          _rotationPoint.Rotate(0, _playerStats.GetRotationSpeed() * Time.deltaTime * _rotateInverse, 0);
     }
     
     protected virtual void Parry()
     {
          _rotateInverse = _rotateInverse * -1;
          _soundsPlayer.PlayParry();
     }

     protected virtual void DealDamage(Collider other)
    {
    }
     private void OnTriggerEnter(Collider other)
     {
          if (other.CompareTag(_enemyTag))
          {
               _rotateInverse = _rotateInverse * -1;
               HealthGeneral _enemy = other.GetComponent<HealthGeneral>();
               print($"Hit, weapon status effects = {_weaponStatusEffects.GetStatusEffects().Count}, я - {gameObject.transform.parent.parent}");
               for (int i = 0; i < _weaponStatusEffects.GetStatusEffects().Count; i++)
               {
                   _addStatusEffect.DebuffTarget(_weaponStatusEffects.GetStatusEffects()[i], _enemy, _playerStats);
                   print($"Статус эффект {_weaponStatusEffects.GetStatusEffects()[i]} добавлен на существо {_enemy}");
               }
               if (UnityEngine.Random.Range(0f, 100f) > _playerStats.GetCritChance())
               {
                _enemy.GetDamage(_playerStats.GetPlayerDamage());
               }
               else
               {
                _enemy.GetDamage(_playerStats.GetPlayerDamage() * (_playerStats.GetCritDamage() + 100) / 100);
               }
               _timeDilation.StartDilation();
               Instantiate(_hitVfx, other.transform.position, _rotationPoint.rotation);
               ScaleStats();
          }
          if (other.CompareTag(_enemyWeaponTag))
          {
               Parry();
               other.transform.parent.parent.GetComponent<HealthGeneral>().GetDamage(_playerStats.GetPlayerDamage() * (_playerStats.GetParryDamage() / 100));
        }
     }

     protected abstract void ScaleStats();


}
