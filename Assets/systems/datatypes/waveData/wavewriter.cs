using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class wavewriter : MonoBehaviour
{

    public waveData wave;
    public wavesListData wavesList;
    public enemyData enemy;

    public GameObject playerPrefab;
    GameObject player;

    public GameObject deathscreenPrefab;
    GameObject deathscreen;

    public GameObject backgroundPrefab;
    GameObject background;

    public GameObject EventSystem;
    GameObject events;

    public GameObject PauseScreen;
    GameObject pause;
    public string[] enemies = new string[6];


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitFile());
        if (GameObject.FindGameObjectsWithTag("deathscreen").Length > 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("deathscreen"));
        }
        //enemies ---------------------------------------------------------------------------------------------------
        enemy = new enemyData();
        enemy.name = "tumbleweed";
        enemy.HP = 1;
        enemy.speed = 1.8f;
        enemy.XP = 1f;
        enemy.animFrames = 4;
        enemy.frameRate = .3f;
        enemy.size = 3;
        enemies[0] = enemy.SaveToString();

        enemy.name = "blackbird";
        enemy.HP = 7;
        enemy.speed = 1.6f;
        enemy.XP = 1f;
        enemy.animFrames = 2;
        enemy.frameRate = .3f;
        enemy.size = 3;
        enemies[1] = enemy.SaveToString();

        enemy.name = "vulture";
        enemy.HP = 12;
        enemy.speed = 1.7f;
        enemy.XP = 1.25f;
        enemy.animFrames = 1;
        enemy.frameRate = .3f;
        enemy.size = 3;
        enemies[2] = enemy.SaveToString();

        enemy.name = "coyote";
        enemy.HP = 20;
        enemy.speed = 1.7f;
        enemy.XP = 1.4f;
        enemy.animFrames = 2;
        enemy.frameRate = .3f;
        enemy.size = 3;
        enemies[3] = enemy.SaveToString();

        enemy.name = "wolf";
        enemy.HP = 35;
        enemy.speed = 1.8f;
        enemy.XP = 1.5f;
        enemy.animFrames = 2;
        enemy.frameRate = .3f;
        enemy.size = 3;
        enemies[4] = enemy.SaveToString();

        enemy.name = "blackwolf";
        enemy.HP = 40;
        enemy.speed = 1.8f;
        enemy.XP = 2.0f;
        enemy.animFrames = 2;
        enemy.frameRate = .3f;
        enemy.size = 3;
        enemies[5] = enemy.SaveToString();


        //waves -------------------------------------------------------------------------------------


        wavesList = new wavesListData();

        wave = new waveData();
        wave.timeGoal = 60;
        wave.enemies[0] = enemies[0];
        wave.enemies[1] = "";
        wave.ratio = 1f;
        wave.mobCap = 30;
        wave.spawnRate = 3f;
        wave.hazard = "";

        wavesList.waves[0] = wave.SaveToString();

        wave.timeGoal = 120;
        wave.enemies[0] = enemies[0];
        wave.enemies[1] = enemies[1];
        wave.ratio = .5f;
        wave.mobCap = 36;
        wave.spawnRate = 3f;
        wave.hazard = "";

        wavesList.waves[1] = wave.SaveToString();

        wave.timeGoal = 150;
        wave.enemies[0] = enemies[1];
        wave.enemies[1] = "";
        wave.ratio = 1f;
        wave.mobCap = 40;
        wave.spawnRate = 2f;
        wave.hazard = "";

        wavesList.waves[2] = wave.SaveToString();

        wave.timeGoal = 210;
        wave.enemies[0] = enemies[1];
        wave.enemies[1] = enemies[2];
        wave.ratio = .6666f;
        wave.mobCap = 44;
        wave.spawnRate = 3f;
        wave.hazard = "";

        wavesList.waves[3] = wave.SaveToString();

        wave.timeGoal = 270;
        wave.enemies[0] = enemies[2];
        wave.enemies[1] = "";
        wave.ratio = 1f;
        wave.mobCap = 40;
        wave.spawnRate = 2.5f;
        wave.hazard = "";

        wavesList.waves[4] = wave.SaveToString();

        wave.timeGoal = 300;
        wave.enemies[0] = enemies[2];
        wave.enemies[1] = "";
        wave.ratio = 1f;
        wave.mobCap = 44;
        wave.spawnRate = 2.5f;
        wave.hazard = "potshot";

        wavesList.waves[5] = wave.SaveToString();

        wave.timeGoal = 330;
        wave.enemies[0] = enemies[0];
        wave.enemies[1] = "";
        wave.ratio = 1f;
        wave.mobCap = 30;
        wave.spawnRate = 3f;
        wave.hazard = "boss1";

        wavesList.waves[6] = wave.SaveToString();

        wave.timeGoal = 390;
        wave.enemies[0] = enemies[2];
        wave.enemies[1] = enemies[3];
        wave.ratio = .33333f;
        wave.mobCap = 50;
        wave.spawnRate = 2.5f;
        wave.hazard = "";

        wavesList.waves[7] = wave.SaveToString();

        wave.timeGoal = 420;
        wave.enemies[0] = enemies[3];
        wave.enemies[1] = "";
        wave.ratio = 1f;
        wave.mobCap = 50;
        wave.spawnRate = 2.5f;
        wave.hazard = "";

        wavesList.waves[8] = wave.SaveToString();

        wave.timeGoal = 480;
        wave.enemies[0] = enemies[3];
        wave.enemies[1] = enemies[4];
        wave.ratio = .33333f;
        wave.mobCap = 50;
        wave.spawnRate = 3f;
        wave.hazard = "";

        wavesList.waves[9] = wave.SaveToString();

        wave.timeGoal = 510;
        wave.enemies[0] = enemies[4];
        wave.enemies[1] = enemies[5];
        wave.ratio = .66666f;
        wave.mobCap = 50;
        wave.spawnRate = 2.5f;
        wave.hazard = "";

        wavesList.waves[10] = wave.SaveToString();

        wave.timeGoal = 540;
        wave.enemies[0] = enemies[4];
        wave.enemies[1] = enemies[5];
        wave.ratio = .25f;
        wave.mobCap = 50;
        wave.spawnRate = 2.5f;
        wave.hazard = "";

        wavesList.waves[11] = wave.SaveToString();

        wave.timeGoal = 600;
        wave.enemies[0] = enemies[5];
        wave.enemies[1] = "";
        wave.ratio = 1f;
        wave.mobCap = 60;
        wave.spawnRate = 2.5f;
        wave.hazard = "mad_howls";

        wavesList.waves[12] = wave.SaveToString();

        wave.timeGoal = 750;
        wave.enemies[0] = enemies[5];
        wave.enemies[1] = "";
        wave.ratio = 1f;
        wave.mobCap = 40;
        wave.spawnRate = 3f;
        wave.hazard = "boss2";

        wavesList.waves[13] = wave.SaveToString();

        //Debug.Log(wavesList.SaveToString());

        string filePath = Application.persistentDataPath + "/WaveFile.json";
        File.WriteAllText(filePath, wavesList.SaveToString());
        deathscreen = Instantiate(deathscreenPrefab, transform.position, transform.rotation);
        pause = Instantiate(PauseScreen, transform.position, transform.rotation);
        events = Instantiate(EventSystem, transform.position, transform.rotation);
        player = Instantiate(playerPrefab, transform.position, transform.rotation);
        background = Instantiate(backgroundPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }


    IEnumerator WaitFile()
    {
        while (GameObject.FindGameObjectsWithTag("mainScreen").Length != 0)
        {
            yield return null;
        }
    }
}
