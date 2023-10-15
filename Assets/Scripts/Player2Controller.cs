using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public float _speed;
    private Input _input = null;
    private Rigidbody2D _rb;
    private Vector2 _playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _input = new Input();
        _input.Enable();

        _input.Player2.Movement.performed += ctx => Movement(ctx.ReadValue<Vector2>());
        _input.Player2.HitBall.performed += ctx => HitBall();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.velocity = _playerDirection * _speed * Time.fixedDeltaTime * 1000;
    }

    void Movement(Vector2 value)
    {
        _playerDirection = value;
    }

    void HitBall()
    {
        StartCoroutine(RotateCo());
    }

    private IEnumerator RotateCo()
    {
        this.transform.Rotate(0, 0, -45, Space.Self);
        yield return new WaitForSeconds(0.1f);
        this.transform.Rotate(0, 0, 45, Space.Self);
    }
}
