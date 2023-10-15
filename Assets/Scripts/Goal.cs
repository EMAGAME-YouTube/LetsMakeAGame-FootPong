using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.name == "Ball")
            StartCoroutine(Goalll(collider2D.gameObject));
    }

    private IEnumerator Goalll(GameObject ball)
    {
        audioSource.PlayOneShot(audioClip);
        yield return new WaitForSeconds(0.1f);
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }

}
