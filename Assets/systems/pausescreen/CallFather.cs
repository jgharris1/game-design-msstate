using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallFather : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.parent.SendMessage("NotQuiteStart");
        //NotQuiteStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
