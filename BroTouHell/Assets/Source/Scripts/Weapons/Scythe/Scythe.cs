using System.Collections;
using UnityEngine;

public class Scythe : WeaponGeneral
{
    [SerializeField] private float _scalePower = 0.1f;
    [SerializeField] private float _poisonFrequency = 0.5f;
    [SerializeField] private float _poisonDamage = 1f;
    protected override void ScaleStats()
    {
        _poisonDamage += _scalePower;
    }

    protected override void DealDamage(Collider other)
    {
        if (other.CompareTag(_enemyTag))
        {
            print("Hit");
            if (_enemyHealth == null)
            {
                _enemyHealth = other.GetComponent<HealthGeneral>();
            }
            _enemyHealth.GetDamage(_damage);
            _timeDilation.StartDilation();
            Instantiate(_hitVfx, other.transform.position, _rotationPoint.rotation);
            ScaleStats();
            if (_enemy == null)
            {
                _enemy = other.gameObject;
                StartCoroutine(PoisonEnemy());
            }
        }
        if (other.CompareTag(_enemyWeaponTag))
        {
            Parry();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        DealDamage(other);
    }

    IEnumerator PoisonEnemy()
    {
        while(_enemy != null) // ƒобавить диспелл при переходе на новый уровень
        {
            _enemyHealth.GetDamage(_poisonDamage);
            yield return new WaitForSeconds(_poisonFrequency);
        }
    }
}
