using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputActionReference Move;
    [SerializeField] float speed;

    Rigidbody2D rb;
    Vector2 moveInput;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Move.action.Enable();
        Move.action.performed += OnMove;
        Move.action.canceled += OnMove;
    }

    private void OnDisable()
    {
        Move.action.performed -= OnMove;
        Move.action.canceled -= OnMove;
        Move.action.Disable();
    }

   private void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);
    }
}
