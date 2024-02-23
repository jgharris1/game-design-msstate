using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseScript : MonoBehaviour
{

    public Vector3 playerDir;
    public float cooldown;
    private float timer = 0.0f;
    public int health;
    public float entitySpeed;
    public GameObject bulletPrefab;
    GameObject bullet;
    public damageData attack;
    public GameObject deathCam;
    // Start is called before the first frame update
    void Start()
    {
        playerDir = new Vector3(0.0f, 0.0f, 0.0f);
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > cooldown)
        {
            bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            timer = 0.0f;
        }
        playerDir.Set(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            playerDir.Set(playerDir.x, playerDir.y + 1, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerDir.Set(playerDir.x - 1, playerDir.y, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerDir.Set(playerDir.x, playerDir.y - 1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerDir.Set(playerDir.x + 1, playerDir.y, 0);
        }
        //Selfdata.targetPos.Set(transform.position.x + playerDir.x, transform.position.y + playerDir.y, 0);
        if ((Mathf.Abs(playerDir.x) + Mathf.Abs(playerDir.y)) != 0)
        {
            playerDir = Vector3.Normalize(playerDir);
            transform.position = transform.position + (playerDir * entitySpeed) * Time.deltaTime;
        }
    }

    public void damageApply(string attackStr)//, int statusId = 0, int statusLevel = 0, float duration = 0)
    {
        attack = JsonUtility.FromJson<damageData>(attackStr);
        health -= attack.damage;
        if (health <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
