using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundscript : MonoBehaviour
{
    public GameObject[] tile;

    public float horzExtent;
    public int tile1;
    public bool iftile2;
    public int tile2;

    public Vector3 bottomleft;
    public Vector3 topright;

    public Vector3 startpos;

    public Vector2 spacing;

    public float gridwidth;
    public float gridheight;

    public string message;

    public float scaleset;

    public Vector3 scale;

    void Start()
    {
        scale = new Vector3(scaleset, scaleset, scaleset);
        spacing = tile[0].GetComponent<Renderer>().bounds.size;
        for (int i = 0; i < gridheight; i++)
        {
            for(int h = 0; h < gridwidth; h++)
            {
                iftile2 = false;
                tile1 =  Random.Range(0, 4);
                if (Random.Range(0, 1.0f) > 0.66666f)
                {
                    iftile2 = true;
                    tile2 = Random.Range(4, 12);
                }
                GameObject go1 = Instantiate(tile[tile1], new Vector3(startpos.x + h * spacing.x * scaleset, startpos.y + i * spacing.y * scaleset, 5f), Quaternion.identity) as GameObject;
                go1.transform.parent = GameObject.Find("BGTiles").transform;
                go1.transform.localScale = scale;
                if (iftile2)
                {
                    GameObject go2 = Instantiate(tile[tile2], new Vector3(startpos.x + h * spacing.x * scaleset, startpos.y + i * spacing.y * scaleset, 3f), Quaternion.identity) as GameObject;
                    go2.transform.parent = GameObject.Find("BGTiles").transform;
                    go2.transform.localScale = scale;
                }
            }
        }
        var bottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
    }
}
