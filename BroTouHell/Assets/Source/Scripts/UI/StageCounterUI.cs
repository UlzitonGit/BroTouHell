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
        _cardUpgradeRandomizer.HideUpgrade();
        _cardAnimatorPanel.SetTrigger("Hide");
        StartCoroutine(StageCountdown());
    }
    
    IEnumerator StageCountdown()
    {
        yield return new WaitForSeconds(1f);
        _player.SetActive(false);
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
