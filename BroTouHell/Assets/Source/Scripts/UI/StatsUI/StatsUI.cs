using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;
using System;

public class StatsUI : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _textElements;
    private PlayerMovement _player;
    private PlayerStats _playerStats;

    [Inject]
    private void Constructor(PlayerMovement player)
    {
        _player = player;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        _playerStats = _player.GetComponent<PlayerStats>();
        _textElements[0].text = Math.Round(_playerStats.GetPlayerDamage(), 2).ToString();
        _textElements[1].text = Math.Round(_playerStats.GetPlayerHealth(), 2).ToString();
        _textElements[2].text = Math.Round(_playerStats.GetBleedingDamage(), 2).ToString();
        _textElements[3].text = Math.Round(_playerStats.GetBleedingChance(), 2).ToString();
        _textElements[4].text = Math.Round(_playerStats.GetPoisonDamage(), 2).ToString();
        _textElements[5].text = Math.Round(_playerStats.GetRotationSpeed(), 2).ToString();
        _textElements[6].text = Math.Round(_playerStats.GetParryDamage(), 2).ToString();
        _textElements[7].text = Math.Round(_playerStats.GetCritChance(), 2).ToString();
        _textElements[8].text = Math.Round(_playerStats.GetCritDamage(), 2).ToString();
    }
}
