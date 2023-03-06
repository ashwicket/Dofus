using UnityEngine;

namespace Version2
{
    public class PulpitTimer : MonoBehaviour
    {
        private PulpitSpawner spawner;

        private readonly float minTime = 4.0f;
        private readonly float maxTime = 5.0f;

        private float pulpitTime;

        private void Awake()
        {
            spawner = FindAnyObjectByType<PulpitSpawner>();
        }

        // Start is called before the first frame update
        void Start()
        {
            ResetTimer();
        }

        // Update is called once per frame
        void Update()
        {
            pulpitTime -= Time.deltaTime;

            if (pulpitTime <= 0f) DestroyPulpit();
        }

        public void ResetTimer()
        {
            pulpitTime = Random.Range(minTime, maxTime);
        }

        private void DestroyPulpit()
        {
            // IsTimerFinished = true;
            //Debug.Log("Destroy Pulpit");
            spawner.DespawnPulpit(this);
        }
    }
}