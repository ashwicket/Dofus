using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameStarted;

    public GameObject pulpitPrefab;
    public int maxPulpits = 2;
    public float spawnInterval = 2.5f;

    private Pulpit[] pulpits;
    private Vector3[] nextPositions;
    private Vector3 nextPulpitPosition;
    private Pulpit nextPulpit;
    private int pulpitIndex;

    private float spawnTime = 0f;


    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = true;
        pulpits = new Pulpit[maxPulpits];

        for (int i = 0; i < maxPulpits; i++)
        {
            pulpits[i] = Instantiate(pulpitPrefab, transform.position, transform.rotation).GetComponent<Pulpit>();
        }
        pulpitIndex = 0;
        nextPulpit = pulpits[0];

        nextPositions = new Vector3[4];
        nextPositions[0] = new Vector3(9f, 0f, 0f);
        nextPositions[1] = new Vector3(0f, 0f, 9f);
        nextPositions[2] = new Vector3(0f, 0f, -9f);
        nextPositions[3] = new Vector3(-9f, 0f, 0f);

        nextPulpitPosition = new Vector3(0f, 0f, 0f);

        spawnTime = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            spawnTime -= Time.deltaTime;
            if (spawnTime <= 0f)
            {
                Debug.Log("Spawn");
                nextPulpit.SpawnPulpit(nextPositions[pulpitIndex]);

                pulpitIndex += 1;
                pulpitIndex = pulpitIndex % maxPulpits;

                nextPulpit = pulpits[pulpitIndex];

                Debug.Log(nextPulpit.transform.position);

                spawnTime = spawnInterval;
            }
        }
    }

    public void StartGame()
    {

    }
}
