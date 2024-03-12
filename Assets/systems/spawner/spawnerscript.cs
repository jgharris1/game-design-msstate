using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerscript : MonoBehaviour
{
    public float spawnDistMin;
    public float spawnDistMax;
    public float spawnTimer;
    public float waveTimer;
    public float hazardTimer;
    public float hazardRate;
    public Vector3 parentLoc;
    public Vector3 dirVec;
    public GameObject enemyPrefab;
    public GameObject potshotPrefab;
    public GameObject howlPrefab;
    public GameObject boss1Prefab;
    public GameObject boss2Prefab;
    GameObject enemy;
    public int randCheck;

    public int waveid = 0;
    public int spawnLimit;
    public float spawnRate;
    public float waveGoal;
    public string[] enemies = new string[2];
    public float ratio;
    public string hazard;

    public int enemycnt;
    public wavesListData wavesList;
    public waveData wave;
    public bool pause;

    public bool potshot;
    public bool howl;
    public float DMGBonus;
    // Start is called before the first frame update
    void Start()
    {
        dirVec = new Vector3(0f, 0f, 0f);
        spawnTimer = spawnRate;
        StartCoroutine(WaitFile());
        wavesList = new wavesListData();
        wave = new waveData();
        wavesList = JsonUtility.FromJson<wavesListData>(System.IO.File.ReadAllText(Application.persistentDataPath + "/WaveFile.json"));
        nextWave();
    }


    // Update is called once per frame
    void Update()
    {
        enemycnt = GameObject.FindGameObjectsWithTag("Enemy").Length;
        parentLoc = transform.parent.transform.position;
        if (!pause)
        {
            waveTimer += Time.deltaTime;
        }
        spawnTimer -= Time.deltaTime;
        if (potshot)
        {
            hazardTimer += Time.deltaTime;
            if (hazardTimer >= hazardRate)
            {
                PotShot();
                hazardTimer = 0f;
            }
        }
        if (howl)
        {
            hazardTimer += Time.deltaTime;
            if (hazardTimer >= hazardRate)
            {
                Howl();
                hazardTimer = 0f;
            }
        }
        if (waveTimer > waveGoal)
        {
            if (waveTimer >= 750)
            {
                transform.parent.SendMessage("InstDeath");
                waveGoal += waveGoal;
            }
            else
            {
                nextWave();
            }
        }
        if (spawnTimer < 0)
        {
            spawnEnemy();
        }
    }

    public void nextWave()
    {
        hazardDisable();
        wave = JsonUtility.FromJson<waveData>(wavesList.waves[waveid]);
        waveGoal = wave.timeGoal;
        spawnLimit = wave.mobCap;
        spawnRate = wave.spawnRate;
        ratio = wave.ratio;
        hazard = wave.hazard;
        enemies = wave.enemies;
        waveid += 1;
        if (hazard.Length > 0)
        {
            if (hazard == "potshot")
            {
                potshot = true;
            }
            else if (hazard == "mad_howls")
            {
                howl = true;
            }
            else if (hazard == "boss1")
            {
                dirVec.Set(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
                dirVec = Vector3.Normalize(dirVec);
                Instantiate(boss1Prefab, transform.parent.position + (dirVec * Random.Range(spawnDistMin, spawnDistMax)), transform.parent.rotation);
            }
            else if (hazard == "boss2")
            {
                dirVec.Set(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
                dirVec = Vector3.Normalize(dirVec);
                Instantiate(boss2Prefab, transform.parent.position + (dirVec * Random.Range(spawnDistMin, spawnDistMax)), transform.parent.rotation);
            }
        }
    }

    public void spawnEnemy()
    {
        for (int i = 0; i < Random.Range(1, spawnLimit / 2); i ++)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < spawnLimit)
            {
                spawnTimer = spawnRate;
                dirVec.Set(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
                dirVec = Vector3.Normalize(dirVec);
                randCheck = 0;
                if (Random.Range(0f, 1f) > ratio)
                {
                    randCheck = 1;
                }
                enemy = Instantiate(enemyPrefab, transform.parent.position + (dirVec * Random.Range(spawnDistMin, spawnDistMax)), transform.parent.rotation);
                enemy.SendMessage("setData", enemies[randCheck]); 
                enemy.SendMessage("setDMGBonus", DMGBonus);
            }
        }
    }

    IEnumerator WaitFile()
    {
        while(GameObject.FindGameObjectsWithTag("PauseTillGone").Length != 0)
        {
            yield return null;
        }
    }

    public void hazardDisable()
    {
        potshot = false;
        howl = false;
    }

    public void PotShot()
    {
        Instantiate(potshotPrefab);
    }

    public void Howl()
    {
        dirVec.Set(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
        dirVec = Vector3.Normalize(dirVec);
        Instantiate(howlPrefab, transform.parent.position + (dirVec * Random.Range(spawnDistMin, spawnDistMax)), transform.parent.rotation);
    }

    public void setDMGBonus(float Bonus)
    {
        DMGBonus += Bonus;
    }
}
