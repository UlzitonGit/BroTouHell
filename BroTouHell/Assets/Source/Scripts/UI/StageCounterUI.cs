using System;
using System.Collections;
using TMPro;
using UnityEngine;

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
    private void Start()
    {
        StartCoroutine(FirstStage());
    }
    
    public void NextStage(int level)
    {
        _backPanel.gameObject.SetActive(true);
        ShowCards();
        _stageCounterText.text = "СТАДИЯ " + level.ToString();
    }

    private void ShowCards()
    {
        _cardUpgradeRandomizer.Randomize();
        _player.SetActive(false);
        _enemy.SetActive(false);
        _cardAnimatorPanel.gameObject.SetActive(true);
    }

    public void CardChoosen()
    {
        _cardUpgradeRandomizer.HideUpgrade();
        _cardAnimatorPanel.SetTrigger("Hide");
        StartCoroutine(StageCountdown());
    }

    IEnumerator FirstStage()
    {
        yield return new WaitForSeconds(1f);
        NextStage(1);
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
        _backPanel.SetTrigger("Hide");
        _player.SetActive(true);
        _enemy.SetActive(true);
        yield return new WaitForSeconds(1f);
        _backPanel.gameObject.SetActive(false);
        _uiAnimator.SetActive(false);
        
    }
}
