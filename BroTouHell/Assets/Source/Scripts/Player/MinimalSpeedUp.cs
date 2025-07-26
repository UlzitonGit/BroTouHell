using UnityEngine;

public class MinimalSpeedUp : MonoBehaviour
{
    [SerializeField] private float _speedLimit;
    [SerializeField] private float _additableSpeed;
    private void Update()
    {
            Rigidbody _playerRb = gameObject.GetComponent<Rigidbody>();
            float _playerSpeed = _playerRb.linearVelocity.magnitude;
            if (_playerSpeed < _speedLimit)
            {
                _playerRb.transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
                _playerRb.AddForce(_playerRb.transform.forward * _additableSpeed, ForceMode.Impulse);
            }
    }
}
