using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Кнопка бега")]
    [SerializeField] private KeyCode runningKey = KeyCode.LeftShift;
    [Header("Скорость ходьбы")]
    [SerializeField] private float _targetMovingSpeed = 1f;
    [Header("Скорость бега")]
    [SerializeField] private float _targetRunningSpeed = 10f;
    [Header("Скорость поворота")]
    [SerializeField] private float _rotateSpeed = 3f;
    [Header("Сила прыжка")]
    [SerializeField] private float _jumpForce = 3f;
    [Header("Маска земли")]
    [SerializeField] private LayerMask _groundLayer;

    private float _groundCheckRadius = 0.5f; // Радиус проверки касания с землей
    private float _currentMovingSpeed;

    private Rigidbody _playerRigidbody;
    private Animator _animator;

    private AnimMovement _animMovement;

    private void Start()
    {
        _playerRigidbody = gameObject.GetComponent<Rigidbody>();
        _animator = gameObject.GetComponent<Animator>();

        _animMovement = new AnimMovement(_animator);

        _currentMovingSpeed = _targetMovingSpeed;
    }

    void Update()
    { 
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0)
        {
            Move(horizontal,vertical);
        }
        else
        {
            StopMove();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (IsGrounded())
        {
            _animMovement.UnanimateJump();
        }

        if (Input.GetMouseButton(0))
        {
            Attack();
        }
        else
        {
            _animMovement.UnanimateAttack();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _animMovement.AnimateRun();
            _currentMovingSpeed = _targetRunningSpeed;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            _animMovement.UnanimateRun();
            _currentMovingSpeed = _targetMovingSpeed;
        }
    }

    private void Move(float horizontal, float vertical)
    {
        _animMovement.AnimateMove();

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        _playerRigidbody.velocity = movement * _currentMovingSpeed;

        if (movement != Vector3.zero)
        {
            // Используем Slerp для плавного поворота
            float angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, angle, 0f), Time.deltaTime * _rotateSpeed);
        }
    }

    private void StopMove()
    {
        _animMovement.UnanimateMove();
    }

    private void Jump()
    {
        _animMovement.AnimateJump();

        _playerRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down);
        return Physics.Raycast(transform.position, Vector3.down, _groundCheckRadius, _groundLayer);
    }

    private void Attack()
    {
        _animMovement.AnimateAttack();
    }
}
