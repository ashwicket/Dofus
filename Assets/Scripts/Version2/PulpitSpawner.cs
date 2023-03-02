using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Version2
{
    public class PulpitSpawner : MonoBehaviour
    {
        private float spawnInterval = 2.5f;
        [SerializeField]
        private GameObject pulpitPrefab;

        private readonly Queue<PulpitTimer> pulpitQueue = new();

        private Vector3[] spawnPositions;
        private Vector3 nextSpawnPosition;

        // Start is called before the first frame update
        void Start()
        {
            spawnPositions = new Vector3[4];
            spawnPositions[0] = new Vector3(0.0f, 0.0f, 9.0f);
            spawnPositions[1] = new Vector3(0.0f, 0.0f, -9.0f);
            spawnPositions[2] = new Vector3(9.0f, 0.0f, 0.0f);
            spawnPositions[3] = new Vector3(-9.0f, 0.0f, 0.0f);

            nextSpawnPosition = transform.position;
            Debug.Log(pulpitQueue.Count > 0);
            SpawnPulpit();
        }

        // Update is called once per frame
        void Update()
        {
            spawnInterval -= Time.deltaTime;

            if (spawnInterval <= 0f)
                SpawnPulpit();
        }

        public void SpawnPulpit()
        {
            spawnInterval = 2.5f;
            if (pulpitQueue.Count > 0)
            {
                PulpitTimer currentPulpit = pulpitQueue.Dequeue();
                currentPulpit.transform.position = nextSpawnPosition;
                currentPulpit.ResetTimer();
                currentPulpit.gameObject.SetActive(true);
            }
            else
                Instantiate(pulpitPrefab, nextSpawnPosition, transform.rotation);

            nextSpawnPosition += spawnPositions[Random.Range(0, 4)];
        }

        public void DespawnPulpit(PulpitTimer currentPulpit)
        {
            pulpitQueue.Enqueue(currentPulpit);
            currentPulpit.gameObject.SetActive(false);
        }
    }
}