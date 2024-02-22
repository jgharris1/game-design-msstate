using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveScript : MonoBehaviour
{
    public entitybasebehavior Selfdata;
    public Vector3 bulletDir;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 mPosition = Input.mousePosition;
        bulletDir = mPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x + transform.position.y > 100)//100 is arbitrary, just has to be offscreen
        {
            Destroy(gameObject);
        }

        Selfdata.targetPos.Set((transform.position.x + bulletDir.x) * speed, (transform.position.y + bulletDir.y) * speed, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy")//will need to be an enemy tag if multiple enemies
        {
            //uncomment the below when enemy damage exists
            //damageApply(enemygameobject, damage, statusId, statusLevel, duration);
        }
    }
}
