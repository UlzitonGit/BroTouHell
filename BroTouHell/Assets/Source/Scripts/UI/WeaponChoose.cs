using TMPro;
using UnityEngine;

public class WeaponChoose : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _weaponStatusText;
    private int _currentWeapon;
    void Start()
    {
        ChooseWeapon(PlayerPrefs.GetInt("Weapon"));
    }

    public void ChooseWeapon(int index)
    {
        _weaponStatusText[_currentWeapon].text = "Выбрать";
        _weaponStatusText[index].text = "Выбрано";
        _currentWeapon = index;
        PlayerPrefs.SetInt("Weapon", index);
    }
}
