using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] VariableJoystick _joystick;
    [SerializeField] float _speed;

    [Header("Player Components")]
    [SerializeField] Animator animator;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.forward = transform.forward + new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);
        rb.velocity = (Vector3.forward * _joystick.Vertical + Vector3.right * _joystick.Horizontal) * _speed;
        animator.SetFloat("Speed", rb.velocity.magnitude);
    }
}
