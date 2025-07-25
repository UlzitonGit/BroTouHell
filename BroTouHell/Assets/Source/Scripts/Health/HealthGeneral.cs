using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class HealthGeneral : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private Animator _animator;
    private bool _isPlayer;
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
            Destroy(gameObject);
            _levelManager.IncreaseDefeatedEnemies();
            _levelManager.NextLevel();
        }
    }
}
