using UnityEngine;

public class Sword : WeaponGeneral
{
    [SerializeField] private float _scalePower = 0.1f;
    protected override void ScaleStats()
    {
        _damage += _scalePower;
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
}
