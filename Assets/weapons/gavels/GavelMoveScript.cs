using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GavelMoveScript : MonoBehaviour
{
    public Vector3 gavelDir;
    public float speed;
    public float fallSpeed;
    public int level;
    public int damage;
    private Vector3 down;
    public GameObject player;//necessary to get direction
    // Start is called before the first frame update
    void Start()
    {
        down = new Vector3(0, -1, 0);
        gavelDir = player.GetComponent<Vector3>();//GetComponent is janky and if there is another Vector3 added to PlayerBaseScript, more specificity will be needed
        gavelDir = Vector3.Normalize(gavelDir);

        if (gavelDir.x == 0.0f)
        {
            gavelDir.x += Random.Range(-.222f, .222f);// after normalizing to 1.0, .222 approximates 10 degrees
        }

        if (gavelDir.y == 0.0f)
        {
            gavelDir.y += Random.Range(-.222f, .222f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x + transform.position.y > 100)//100 is arbitrary, just has to be offscreen
        {
            Destroy(gameObject);
        }

        fallSpeed += 0.02f;
        transform.position = transform.position + (gavelDir * speed * Time.deltaTime) + (down * fallSpeed * Time.deltaTime);
    }

    void Upgrade()
    {
        level += 1;
        switch (level)
        {
            case 1:
                break;
                //need sprite renderer to increase size
            case 2:
                break;
                //need gavel spawning in player to implement count increase
            case 3:
                player.GetComponent<PlayerBaseScript>().changeFR(1, 1250);
                break;
            case 4:
                //another size increase
                damage += 5;
                break;
            case 5:
                //count increase
                break;
            case 6:
                //count increase
                damage += 5;
                break;
            case 7:
                player.GetComponent<PlayerBaseScript>().changeFR(1, 1000);
                break;
            case 8:
                speed += 0.2f;
                damage += 5;
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
