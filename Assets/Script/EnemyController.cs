using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Transform target;

    [Range(0, 10)]
    public float speed = 5;

    [Range(0, 2)]
    public float rotationSpeed = 1;

    private SpriteRenderer sp;

    public bool active;

    /// <summary>
    /// Background manager
    /// </summary>
    private Background bg;

    void Start()
    {
        TrailCollision.enemies.Add(this.gameObject);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        sp = GetComponent<SpriteRenderer>();
        sp.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f),1);
        active = true;

    }

    public void setBackgroundManager(Background _bg)
    {
        bg = _bg;
        restartPosition();

    }

    // Update is called once per frame
    void Update()
    {

        if(active)
        {
            Vector2 distance = target.transform.position - transform.position;
            Vector2 movement = distance.normalized * speed * Time.deltaTime;

            this.transform.position += new Vector3(movement.x, movement.y);

            transform.Rotate (new Vector3(0,0,1), rotationSpeed);
        }

    }

    public void restart()
    {
        active = false;
        StartCoroutine(disappear());
    }

    public void restartPosition()
    {
        Vector2 newPosition;


        newPosition.y = Random.Range(0,2) == 0 ? Random.Range(bg.height.y, bg.height.y + 10) : Random.Range(bg.height.x, bg.height.x - 10); ;
        newPosition.x = Random.Range(0,2) == 0 ? Random.Range(bg.width.y, bg.width.y + 10) : Random.Range(bg.width.x, bg.width.x - 10); ;
        

        transform.position = newPosition;
    }

    IEnumerator disappear()
    {

        while(sp.color.a > 0)
        {
            sp.color += new Color(0,0,0,-0.01f);
            yield return null;

        }

        sp.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f),1);
        speed = Random.Range(1,7);
        rotationSpeed = Random.Range(5, 20);
        restartPosition();
        active = true;
    }
}
