using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;

public class CardUpgradesList : MonoBehaviour
{
     [SerializeField] public GameObject[] _cardUpgrades;
     private int _currentIndex;

    public GameObject[] GetCards()
    {
        return _cardUpgrades;
    }
    public void ShowUpgrade(int index)
     {
          _cardUpgrades[index].SetActive(true);
          _currentIndex = index;
     }

     public void HideUpgrade()
     {
          _cardUpgrades[_currentIndex].SetActive(false);
     }
}