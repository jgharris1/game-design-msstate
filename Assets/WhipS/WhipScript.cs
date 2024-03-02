using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipScript : MonoBehaviour
{
    public entitybasebehavior Selfdata;
    public Vector3 whipDir;
    public GameObject player;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        whipDir = player.GetComponent<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= .1)//destroys self on time
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy")//will need to be an enemy tag if multiple enemies
        {
            //uncomment the below when enemy damage exists
            //damageApply(enemygameobject, damage, statusId, statusLevel, duration);
            Destroy(gameObject);//prevents repeated damage
        }
    }
}
