using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _graphicTransform;
    [SerializeField] bool _isPlayer;
    private Rigidbody _rb;
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(transform.forward * _speed, ForceMode.Impulse);
    }

    private void Update()
    {
        _graphicTransform.rotation = Quaternion.LookRotation (_rb.linearVelocity);
    }

    public bool GetIsPlayer()
    {
        return _isPlayer;
    }
}
