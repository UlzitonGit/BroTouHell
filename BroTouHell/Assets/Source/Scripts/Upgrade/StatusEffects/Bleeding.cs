using System.Collections;
using UnityEngine;
public class Bleeding : StatusEffect
{

    [SerializeField] private float _effectDuration;
    [SerializeField] private float _effectFrequency;
    private float timer;

    public override bool CreateEffect(HealthGeneral target, PlayerStats user)
    {
        timer += Time.deltaTime;
        if (timer >= _effectDuration)
        {
            print("Bleeding END");
            return false;
        }
        if (timer >= _effectFrequency)
        {
            print("Bleeding");
            _effectDuration -= Time.deltaTime;
            timer = 0;
            target.GetDamage(user.GetComponent<PlayerStats>().GetBleedingDamage());
        }
        return true;
    }
}
