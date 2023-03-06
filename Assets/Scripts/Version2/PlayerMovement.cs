using System.Collections;
using UnityEngine;

namespace Version2
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed = 3.0f;

        private PlayerInputController playerInputs;

        private void Awake()
        {
            playerInputs = GetComponent<PlayerInputController>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 movePosition = moveSpeed * Time.deltaTime *
                (playerInputs != null ? playerInputs.MoveDirection : Vector3.zero);

            transform.position += movePosition;
        }
    }
}