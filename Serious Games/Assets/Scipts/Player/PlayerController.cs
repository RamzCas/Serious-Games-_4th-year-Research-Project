using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float Speed;
    public bool IsSprinting;
    public float SprintSpeed;
    public float Rotation;
    public Rigidbody2D rb;
    private Vector2 MoveInput;

    [Header("Interaction")]
    public float InteractRange;
    public float RayDistance;
    public Transform Player;

    PlayerControler Controls;

    private void Awake()
    {
        Controls = new PlayerControler();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Controls.Enable();
        Controls.Player.Interaction.performed += Interact;
        Controls.Player.Sprint.performed += Sprint;
    }

    private void OnDisable()
    {
        Controls.Disable();
        Controls.Player.Sprint.canceled -= Sprint;
    }

    private void Update()
    {
        MoveInput = Controls.Player.Movement.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = MoveInput * Speed;

        if (MoveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(MoveInput.y, MoveInput.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        Ray();
    }

    public void Ray()
    {

    }

    public void Interact(InputAction.CallbackContext context) 
    {
        Debug.Log("Interact");
    }

  
    public void Sprint(InputAction.CallbackContext context) 
    {
        
    }
}
