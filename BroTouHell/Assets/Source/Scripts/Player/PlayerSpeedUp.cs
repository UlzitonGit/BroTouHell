using NUnit.Framework.Internal;
using UnityEngine;

public class PlayerSpeedUp : MonoBehaviour
{

    [SerializeField] private float _speedLimit;
    [SerializeField] private float _additableSpeed;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody _playerRb = collision.gameObject.GetComponent<Rigidbody>();
            float _playerSpeed = _playerRb.velocity.magnitude;
            print(_playerSpeed);
            if (_playerSpeed < _speedLimit)
            {
                transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
                _playerRb.AddForce(transform.forward * _additableSpeed, ForceMode.Impulse);
            }
        }
    }
}
