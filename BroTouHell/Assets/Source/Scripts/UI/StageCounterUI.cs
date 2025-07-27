using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;
public class StageCounterUI : MonoBehaviour
{
    [SerializeField] private GameObject _uiAnimator;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private TextMeshProUGUI _countDownText;
    [SerializeField] private TextMeshProUGUI _stageCounterText;
    [SerializeField] private Animator _backPanel;
    [SerializeField] private Animator _cardAnimatorPanel;
    [SerializeField] private CardUpgradeRandomizer _cardUpgradeRandomizer;
    bool _active = false;
    private NewLevel _levelSystem;
    private SoundsPlayer _soundsPlayer;
    [Inject]
    private void Constructor(SoundsPlayer soundsPlayer, NewLevel levelSystem)
    {
        _soundsPlayer = soundsPlayer;
        _levelSystem = levelSystem;
   
    }
    private void Start()
    {
        StartCoroutine(StageCountdown());
        _stageCounterText.text = "СТАДИЯ 1";
    }

  

    public void NextStage(int level)
    {
        StartCoroutine(Duration());
        _stageCounterText.text = "СТАДИЯ " + level.ToString();
    }
    IEnumerator Duration()
    {
        _enemy.SetActive(false);
        yield return new WaitForSeconds(2f);
        _player.SetActive(false);
        _backPanel.gameObject.SetActive(true);
        ShowCards();
    }
    
    private void ShowCards()
    {
        _cardUpgradeRandomizer.Randomize();
        _cardAnimatorPanel.gameObject.SetActive(true);
    }

    public void CardChoosen()
    {
        _soundsPlayer.PlayCardPick();
        _cardUpgradeRandomizer.HideUpgrade();
        _cardAnimatorPanel.SetTrigger("Hide");
        StartCoroutine(StageCountdown());
    }
    
    IEnumerator StageCountdown()
    {
        yield return new WaitForSeconds(1f);
        _cardAnimatorPanel.gameObject.SetActive(false);
        _uiAnimator.SetActive(true);
        for (int i = 3; i != 0; i--)
        {
            _countDownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        print("aaa");
        _levelSystem.SpawnCharacters();
        _backPanel.SetTrigger("Hide");
        _player.SetActive(true);
        _enemy.SetActive(true);
        yield return new WaitForSeconds(1f);
        _backPanel.gameObject.SetActive(false);
        _uiAnimator.SetActive(false);
        
    }
}
