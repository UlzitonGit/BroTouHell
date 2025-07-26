using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthGeneral : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _deathParticle;
    private bool _isPlayer;
    private bool _isDead;
    private NewLevel _levelManager;
    private SoundsPlayer _soundsPlayer;
    private PlayerStats _playerStats;
    
    private void Start()
    {
        _soundsPlayer = FindAnyObjectByType<SoundsPlayer>();
        _isPlayer = GetComponent<PlayerMovement>().GetIsPlayer();
        _levelManager = FindAnyObjectByType<NewLevel>();
        _playerStats = GetComponent<PlayerStats>();
        _health = _playerStats.GetPlayerHealth();
    }
    public void GetDamage(float damage)
    {
        _health -= damage;
        _animator.SetTrigger("Hit");
        _soundsPlayer.PlayGetDamage();
        if(_health <= 0) Death();
    }

    private void Death()
    {
        if (_isPlayer) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
