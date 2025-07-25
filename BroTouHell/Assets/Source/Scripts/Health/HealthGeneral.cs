using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthGeneral : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private bool _isPlayer;
    [SerializeField] private Animator _animator;
    public void GetDamage(float damage)
    {
        _health -= damage;
        _animator.SetTrigger("Hit");
        if(_health <= 0) Death();
    }

    private void Death()
    {
        Destroy(gameObject);
        if (_isPlayer) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
