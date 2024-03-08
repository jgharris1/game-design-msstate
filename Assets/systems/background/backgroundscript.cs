using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundscript : MonoBehaviour
{
    public GameObject[] tile;
    private List<GameObject> children = new List<GameObject>();
    private List<GameObject> tempchildren = new List<GameObject>();

    private int tile1;
    private bool iftile2;
    private int tile2;

    public Vector3 bottomLeft;
    public Vector3 topRight;

    private Vector2 spacing;

    public float scaleset;

    private Vector3 scale;

    private Vector3 constminvec;
    private Vector3 constmaxvec;

    public Vector3 curmax;
    public Vector3 curmin;
    public Vector3 innercurmax;
    public Vector3 innercurmin;
    public Vector3 newcurmax;
    public Vector3 newcurmin;

    public float tile2chance;

    void Start()
    {
        constminvec = new Vector3(0, 0, 0);
        constmaxvec = new Vector3(Screen.width, Screen.height, 0);
        bottomLeft = Camera.main.ScreenToWorldPoint(constminvec);
        topRight = Camera.main.ScreenToWorldPoint(constmaxvec);
        newcurmin = new Vector3(0f, 0f, 0f);
        newcurmax = new Vector3(0f, 0f, 0f);

        scale = new Vector3(scaleset, scaleset, scaleset);
        spacing = tile[0].GetComponent<Renderer>().bounds.size;

        curmin = new Vector3(bottomLeft.x + -1 * spacing.x * scaleset, bottomLeft.y + -1 * spacing.y * scaleset, 0);
        curmax = new Vector3(bottomLeft.x + -2 * spacing.x * scaleset, bottomLeft.y + -2 * spacing.y * scaleset, 0);
        innercurmin = new Vector3(bottomLeft.x, bottomLeft.y, 0);
        while (curmax.y < topRight.y + spacing.y * scaleset)
        {
            curmax.Set(bottomLeft.x + -2 * spacing.x * scaleset, curmax.y + spacing.y * scaleset, 0);
            while (curmax.x < topRight.x + spacing.x * scaleset)
            {
                tile1 = Random.Range(0, 4);
                if (Random.Range(0, 1.0f) > (1-tile2chance))
                {
                    iftile2 = true;
                    tile2 = Random.Range(4, 12);
                }
                GameObject go1 = Instantiate(tile[tile1], new Vector3(curmax.x + spacing.x * scaleset, curmax.y, 5f), Quaternion.identity) as GameObject;
                go1.transform.parent = GameObject.Find("BGTiles").transform;
                go1.transform.localScale = scale;
                children.Add(go1);
                if (iftile2)
                {
                    GameObject go2 = Instantiate(tile[tile2], new Vector3(curmax.x + spacing.x * scaleset, curmax.y, 3f), Quaternion.identity) as GameObject;
                    go2.transform.parent = GameObject.Find("BGTiles").transform;
                    go2.transform.localScale = scale;
                    children.Add(go2);
                    iftile2 = false;
                }
                curmax = go1.transform.position;
            }
        }
        innercurmax = new Vector3(curmax.x - spacing.x * scaleset, curmax.y + spacing.y * scaleset, 0);
        
    }

    void Update()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(constminvec);
        topRight = Camera.main.ScreenToWorldPoint(constmaxvec);
        //----------------------------------------------------------------------------------------------------------------
        //adds
        //----------------------------------------------------------------------------------------------------------------
        //add right
        if (topRight.x > curmax.x)
        {
            newcurmax.Set(curmax.x + spacing.x * scaleset, curmax.y - .001f, 0f);
            innercurmax.Set(curmax.x, innercurmax.y, 0f);
            curmax.Set(newcurmax.x, curmin.y + -1 * spacing.y * scaleset, 0f);
            while (curmax.y < newcurmax.y)
            {
                tile1 = Random.Range(0, 4);
                if (Random.Range(0, 1.0f) > (1 - tile2chance))
                {
                    iftile2 = true;
                    tile2 = Random.Range(4, 12);
                }
                GameObject go1 = Instantiate(tile[tile1], new Vector3(curmax.x, curmax.y + spacing.y * scaleset, 5f), Quaternion.identity) as GameObject;
                go1.transform.parent = GameObject.Find("BGTiles").transform;
                go1.transform.localScale = scale;
                children.Add(go1);
                if (iftile2)
                {
                    GameObject go2 = Instantiate(tile[tile2], new Vector3(curmax.x, curmax.y + spacing.y * scaleset, 3f), Quaternion.identity) as GameObject;
                    go2.transform.parent = GameObject.Find("BGTiles").transform;
                    go2.transform.localScale = scale;
                    children.Add(go2);
                    iftile2 = false;
                }
                curmax = go1.transform.position;
            }
        }
        //add left
        if (bottomLeft.x < curmin.x)
        {
            newcurmin.Set(curmin.x - spacing.x * scaleset, curmin.y + .001f, 0f);
            innercurmin.Set(curmin.x, innercurmin.y, 0f);
            curmin.Set(newcurmin.x, curmax.y + 1 * spacing.y * scaleset, 0f);
            while (curmin.y > newcurmin.y)
            {
                tile1 = Random.Range(0, 4);
                if (Random.Range(0, 1.0f) > (1 - tile2chance))
                {
                    iftile2 = true;
                    tile2 = Random.Range(4, 12);
                }
                GameObject go1 = Instantiate(tile[tile1], new Vector3(curmin.x, curmin.y - spacing.y * scaleset, 5f), Quaternion.identity) as GameObject;
                go1.transform.parent = GameObject.Find("BGTiles").transform;
                go1.transform.localScale = scale;
                children.Add(go1);
                if (iftile2)
                {
                    GameObject go2 = Instantiate(tile[tile2], new Vector3(curmin.x, curmin.y - spacing.y * scaleset, 3f), Quaternion.identity) as GameObject;
                    go2.transform.parent = GameObject.Find("BGTiles").transform;
                    go2.transform.localScale = scale;
                    children.Add(go2);
                    iftile2 = false;
                }
                curmin = go1.transform.position;
            }
        }
        //add top
        if (topRight.y > curmax.y)
        {
            newcurmax.Set(curmax.x - .001f, curmax.y + spacing.y * scaleset, 0f);
            innercurmax.Set(innercurmax.x, curmax.y, 0f);
            curmax.Set(curmin.x + -1 * spacing.x * scaleset, newcurmax.y, 0f);
            while (curmax.x < newcurmax.x)
            {
                tile1 = Random.Range(0, 4);
                if (Random.Range(0, 1.0f) > (1 - tile2chance))
                {
                    iftile2 = true;
                    tile2 = Random.Range(4, 12);
                }
                GameObject go1 = Instantiate(tile[tile1], new Vector3(curmax.x + spacing.x * scaleset, curmax.y, 5f), Quaternion.identity) as GameObject;
                go1.transform.parent = GameObject.Find("BGTiles").transform;
                go1.transform.localScale = scale;
                children.Add(go1);
                if (iftile2)
                {
                    GameObject go2 = Instantiate(tile[tile2], new Vector3(curmax.x + spacing.x * scaleset, curmax.y, 3f), Quaternion.identity) as GameObject;
                    go2.transform.parent = GameObject.Find("BGTiles").transform;
                    go2.transform.localScale = scale;
                    children.Add(go2);
                    iftile2 = false;
                }
                curmax = go1.transform.position;
            }
        }
        //add bottom
        if (bottomLeft.y < curmin.y)
        {
            newcurmin.Set(curmin.x + .001f, curmin.y - spacing.x * scaleset, 0f);
            innercurmin.Set(innercurmin.x, curmin.y, 0f);
            curmin.Set(curmax.x + 1 * spacing.x * scaleset, newcurmin.y, 0f);
            while (curmin.x > newcurmin.x)
            {
                tile1 = Random.Range(0, 4);
                if (Random.Range(0, 1.0f) > (1 - tile2chance))
                {
                    iftile2 = true;
                    tile2 = Random.Range(4, 12);
                }
                GameObject go1 = Instantiate(tile[tile1], new Vector3(curmin.x - spacing.x * scaleset, curmin.y, 5f), Quaternion.identity) as GameObject;
                go1.transform.parent = GameObject.Find("BGTiles").transform;
                go1.transform.localScale = scale;
                children.Add(go1);
                if (iftile2)
                {
                    GameObject go2 = Instantiate(tile[tile2], new Vector3(curmin.x - spacing.x * scaleset, curmin.y, 3f), Quaternion.identity) as GameObject;
                    go2.transform.parent = GameObject.Find("BGTiles").transform;
                    go2.transform.localScale = scale;
                    children.Add(go2);
                    iftile2 = false;
                }
                curmin = go1.transform.position;
            }
        }
        //----------------------------------------------------------------------------------------------------------------
        //removes
        //----------------------------------------------------------------------------------------------------------------
        //remove right
        if (topRight.x < innercurmax.x)
        {
            foreach (GameObject child in children)
            {
                if (child.transform.position.x + .001 > curmax.x)
                {
                    tempchildren.Add(child);
                }
            }
            foreach (GameObject child in tempchildren)
            {
                children.Remove(child);
            }
            foreach (GameObject child in tempchildren)
            {
                Destroy(child);
            }
            curmax.Set(innercurmax.x, curmax.y, 0f);
            innercurmax.Set(innercurmax.x + -1 * spacing.x * scaleset, innercurmax.y, 0f);
        }
        //remove left
        if (bottomLeft.x > innercurmin.x)
        {
            foreach (GameObject child in children)
            {
                if (child.transform.position.x - .001 < curmin.x)
                {
                    tempchildren.Add(child);
                }
            }
            foreach (GameObject child in tempchildren)
            {
                children.Remove(child);
            }
            foreach (GameObject child in tempchildren)
            {
                Destroy(child);
            }
            curmin.Set(innercurmin.x, curmin.y, 0f);
            innercurmin.Set(innercurmin.x + 1 * spacing.x * scaleset, innercurmin.y, 0f);
        }
        //remove top
        if (topRight.y < innercurmax.y)
        {
            foreach (GameObject child in children)
            {
                if (child.transform.position.y + .001 > curmax.y)
                {
                    tempchildren.Add(child);
                }
            }
            foreach (GameObject child in tempchildren)
            {
                children.Remove(child);
            }
            foreach (GameObject child in tempchildren)
            {
                Destroy(child);
            }
            curmax.Set(curmax.x, innercurmax.y, 0f);
            innercurmax.Set(innercurmax.x, innercurmax.y + -1 * spacing.y * scaleset, 0f);
        }
        //remove bottom
        if (bottomLeft.y > innercurmin.y)
        {
            foreach (GameObject child in children)
            {
                if (child.transform.position.y - .001 < curmin.y)
                {
                    tempchildren.Add(child);
                }
            }
            foreach (GameObject child in tempchildren)
            {
                children.Remove(child);
            }
            foreach (GameObject child in tempchildren)
            {
                Destroy(child);
            }
            curmin.Set(curmin.x, innercurmin.y, 0f);
            innercurmin.Set(innercurmin.x, innercurmin.y + 1 * spacing.y * scaleset, 0f);
        }
    }
}
