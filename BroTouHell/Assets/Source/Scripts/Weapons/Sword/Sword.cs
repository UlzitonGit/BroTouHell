using UnityEngine;

public class Sword : WeaponGeneral
{
    [SerializeField] private float _scalePower = 0.1f;
    [SerializeField] private float _baseDamageAmplification = 3f;

    private void Start()
    {
        print(_playerStats);
        _playerStats.IncreasePlayerDamage(_baseDamageAmplification, false);
    }
    protected override void ScaleStats()
    {
        _playerStats.IncreasePlayerDamage(_scalePower, false);
    }
}
