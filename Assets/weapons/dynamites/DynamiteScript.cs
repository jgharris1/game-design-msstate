using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteScript : MonoBehaviour
{
    public Vector3 dynamiteDir;
    public float speed;
    private bool exploded;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && exploded)
        {
            //uncomment the below when enemy damage exists
            //damageApply(enemygameobject, damage, statusId, statusLevel, duration);
        }
    }
}
