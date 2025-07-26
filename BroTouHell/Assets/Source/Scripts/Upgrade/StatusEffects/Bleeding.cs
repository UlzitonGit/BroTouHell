using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class Bleeding : StatusEffect
{

    [SerializeField] private float _effectDuration;
    [SerializeField] private float _effectFrequency;
    private float timer;

    public override bool CreateEffect(HealthGeneral target)
    {
        timer += Time.deltaTime;
        if (timer >= _effectDuration)
        {
            return false;
        }
        if (timer >= _effectFrequency)
        {
            _effectDuration -= Time.deltaTime;
            timer = 0;
            target.GetDamage(GetComponent<PlayerStats>().GetBleedingDamage());
        }
        return true;
    }
}
