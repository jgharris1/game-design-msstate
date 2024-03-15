using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainscreenscript : MonoBehaviour
{
    public GameObject backgroundPrefab;
    GameObject background;
    public GameObject loaderPrefab;
    GameObject loader;
    private Vector3 move;
    // Start is called before the first frame update
    void Start()
    {

        if (GameObject.FindGameObjectsWithTag("deathscreen").Length > 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("deathscreen"));
        }
        background = Instantiate(backgroundPrefab);
        move = new Vector3(1.5f, .5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * move;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Begin()
    {
        Destroy(background);
        loader = Instantiate(loaderPrefab);
        Destroy(gameObject);
    }
}
