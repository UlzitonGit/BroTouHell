using UnityEngine;

public class Sword : WeaponGeneral
{
    [SerializeField] private float _scalePower = 0.1f;
    protected override void ScaleStats()
    {
        _damage += 0.1f;
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
}
