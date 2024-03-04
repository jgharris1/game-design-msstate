using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyWormScript : MonoBehaviour
{
    public Vector3 wormDir;
    public float speed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        wormDir = new Vector3(-1.0f, 0.0f, 0.0f);//probably going to do a little more with this, may randomize
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x + transform.position.y > 100)//100 is arbitrary, just has to be offscreen
        {
            Destroy(gameObject);
        }

        transform.position = transform.position + (wormDir * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")//will need to be an enemy tag if multiple enemies
        {
            //uncomment the below when enemy damage exists
            //damageApply(enemygameobject, damage, statusId, statusLevel, duration);
        }
    }
}
