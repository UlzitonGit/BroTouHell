using UnityEngine;

public class Sword : WeaponGeneral
{
    [SerializeField] private float _scalePower = 0.1f;
    protected override void ScaleStats()
    {
        _playerStats.IncreasePlayerDamage(_scalePower);
    }
    protected override void DealDamage(Collider other)
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
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        DealDamage(other);
    }
}
