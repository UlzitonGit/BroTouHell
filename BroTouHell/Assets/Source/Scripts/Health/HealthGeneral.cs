using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class HealthGeneral : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _deathParticle;
    [SerializeField] private TextMeshPro _damageText;
    [SerializeField] private Image _healthBar;
    private Animator _textAnimator;
    private bool _isPlayer;
    private bool _isDead;
    private NewLevel _levelManager;
    private SoundsPlayer _soundsPlayer;
    private PlayerStats _playerStats;
    private float _maxHealth;
    
    private void Start()
    {
        _textAnimator = _damageText.GetComponent<Animator>();
        _soundsPlayer = FindAnyObjectByType<SoundsPlayer>();
        _isPlayer = GetComponent<PlayerMovement>().GetIsPlayer();
        _levelManager = FindAnyObjectByType<NewLevel>();
        _playerStats = GetComponent<PlayerStats>();
        _health = _playerStats.GetPlayerHealth();
    }
    public void GetDamage(float damage)
    {
        if(damage == 0) return;
        _health -= damage;
        _maxHealth = _playerStats.GetPlayerHealth();
        _healthBar.fillAmount = _health / _maxHealth;
        _damageText.text = Math.Round(damage, 1).ToString();
        _textAnimator.SetTrigger("Damage");
        _animator.SetTrigger("Hit");
        _soundsPlayer.PlayGetDamage();
        if(_health <= 0) Death();
    }

    public void Heal(float heal, bool full = false)
    {
        if (full)
        {
            _health = _playerStats.GetPlayerHealth();
            _healthBar.fillAmount = 1;
        }
        else
        {
            _health += heal;
            _maxHealth = _playerStats.GetPlayerHealth();
            _healthBar.fillAmount = _health / _maxHealth;
        }
    }

    private void Death()
    {
        if (_isPlayer) SceneManager.LoadScene(1);
        else
        {
            if(_isDead) return;
            Instantiate(_deathParticle, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            _isDead = true;
            Destroy(gameObject);
            _levelManager.IncreaseDefeatedEnemies();
            _levelManager.NextLevel();
        }
    }
}
