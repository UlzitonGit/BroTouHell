using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponModifier : MonoBehaviour
{
    [SerializeField] private List<StatusEffectSO> _weaponStatusEffectsList;

    public List<StatusEffectSO> GetWeaponStatusEffectsList()
    {
        return _weaponStatusEffectsList;
    }
}
