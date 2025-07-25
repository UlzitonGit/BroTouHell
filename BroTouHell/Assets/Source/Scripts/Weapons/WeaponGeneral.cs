using System;
using UnityEngine;
using Zenject;

public abstract class WeaponGeneral : MonoBehaviour
{
     [SerializeField] protected Transform _rotationPoint;
     [SerializeField] protected string _enemyTag;
     [SerializeField] protected string _enemyWeaponTag;
     [SerializeField] protected float _rotationSpeed;
     [SerializeField] protected float _damage;
     [SerializeField] protected GameObject _hitVfx;
     [SerializeField] protected TimeDilation _timeDilation;
    protected GameObject _enemy;
    protected HealthGeneral _enemyHealth;

    [Inject]
     private void Constructor(TimeDilation timeDilation)
     {
        _timeDilation = timeDilation;
     }
     protected virtual void Update()
     {
          Rotating();
     }
     protected virtual void Rotating()
     {
          _rotationPoint.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
     }
     
     protected virtual void Parry()
     {
          _rotationSpeed = _rotationSpeed * -1;
     }

     protected virtual void DealDamage(Collider other)
    {

    }
     private void OnTriggerEnter(Collider other)
     {
          if (other.CompareTag(_enemyTag))
          {
               print("Hit");
               other.GetComponent<HealthGeneral>().GetDamage(_damage);
               _timeDilation.StartDilation();
               Instantiate(_hitVfx, other.transform.position, _rotationPoint.rotation);
               ScaleStats();
          }
          if (other.CompareTag(_enemyWeaponTag))
          {
               Parry();
          }
     }

     protected abstract void ScaleStats();


}
