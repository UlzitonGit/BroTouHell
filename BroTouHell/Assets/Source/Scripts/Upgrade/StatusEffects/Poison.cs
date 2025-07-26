using UnityEngine;

public class Poison : StatusEffect
{

    [SerializeField] private float _effectFrequency;
    private float timer;

    public override bool CreateEffect(HealthGeneral target, PlayerStats user)
    {
        timer += Time.deltaTime;
        if (timer >= _effectFrequency)
        {
            print("Poison");
            timer = 0;
            target.GetDamage(user.GetComponent<PlayerStats>().GetPoisonDamage());
        }
        return true;
    }
}