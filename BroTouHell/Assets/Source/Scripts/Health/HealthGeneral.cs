using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class HealthGeneral : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _deathParticle;
    private bool _isPlayer;
    private bool _isDead;
    private NewLevel _levelManager;

    private void Start()
    {
        _isPlayer = GetComponent<PlayerMovement>().GetIsPlayer();
        _levelManager = FindAnyObjectByType<NewLevel>();
    }
    public void GetDamage(float damage)
    {
        _health -= damage;
        _animator.SetTrigger("Hit");
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
