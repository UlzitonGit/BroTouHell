using System.Collections;
using UnityEngine;

public class Scythe : WeaponGeneral
{
    [SerializeField] private float _scalePower = 0.1f;
    [SerializeField] private StatusEffectSO _poison;
    private void Start()
    {
        StartingBuff();
    }

    public override void StartingBuff()
    {
        _weaponStatusEffects.AddNewEffect(_poison);
        print($"������ Poison �������� �� ������ {gameObject.transform.parent.parent}, {_weaponStatusEffects.GetStatusEffects().Count} - ������� ���������� ��������");
    }
    public override void ScaleStats()
    {
        _playerStats.IncreasePoisonDamage(_scalePower, false);
    }
}
