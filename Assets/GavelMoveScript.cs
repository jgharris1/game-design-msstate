using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GavelMoveScript : MonoBehaviour
{
    public entitybasebehavior Selfdata;
    public Vector3 gavelDir;
    public float speed;
    public GameObject player;//necessary to get direction
    // Start is called before the first frame update
    void Start()
    {
        gavelDir = player.GetComponent<Vector3>();//GetComponent is janky and if there is another Vector3 added to PlayerBaseScript, more specificity will be needed
        
        if (gavelDir.x == 0.0f)
        {
            gavelDir.x += Random.Range(-10.0f, 10.0f);
        }

        if (gavelDir.y == 0.0f)
        {
            gavelDir.y += Random.Range(-10.0f, 10.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x + transform.position.y > 100)//100 is arbitrary, just has to be offscreen
        {
            Destroy(gameObject);
        }

        Selfdata.targetPos.Set((transform.position.x + gavelDir.x) * speed, (transform.position.y + gavelDir.y) * speed, 0);
    }
}
