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

    public string[] enemies = new string[7];


    // Start is called before the first frame update
    void Start()
    {
        //enemies ---------------------------------------------------------------------------------------------------
        enemy = new enemyData();
        enemy.name = "tumbleweed";
        enemy.HP = 1;
        enemy.speed = 0.9f;
        enemy.XP = 1f;
        enemies[0] = enemy.SaveToString();

        enemy.name = "blackbird";
        enemy.HP = 7;
        enemy.speed = 0.8f;
        enemy.XP = 1f;
        enemies[1] = enemy.SaveToString();

        enemy.name = "vulture";
        enemy.HP = 16;
        enemy.speed = 0.85f;
        enemy.XP = 1.2f;
        enemies[2] = enemy.SaveToString();

        enemy.name = "outlaw";
        enemy.HP = 750;
        enemy.speed = 0.95f;
        enemy.XP = 500f;
        enemies[3] = enemy.SaveToString();


        //waves -------------------------------------------------------------------------------------


        wavesList = new wavesListData();

        wave = new waveData();
        wave.timeGoal = 60;
        wave.enemies[0] = enemies[0];
        wave.enemies[1] = "";
        wave.ratio = 1f;
        wave.mobCap = 15;
        wave.spawnRate = 3f;
        wave.hazard = "";

        wavesList.waves[0] = wave.SaveToString();

        wave.timeGoal = 120;
        wave.enemies[0] = enemies[0];
        wave.enemies[1] = enemies[1];
        wave.ratio = .5f;
        wave.mobCap = 18;
        wave.spawnRate = 3f;
        wave.hazard = "";

        wavesList.waves[1] = wave.SaveToString();

        wave.timeGoal = 150;
        wave.enemies[0] = enemies[1];
        wave.enemies[1] = "";
        wave.ratio = 1f;
        wave.mobCap = 20;
        wave.spawnRate = 2f;
        wave.hazard = "";

        wavesList.waves[2] = wave.SaveToString();

        wave.timeGoal = 210;
        wave.enemies[0] = enemies[1];
        wave.enemies[1] = enemies[2];
        wave.ratio = .6666f;
        wave.mobCap = 22;
        wave.spawnRate = 3f;
        wave.hazard = "";

        wavesList.waves[3] = wave.SaveToString();

        wave.timeGoal = 270;
        wave.enemies[0] = enemies[2];
        wave.enemies[1] = "";
        wave.ratio = 1f;
        wave.mobCap = 20;
        wave.spawnRate = 2.5f;
        wave.hazard = "";

        wavesList.waves[4] = wave.SaveToString();

        wave.timeGoal = 300;
        wave.enemies[0] = enemies[2];
        wave.enemies[1] = "";
        wave.ratio = 1f;
        wave.mobCap = 22;
        wave.spawnRate = 2.5f;
        wave.hazard = "potshot";

        wavesList.waves[5] = wave.SaveToString();

        wave.timeGoal = 330;
        wave.enemies[0] = enemies[0];
        wave.enemies[1] = "";
        wave.ratio = 1f;
        wave.mobCap = 15;
        wave.spawnRate = 3f;
        wave.hazard = "boss1";

        wavesList.waves[6] = wave.SaveToString();

        //Debug.Log(wavesList.SaveToString());

        string filePath = Application.persistentDataPath + "/WaveFile.json";
        File.WriteAllText(filePath, wavesList.SaveToString());
        Destroy(gameObject);
    }


}
