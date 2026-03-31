using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float Speed;
    public float Rotation;
    public Rigidbody2D rb;
    private Vector2 MoveInput;

    [Header("Interaction")]
    public float InteractRange;

    PlayerControler Controls;

    private void Awake()
    {
        Controls = new PlayerControler();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Controls.Enable();
    }

    private void OnDisable()
    {
        Controls.Disable();
    }

    private void Update()
    {
        MoveInput = Controls.Player.Movement.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = MoveInput * Speed;
    }
}
