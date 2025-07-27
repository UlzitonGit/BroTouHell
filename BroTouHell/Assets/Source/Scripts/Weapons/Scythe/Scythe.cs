using System.Collections;
using UnityEngine;

public class Scythe : WeaponGeneral
{
    [SerializeField] private float _scalePower = 0.1f;
    [SerializeField] private StatusEffectSO _poison;

    private void Start()
    {
        _weaponStatusEffects.AddNewEffect(_poison);
        print($"Ёффект Poison добавлен на оружие {gameObject.transform.parent.parent}, {_weaponStatusEffects.GetStatusEffects().Count} - текущее количество эффектов");
    }
    protected override void ScaleStats()
    {
        _playerStats.IncreasePoisonDamage(_scalePower);
    }
}
