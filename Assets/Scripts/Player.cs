using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 50f;
    public Transform bottom;

    private Rigidbody rigid;
    private GameManager gameManager;
    private NewControls playerControls;
    private Vector3 moveDirection;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();

        playerControls = new NewControls();
        playerControls.PlayerInput.Movement.performed += _ => Move(_.ReadValue<Vector2>());
        playerControls.PlayerInput.Movement.canceled += _ => Move(_.ReadValue<Vector2>());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movePosition = Time.deltaTime * moveSpeed * moveDirection;
        transform.position += movePosition;
        bottom.position += movePosition;
    }

    private void OnEnable()
    {
        transform.position = new Vector3(0f, 2f, 0f);
        bottom.position = new Vector3(0f, -4f, 0f);
        rigid.isKinematic = false;
        playerControls.Enable();
    }

    private void OnDisable()
    {
        rigid.isKinematic = true;
        playerControls.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == bottom)
        {
            gameManager.EndGame();
        }
    }

    public void Move(Vector2 direction)
    {
        moveDirection = new Vector3(direction.x, 0.0f, direction.y);
    }
}
