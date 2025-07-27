using UnityEngine;

public class Shield : WeaponGeneral
{
    [SerializeField] private float _scalePower = 3f;
    [SerializeField] private float _baseParryDamageAmplification = 100f;

    private void Start()
    {
        _playerStats.IncreaseParryDamage(_baseParryDamageAmplification, false);
    }
    protected override void ScaleStats()
    {
        _playerStats.IncreasePlayerHealth(_scalePower, false);
    }
}
