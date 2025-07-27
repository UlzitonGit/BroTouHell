using UnityEngine;

public class Dagger : WeaponGeneral
{
    [SerializeField] private float _scalePower = 10f;
    [SerializeField] private float _baseRotationSpeedAmplification = 115f;

    private void Start()
    {
        _playerStats.IncreaseRotationSpeed(_baseRotationSpeedAmplification, false);
    }
    protected override void ScaleStats()
    {
        _playerStats.IncreaseRotationSpeed(_scalePower, false);
    }
}
