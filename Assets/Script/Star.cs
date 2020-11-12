using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    /// <summary>
    /// Star speed
    /// </summary>
    private float speed;

    /// <summary>
    /// Background manager
    /// </summary>
    private Background bg;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.05f, 0.25f);
    }

    public void setBackgroundManager(Background _bg)
    {
        bg = _bg;
        transform.position = new Vector3(Random.Range(bg.width.x, bg.width.y), bg.height.y, 0);

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < bg.height.x)
        {
            transform.position = new Vector3(Random.Range(bg.width.x, bg.width.y), bg.height.y, 0);

        }
        else
            transform.position = transform.position + (bg.getDirection() * speed * 0.15f);

    }
}
