using UnityEngine;

public class Sword : WeaponGeneral
{
    [SerializeField] private float _scalePower = 0.1f;
    [SerializeField] private float _baseDamageAmplification = 3f;

    private void Start()
    {
        StartingBuff();
    }

    public override void StartingBuff()
    {
        _playerStats.IncreasePlayerDamage(_baseDamageAmplification, false);
    }
    public override void ScaleStats()
    {
        if (_playerStats == null)
        {
            _playerStats = gameObject.transform.parent.parent.GetComponent<PlayerStats>();
        }
        _playerStats.IncreasePlayerDamage(_scalePower, false);
    }
}
