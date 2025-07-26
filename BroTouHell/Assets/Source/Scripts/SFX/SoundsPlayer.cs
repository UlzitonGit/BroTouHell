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
        _audioSource.PlayOneShot(_cardPick);
    }
    public void PlayGetDamage()
    {
        _audioSource.PlayOneShot(_getDamage);
    }
    public void PlayParry()
    {
        _audioSource.PlayOneShot(_parry);
    }
}
