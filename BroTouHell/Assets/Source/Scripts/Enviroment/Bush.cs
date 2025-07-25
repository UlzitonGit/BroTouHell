using System;
using UnityEngine;

public class Bush : MonoBehaviour
{
        [SerializeField] private Animator _animator;
        [SerializeField] private ParticleSystem _leafsParticles;
        private void OnCollisionEnter(Collision other)
        {
                if (other.transform.CompareTag("Player") || other.transform.CompareTag("Enemy"))
                {
                        _leafsParticles.Play();
                        _animator.SetTrigger("Hit");
                }
        }
}
