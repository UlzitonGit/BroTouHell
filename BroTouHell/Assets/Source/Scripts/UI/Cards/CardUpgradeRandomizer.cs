using System.Collections.Generic;
using UnityEngine;

public class CardUpgradeRandomizer : MonoBehaviour
{
    [SerializeField] private CardUpgradesList[] _cardUpgradesList;
    private List<int> _upgrades = new List<int>();
    public void Randomize()
    {
        print("done1");
        while (_upgrades.Count < 3)
        {
            int index = Random.Range(0, _cardUpgradesList[0]._cardUpgrades.Length - 1);
            if (_upgrades.Contains(index))
            {
                _upgrades.Remove(index);
            }
            else
            {
                _upgrades.Add(index);
            }
        }

        print("done");
        for (int i = 0; i < _cardUpgradesList.Length; i++)
        {
            _cardUpgradesList[i].ShowUpgrade(_upgrades[i]);
        }
    }

    public void HideUpgrade()
    {
        for (int i = 0; i < _cardUpgradesList.Length; i++)
        {
            _cardUpgradesList[i].HideUpgrade();
        }
        _upgrades.Clear();
    }
}
