using UnityEngine;

public class Shield : WeaponGeneral
{
    [SerializeField] private float _scalePower = 3f;
    [SerializeField] private float _baseParryDamageAmplification = 100f;

    private void Start()
    {
        StartingBuff();
    }

    public override void StartingBuff()
    {
        _playerStats.IncreaseParryDamage(_baseParryDamageAmplification, false);
    }
    public override void ScaleStats()
    {
        if (_playerStats == null)
        {
            _playerStats = gameObject.transform.parent.parent.GetComponent<PlayerStats>();
        }
        _playerStats.IncreasePlayerHealth(_scalePower, false);
    }
}
