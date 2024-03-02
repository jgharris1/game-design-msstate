using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntimidatingAuraScript : MonoBehaviour
{
    public entitybasebehavior Selfdata;
    public Vector3 auraDir;
    private float cooldown = 1.0f;
    private float timer = 0.0f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        auraDir = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        auraDir = new Vector3 (player.transform.position.x, player.transform.position.y, 0);

        Selfdata.targetPos.Set(transform.position.x + auraDir.x, transform.position.y + auraDir.y, 0);
    }
}
