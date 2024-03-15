using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mad_howls : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float timer = 0f;
    public float spawnTime;
    public float percentage;
    public Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        scale = new Vector3(0f, 0f, 0f);
        sprite = this.GetComponent<SpriteRenderer>();
        sprite.material.color = new Color(0f, 1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        percentage = timer / spawnTime;
        sprite.material.color = new Color(0f, 1f, 1f, 1-percentage);
        scale.Set(percentage * 200, percentage * 200, 0f);
        transform.localScale = scale;
        if (percentage > 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")//will need to be an enemy tag if multiple enemies
        {
            collision.gameObject.SendMessage("mad_howl");
        }
    }
}
