using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Animator _FadeAnimator;
    public void Play(int index)
    {
        StartCoroutine(FadeIn(index));
    }

    IEnumerator FadeIn(int index)
    {
        _FadeAnimator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(index);
    }
}
