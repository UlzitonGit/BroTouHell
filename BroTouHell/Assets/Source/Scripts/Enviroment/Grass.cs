using System;
using UnityEngine;

public class Grass : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            _animator.SetTrigger("Hit");
        }
    }
}
