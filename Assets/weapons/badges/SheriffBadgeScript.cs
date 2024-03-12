using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheriffBadgeScript : MonoBehaviour
{
    public Vector3 badgeDir;
    public float speed;
    public float startPosOffset;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        badgeDir = player.GetComponent<Vector3>();//GetComponent is janky and if there is another Vector3 added to PlayerBaseScript, more specificity will be needed

        if (badgeDir.x == 0.0f)
        {
            badgeDir.x += startPosOffset;
        }

        if (badgeDir.y == 0.0f)
        {
            badgeDir.y += startPosOffset;
        }

        badgeDir = Vector3.Normalize(badgeDir);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x + transform.position.y > 100)//100 is arbitrary, just has to be offscreen
        {
            Destroy(gameObject);
        }

        transform.position = transform.position + (badgeDir * speed * Time.deltaTime);
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
