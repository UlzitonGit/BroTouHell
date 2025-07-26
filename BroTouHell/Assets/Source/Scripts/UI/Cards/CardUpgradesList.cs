using UnityEngine;

public class CardUpgradesList : MonoBehaviour
{
     [SerializeField] public GameObject[] _cardUpgrades;
     private int _currentIndex;
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
