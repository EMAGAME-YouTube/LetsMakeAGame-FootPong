using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour
{
    public AudioSource _audioSource;
    public AudioClip _clip;

    private Rigidbody2D _rb;
    private Vector3 LastVelocity;
    private int[] ballStartingVelocity = new int[] { -400, 300 };

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Starting());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LastVelocity = _rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = LastVelocity.magnitude;
        var direction = Vector3.Reflect(LastVelocity.normalized, collision.contacts[0].normal);
        _rb.velocity = direction * Mathf.Max(speed + 1, 0);
        _audioSource.PlayOneShot(_clip);
    }

    private IEnumerator Starting()
    {
        yield return new WaitForSeconds(1f);
        var random = new System.Random();
        _rb.velocity = new Vector2(ballStartingVelocity[random.Next(2)], ballStartingVelocity[random.Next(2)]);
    }
}
