using System.Collections;
using UnityEngine;

public class Scythe : WeaponGeneral
{
    [SerializeField] private float _scalePower = 0.1f;
    [SerializeField] private StatusEffectSO _poison;
    [SerializeField] private float _defaultPoisonDamage;
    private void Start()
    {
        StartingBuff();
        _playerStats.IncreasePoisonDamage(_defaultPoisonDamage, false);
    }

    public override void StartingBuff()
    {
        _weaponStatusEffects.AddNewEffect(_poison);
        print($"������ Poison �������� �� ������ {gameObject.transform.parent.parent}, {_weaponStatusEffects.GetStatusEffects().Count} - ������� ���������� ��������");
    }
    public override void ScaleStats()
    {
        if (_playerStats == null)
        {
            _playerStats = gameObject.transform.parent.parent.GetComponent<PlayerStats>();
        }
        _playerStats.IncreasePoisonDamage(_scalePower, false);
    }
}
