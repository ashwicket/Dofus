using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Version2
{
    public class MoveBottom : MonoBehaviour
    {
        [SerializeField]
        private Transform playerTransform;

        // Update is called once per frame
        private void Update()
        {
            transform.position = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == playerTransform.gameObject)
            {
                Debug.Log("End the game");
            }
        }
    }
}