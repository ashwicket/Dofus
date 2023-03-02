using UnityEngine;
using TMPro;

namespace Version1
{
    public class Pulpit : MonoBehaviour
    {
        public TextMeshPro destroyTimeText;

        public float minDestroyTime = 4f;
        public float maxDestroyTime = 5f;

        private GameManager gameManager;

        private float destroyTime;
        private bool scoreCounted;
        private readonly string playerTag = "Player";

        private void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        // Start is called before the first frame update
        void Start()
        {
            scoreCounted = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (gameManager.gameStarted)
            {
                if (destroyTime > 0f)
                {
                    destroyTime -= Time.deltaTime;
                    destroyTimeText.text = destroyTime.ToString("F2");
                }
                else
                    gameObject.SetActive(false);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!scoreCounted)
            {
                if (collision.gameObject.CompareTag(playerTag))
                {
                    gameManager.UpdateScore();
                    scoreCounted = true;
                }
            }
        }

        public void SpawnPulpit(Vector3 spawnPosition)
        {
            scoreCounted = false;
            transform.position = spawnPosition;
            destroyTime = Random.Range(minDestroyTime, maxDestroyTime);
            destroyTimeText.text = destroyTime.ToString("F2");
            gameObject.SetActive(true);
        }
    }
}