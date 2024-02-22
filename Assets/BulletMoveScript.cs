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
        Selfdata.targetPos.Set((transform.position.x + bulletDir.x) * speed, (transform.position.y + bulletDir.y) * speed, 0);
    }
}
