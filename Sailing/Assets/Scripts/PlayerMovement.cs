using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    private Vector2 _movement;
    private Rigidbody2D _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        var newPosition = GetNewPosition();
        
        _rigidbody.MovePosition(newPosition);
    }

    Vector2 GetNewPosition()
    {
        var currentPosition = _rigidbody.position;
        
        var newPosition = currentPosition + _movement * (moveSpeed * Time.fixedDeltaTime);
        
        return newPosition;
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
        Debug.Log(_movement);
    }
}
