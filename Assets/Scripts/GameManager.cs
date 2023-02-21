using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public CanvasGroup startUI;
    public CanvasGroup gameUI;
    public CanvasGroup endUI;

    public bool gameStarted;
    public int gameScore;

    public Player player;
    public GameObject pulpitPrefab;
    public TextMeshProUGUI scoreText;
    public int maxPulpits = 2;
    public float spawnInterval = 2.5f;

    private Pulpit[] pulpits;
    private Vector3[] nextPositions;
    private Vector3 nextPulpitPosition;
    private Pulpit nextPulpit;
    private int pulpitIndex;

    private float spawnTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        pulpits = new Pulpit[maxPulpits];

        for (int i = 0; i < maxPulpits; i++)
        {
            pulpits[i] = Instantiate(pulpitPrefab, transform.position, transform.rotation).GetComponent<Pulpit>();
        }
        pulpitIndex = 0;
        nextPulpit = pulpits[pulpitIndex];

        nextPositions = new Vector3[4];
        nextPositions[0] = new Vector3(9.2f, 0f, 0f);
        nextPositions[1] = new Vector3(0f, 0f, 9.2f);
        nextPositions[2] = new Vector3(0f, 0f, -9.2f);
        nextPositions[3] = new Vector3(-9.2f, 0f, 0f);

        nextPulpitPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            spawnTime -= Time.deltaTime;
            if (spawnTime <= 0f)
            {
                nextPulpit.SpawnPulpit(nextPulpitPosition);

                pulpitIndex += 1;
                pulpitIndex %= maxPulpits;

                nextPulpit = pulpits[pulpitIndex];
                nextPulpitPosition += nextPositions[Random.Range(0, 4)];

                //Debug.Log(nextPulpit.transform.position);

                spawnTime = spawnInterval;
            }
        }
    }

    public void StartGame()
    {
        startUI.alpha = 0f;
        startUI.blocksRaycasts = false;

        gameScore = 0;
        scoreText.text = $"Score: {gameScore}";
        gameUI.alpha = 1f;

        player.enabled = true;
        gameStarted = true;
    }

    public void EndGame()
    {
        endUI.alpha = 1f;
        endUI.blocksRaycasts = true;

        player.enabled = false;
        gameStarted = false;
    }

    public void RestartGame()
    {
        endUI.alpha = 0f;
        endUI.blocksRaycasts = false;

        foreach (Pulpit pulpit in pulpits)
            pulpit.gameObject.SetActive(false);
        pulpitIndex = 0;
        nextPulpit = pulpits[pulpitIndex];
        spawnTime = 0f;
        nextPulpitPosition = new Vector3(0f, 0f, 0f);

        gameScore = 0;
        scoreText.text = $"Score: {gameScore}";
        gameUI.alpha = 1f;

        player.enabled = true;
        gameStarted = true;
    }

    public void UpdateScore()
    {
        gameScore += 1;
        scoreText.text = $"Score: {gameScore}";
    }
}
