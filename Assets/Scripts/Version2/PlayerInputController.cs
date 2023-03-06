using UnityEngine;
using InputActions;

namespace Version2
{
    public class PlayerInputController : MonoBehaviour
    {
        private Vector3 moveDirection;
        private NewControls playerControls;

        public Vector3 MoveDirection { get => moveDirection; }

        private void Awake()
        {
            playerControls = new NewControls();
            playerControls.PlayerInput.Movement.performed += _ => InputDirection(_.ReadValue<Vector2>());
            playerControls.PlayerInput.Movement.canceled += _ => InputDirection(_.ReadValue<Vector2>());
        }

        public void InputDirection(Vector2 direction)
        {
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
}