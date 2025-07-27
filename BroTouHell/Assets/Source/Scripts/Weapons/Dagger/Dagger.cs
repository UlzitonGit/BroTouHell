using UnityEngine;

public class Dagger : WeaponGeneral
{
    [SerializeField] private float _scalePower = 10f;
    [SerializeField] private float _baseRotationSpeedAmplification = 115f;

    private void Start()
    {
        StartingBuff();
    }

    public override void StartingBuff()
    {
        _playerStats.IncreaseRotationSpeed(_baseRotationSpeedAmplification, false);
    }
    public override void ScaleStats()
    {
        _playerStats.IncreaseRotationSpeed(_scalePower, false);
    }
}
