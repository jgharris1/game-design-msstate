using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerscript : MonoBehaviour
{
    public int spawnLimit;
    public float spawnDistMin;
    public float spawnDistMax;
    public float spawnRate;
    private float spawnTimer;
    private float timeRem;
    public Vector3 parentLoc;
    public string currentEnemy;
    public Vector3 dirVec;
    public GameObject enemyPrefab;
    GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        dirVec = new Vector3(0f, 0f, 0f);
        spawnTimer = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        parentLoc = transform.parent.transform.position;
        timeRem -= Time.deltaTime;
        spawnTimer -= Time.deltaTime;
        if (timeRem < 0)
        {
            nextWave();
        }
        if (spawnTimer < 0)
        {
            spawnEnemy();
        }
    }

    public void nextWave()
    {
        timeRem = 20f;
        Debug.Log("next wave");
    }

    public void spawnEnemy()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < spawnLimit)
        {
            spawnTimer = spawnRate;
            dirVec.Set(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
            dirVec = Vector3.Normalize(dirVec);
            enemy = Instantiate(enemyPrefab, transform.parent.position + (dirVec * Random.Range(spawnDistMin, spawnDistMax)), transform.parent.rotation);
            enemy.SendMessage("setData", "replace with data json");
        }
    }
}
