using UnityEngine;

abstract public class Upgrade : MonoBehaviour
{
    public abstract void UpgradeTarget(ScriptableObject upgrade, HealthGeneral target);

}