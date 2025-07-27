using UnityEngine;

public class Poison : StatusEffect
{

    [SerializeField] private float _effectFrequency;
    private float timer;

    public override bool CreateEffect(HealthGeneral target, PlayerStats user)
    {
        print("CreateEffect() Poison �������");
        timer += Time.deltaTime;
        if (timer >= _effectFrequency)
        {
            timer = 0;
            print(target);
            print(user);
            target.GetDamage(user.GetPoisonDamage());
            print($"���� Poison ������, ���� - {user.GetPoisonDamage()}!");
        }
        return true;
    }
}