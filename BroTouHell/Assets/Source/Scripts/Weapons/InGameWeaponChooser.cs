using UnityEngine;

public class InGameWeaponChooser : MonoBehaviour
{
   [SerializeField] private GameObject[] _weapons;
    void Start()
    {
        _weapons[PlayerPrefs.GetInt("Weapon")].SetActive(true);
    }

}
