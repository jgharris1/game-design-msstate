using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warningscript : MonoBehaviour
{
    public float timer;
    public LineRenderer line;
    public float maxalpha;
    public float spawntime;
    public float curalpha;
    public Color color;
    public Vector3[] points = new Vector3[2]; 
    public Vector3 dirVec;
    public float spawnDistMin;
    public float spawnDistMax;
    public bool in_out = true;
    public GameObject shotPrefab;
    public potshotscript shot;
    // Start is called before the first frame update
    void Start()
    {
        dirVec = new Vector3(0f, 0f, 0f);
        timer = 0f;
        line = this.GetComponent<LineRenderer>();
        line.material.color = new Color(0.5f, 0.125f, 0.125f, 0.0f);
        dirVec.Set(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
        dirVec = Vector3.Normalize(dirVec);
        dirVec *= Random.Range(spawnDistMin, spawnDistMax);
        points[0] = GameObject.FindGameObjectWithTag("Player").transform.position + dirVec;
        points[1] = GameObject.FindGameObjectWithTag("Player").transform.position - dirVec;
        line.SetPositions(points);
        //this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (in_out)
        {
            curalpha = timer / (spawntime / 2) * maxalpha;
        }
        else
        {
            curalpha = maxalpha - timer / (spawntime / 2) * maxalpha;
        }
        if (curalpha > maxalpha)
        {
            in_out = false;
            timer = 0f;
        }
        if (curalpha < 0)
        {
            shot = Instantiate(shotPrefab, points[0], transform.rotation).GetComponent<potshotscript>();
            shot.setpoint(points[1]);
            Destroy(gameObject);
        }
        line.material.color = new Color(0.5f, 0.125f, 0.125f, curalpha);
    }
}
