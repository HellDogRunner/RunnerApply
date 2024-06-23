using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _transformToMove;

    private bool isMoving;

    private Vector3 _forwardDirection;

    const float rotationPerSecond_c = 90 / 1f;
    private float amountRotated;  
    private bool rotateToLeft;
    private bool rotateToRight;

    private Touch _currentTouch;

    private Vector3 _newPos;

    private void FixedUpdate()
    {
        if (isMoving)
        {
            _forwardDirection = transform.forward * _forwardSpeed * Time.fixedDeltaTime;
            _rigidbody.MovePosition(_rigidbody.position + _forwardDirection);
        }
        if (Input.touchCount > 0)
        {
            _currentTouch = Input.GetTouch(0);
            if (_currentTouch.phase == TouchPhase.Moved)
            {
                float newX = _currentTouch.deltaPosition.x * _horizontalSpeed * Time.deltaTime;

                _newPos = _transformToMove.localPosition;

                _newPos.x += newX;

                _newPos.x = Mathf.Clamp(_newPos.x, -1, 1);
                _transformToMove.localPosition = _newPos;
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
    public void IsAbleToMove(bool isAble) 
    {
        isMoving = isAble;
    }
}
