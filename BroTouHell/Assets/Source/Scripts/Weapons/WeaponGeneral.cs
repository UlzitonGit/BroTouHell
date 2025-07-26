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

    private void Start()
    {
         _soundsPlayer = FindAnyObjectByType<SoundsPlayer>();
        _timeDilation = FindAnyObjectByType<TimeDilation>();
        _playerStats = gameObject.transform.parent.parent.GetComponent<PlayerStats>();
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
               print("Hit");
               if (UnityEngine.Random.Range(0f, 100f) > _playerStats.GetCritChance())
               {
                other.GetComponent<HealthGeneral>().GetDamage(_playerStats.GetPlayerDamage());
               }
               else
               {
                other.GetComponent<HealthGeneral>().GetDamage(_playerStats.GetPlayerDamage() * (_playerStats.GetCritDamage() + 100) / 100);
               }
               _timeDilation.StartDilation();
               Instantiate(_hitVfx, other.transform.position, _rotationPoint.rotation);
               ScaleStats();
          }
          if (other.CompareTag(_enemyWeaponTag))
          {
               Parry();
               other.GetComponent<HealthGeneral>().GetDamage(_playerStats.GetPlayerDamage() * _playerStats.GetParryDamage() / 100);
        }
     }

     protected abstract void ScaleStats();


}
