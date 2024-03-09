using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteScript : MonoBehaviour
{
    public Vector3 dynamiteDir;
    public float speed;
    private bool exploded;
    public int level;
    public int damage;
    public float explosionSize;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        dynamiteDir = player.GetComponent<Vector3>();

        dynamiteDir = Vector3.Normalize(dynamiteDir);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x + transform.position.y > 10)//10 is arbitrary, should be about a quarter screen
        {
            exploded = true;
            //do sprite change
        }
    }

    void Upgrade()
    {
        level += 1;
        switch (level)
        {
            case 1:
                damage += 10;
                break;
            case 2:
                explosionSize *= 1.1f;
                break;
            case 3:
                damage += 10;
                break;
            case 4:
                explosionSize *= 1.090909f;
                break;
            case 5:
                damage += 10;
                break;
            case 6:
                explosionSize *= 1.083333f;
                break;
            case 7:
                damage += 10;
                break;
            case 8:
                player.GetComponent<PlayerBaseScript>().changeFR(6, 9000);
                break;
            case 9://infinite upgrade
                //call for player choice/UI
                level -= 1;
                break;
            default:
                break;//shouldn't happen; good practice
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && exploded)
        {
            //uncomment the below when enemy damage exists
            //damageApply(enemygameobject, damage, statusId, statusLevel, duration);
        }
    }
}
