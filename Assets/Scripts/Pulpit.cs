using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pulpit : MonoBehaviour
{
    public TextMeshPro destroyTimeText;

    public float minDestroyTime = 4f;
    public float maxDestroyTime = 5f;

    private float destroyTime;

    public float DestroyTime { get { return destroyTime; } }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (destroyTime > 0f)
        {
            destroyTime -= Time.deltaTime;
            destroyTimeText.text = destroyTime.ToString("F2");
        }
        else
            DestroyPulpit();
    }

    public void SpawnPulpit(Vector3 spawnPosition)
    {
        transform.position = spawnPosition;
        destroyTime = Random.Range(minDestroyTime, maxDestroyTime);
        Debug.Log($"Pulpit Time: {destroyTime.ToString("F2")}");
        gameObject.SetActive(true);
    }

    private void DestroyPulpit()
    {
        gameObject.SetActive(false);
    }
}
