using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 50f;

    private NewControls playerControls;
    private Vector2 movementInput;
    private Vector3 moveDirection;

    private void Awake()
    {
        playerControls = new NewControls();
        playerControls.PlayerInput.Movement.performed += _ => Move(_.ReadValue<Vector2>());
        playerControls.PlayerInput.Movement.canceled += _ => Move(_.ReadValue<Vector2>());
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * Time.deltaTime * moveSpeed;
    }

    public void Move(Vector2 direction)
    {
        Debug.Log($"direction: {direction}");
        moveDirection = new Vector3(direction.x, 0.0f, direction.y);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
