using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    
    Rigidbody _rigidbody;
    Vector2 _movement;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        var moveToPosition = GetMoveToPosition();
        
        _rigidbody.MovePosition(moveToPosition);
    }

    Vector3 GetMoveToPosition()
    {
        var currentPosition = _rigidbody.position;
        var moveDirection = new Vector3(_movement.x, 0, _movement.y);

        var moveToPosition = currentPosition + moveDirection * (movementSpeed * Time.fixedDeltaTime);
        
        return moveToPosition;
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }
}
