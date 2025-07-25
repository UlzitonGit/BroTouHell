using UnityEngine;

public class Sword : WeaponGeneral
{
    [SerializeField] private float _scalePower = 0.1f;
    protected override void ScaleStats()
    {
        _damage += _scalePower;
    }
}
