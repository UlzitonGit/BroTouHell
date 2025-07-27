using UnityEngine;

public class Poison : StatusEffect
{

    [SerializeField] private float _effectFrequency;
    private float timer;

    public override bool CreateEffect(HealthGeneral target, PlayerStats user)
    {
        print("CreateEffect() Poison начался");
        timer += Time.deltaTime;
        if (timer >= _effectFrequency)
        {
            timer = 0;
            target.GetDamage(user.GetComponent<PlayerStats>().GetPoisonDamage());
            print("Урон Poison прошел!");
        }
        return true;
    }
}