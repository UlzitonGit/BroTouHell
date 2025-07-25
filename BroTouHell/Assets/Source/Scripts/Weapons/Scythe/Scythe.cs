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

    private void PoisonEnemy()
    {

    }

    IEnumerator Poison()
    {
        yield return null;
    }
}
