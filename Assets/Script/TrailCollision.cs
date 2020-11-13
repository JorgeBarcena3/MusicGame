using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCollision : MonoBehaviour
{

    public TrailRenderer trail;

    public static List<GameObject> enemies;

    // Start is called before the first frame update
    void Awake()
    {
        enemies = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3[] positions = new Vector3[100];


        int points = trail.GetPositions(positions);

        for(int i = 0; i < points; i++)
        {
            foreach(var enemy in enemies)
            {
                EnemyController ec = enemy.GetComponent<EnemyController>();
                if(ec.active && Vector2.Distance( enemy.transform.position, positions[i] ) < 0.5f )
                {
                    ec.restart();
                    return;
                }
            }
        }
        
    }
}
