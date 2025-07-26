using UnityEngine;

public class SoundsPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    
    [SerializeField] private AudioClip _cardPick;
    [SerializeField] private AudioClip _getDamage;
    [SerializeField] private AudioClip _parry;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayCardPick()
    {
        _audioSource.pitch = Random.Range(0.8f, 1.0f);
        _audioSource.PlayOneShot(_cardPick, Random.Range(0.9f, 1.1f));
    }
    public void PlayGetDamage()
    {
        _audioSource.pitch = Random.Range(0.8f, 1.0f);
        _audioSource.PlayOneShot(_getDamage, Random.Range(0.9f, 1.1f));
    }
    public void PlayParry()
    {
        _audioSource.pitch = Random.Range(0.8f, 1.0f);
        _audioSource.PlayOneShot(_parry, Random.Range(0.7f, 0.8f));
    }
}
