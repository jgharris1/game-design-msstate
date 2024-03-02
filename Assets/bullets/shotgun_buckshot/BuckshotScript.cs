using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuckshotScript : MonoBehaviour
{
    public entitybasebehavior Selfdata;
    public Vector3 buckshotDir;
    public float speed;
    public float startPosOffset;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        buckshotDir = player.GetComponent<Vector3>();//GetComponent is janky and if there is another Vector3 added to PlayerBaseScript, more specificity will be needed

        if (buckshotDir.x == 0.0f)
        {
            buckshotDir.x += startPosOffset;
        }

        if (buckshotDir.y == 0.0f)
        {
            buckshotDir.y += startPosOffset;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x + transform.position.y > 100)//100 is arbitrary, just has to be offscreen
        {
            Destroy(gameObject);
        }

        Selfdata.targetPos.Set((transform.position.x + buckshotDir.x) * speed, (transform.position.y + buckshotDir.y) * speed, 0);
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
