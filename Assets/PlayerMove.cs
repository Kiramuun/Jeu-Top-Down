using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector2 _movementInput;

    public Animator _animatorRef;

    Rigidbody2D _rigidB;

    public float _speed;

    void Awake()
    {
        _rigidB = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"),
              vertical = Input.GetAxisRaw("Vertical");

        _movementInput = new Vector2(horizontal, vertical).normalized;

        if ((Input.GetButtonDown("Jump")) && !_animatorRef.GetBool("touchRoll"))
        {
            _animatorRef.SetBool("touchRoll", true);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) { _speed *=2f; }
        if (Input.GetKeyUp(KeyCode.LeftShift)) { _speed /=2f; }

        _animatorRef.SetFloat("Horizontal", horizontal);
        _animatorRef.SetFloat("Vertical", vertical);
    }
    void LateUpdate()
    {

    }

    void FixedUpdate()
    {

        Vector2 velocity = _movementInput * _speed;
        _rigidB.velocity = velocity;
        _animatorRef.SetFloat("Speed", Mathf.Abs(_rigidB.velocity.x));
    }
}
