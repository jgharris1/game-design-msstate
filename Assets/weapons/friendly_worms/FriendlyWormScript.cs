using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyWormScript : MonoBehaviour
{
    public Vector3 wormDir;
    public float speed;
    public int damage;
    public int level;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        wormDir = new Vector3(-1.0f, Random.Range(-10.0f, 10.0f), 0.0f);//probably going to do a little more with this, may randomize
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

    void Upgrade()
    {
        level += 1;
        switch (level)
        {
            case 1:
                //increase size
                break;
            case 2:
                damage += 5;
                break;
            case 3:
                //size increase
                break;
            case 4:
                player.GetComponent<PlayerBaseScript>().changeFR(5, 4750);
                break;
            case 5:
                //size increase;
                break;
            case 6:
                damage += 5;
                break;
            case 7:
                damage += 5;
                break;
            case 8:
                //size
                break;
            case 9://infinite upgrade
                damage += 5;
                level -= 1;
                break;
            default:
                break;//shouldn't happen; good practice
        }
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
