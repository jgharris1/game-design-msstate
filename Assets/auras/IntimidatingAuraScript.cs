using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntimidatingAuraScript : MonoBehaviour
{
    private float cooldown = 0.2f;
    private float timer = 0.0f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        transform.position = player.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && timer >= cooldown)//will need to be an enemy tag if multiple enemies
        {
            timer = 0.0f;
            //uncomment the below when enemy damage exists
            //damageApply(enemygameobject, damage, statusId, statusLevel, duration);
        }
    }
}
