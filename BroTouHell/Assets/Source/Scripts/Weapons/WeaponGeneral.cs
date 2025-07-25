using System;
using UnityEngine;

public abstract class WeaponGeneral : MonoBehaviour
{
     [SerializeField] protected Transform _rotationPoint;
     [SerializeField] protected string _enemyTag;
     [SerializeField] protected string _enemyWeaponTag;
     [SerializeField] protected float _rotationSpeed;
     [SerializeField] protected float _damage;

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

     private void OnTriggerEnter(Collider other)
     {
          if (other.CompareTag(_enemyTag))
          {
               print("Hit");
               ScaleStats();
          }
          if (other.CompareTag(_enemyWeaponTag))
          {
               Parry();
          }
     }

     protected abstract void ScaleStats();


}
