using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
        private void Start()
        {
                StartCoroutine(Delay());
        }

        IEnumerator Delay()
        {
                yield return new WaitForSeconds(3f);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
}
