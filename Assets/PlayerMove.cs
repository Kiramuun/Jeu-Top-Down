using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 _movementInput;

    Rigidbody2D _rigid2D;

    public float _speed;

    void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"),
              vertical = Input.GetAxisRaw("Vertical");

        _movementInput = new Vector3(horizontal, 0, vertical).normalized;
    }

    void LateUpdate()
    {

    }

    void FixedUpdate()
    {
        Vector3 velocity = _movementInput * _speed;
        _rigid2D.velocity = velocity;
    }
}
