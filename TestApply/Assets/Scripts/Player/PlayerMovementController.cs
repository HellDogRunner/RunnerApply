using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _transformToMove;

    private float horizontalInput;
    private bool isMoving;

    private Vector3 _forwardDirection;
    private Vector3 _horizontalDirection;

    const float rotationPerSecond_c = 90 / 1f;
    private float amountRotated;  
    private bool rotateToLeft;
    private bool rotateToRight;

    private Touch curTouch;

    private Vector3 newPos;

    private void FixedUpdate()
    {
        if (isMoving)
        {
            _forwardDirection = transform.forward * _forwardSpeed * Time.fixedDeltaTime;
            _rigidbody.MovePosition(_rigidbody.position + _forwardDirection);
        }
        if (Input.touchCount > 0)
        {
            curTouch = Input.GetTouch(0);
            if (curTouch.phase == TouchPhase.Moved)
            {
                float newX = curTouch.deltaPosition.x * _horizontalSpeed * Time.deltaTime;

                newPos = _transformToMove.localPosition;

                newPos.x += newX;

                newPos.x = Mathf.Clamp(newPos.x, -1, 1);
                _transformToMove.localPosition = newPos;
;
            }
        }

        if (rotateToRight)
        {
            RotateToRight();
        }
        if (rotateToLeft)
        {
            RotateToLeft();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TurnRight")
        {
            rotateToRight = true;
        }
        if (other.tag == "TurnLeft")
        {
            rotateToLeft = true;
        }
    }

    private void RotateToLeft() 
    {
        var frameRotation = rotationPerSecond_c * Time.deltaTime;
        transform.Rotate(0, -frameRotation, 0);
        amountRotated += frameRotation;
        if (amountRotated >= 90)
        {
            amountRotated = 0f;
            rotateToLeft = false;
        }
    }
    private void RotateToRight()
    {
        var frameRotation = rotationPerSecond_c * Time.deltaTime;
        transform.Rotate(0, frameRotation, 0);
        amountRotated += frameRotation;
        if (amountRotated >= 90)
        {
            amountRotated = 0f;
            rotateToRight = false;
        }
    }

    //private void Update()
    //{
    //    horizontalInput = Input.GetAxis("Horizontal");
    //}

    public void IsAbleToMove(bool isAble) 
    {
        isMoving = isAble;
    }
}
