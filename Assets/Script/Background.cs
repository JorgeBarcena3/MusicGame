using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Background : MonoBehaviour
{

    /// <summary>
    /// Enemies in the background
    /// </summary>
    private List<GameObject> enemies = new List<GameObject>();

    /// <summary>
    /// Number of enemies
    /// </summary>
    public int enemyNumber;

    /// <summary>
    /// Enemy prefab
    /// </summary>
    public GameObject enemyPrefab;

    /// <summary>
    /// Direction of the background
    /// </summary>
    public Vector2 direction;

    /// <summary>
    /// Height limit
    /// </summary>
    public Vector2 height;

    /// <summary>
    /// Width limit
    /// </summary>
    public Vector2 width;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyNumber; i++)
        {
            enemies.Add(Instantiate(enemyPrefab, this.transform));
            enemies.Last().GetComponent<EnemyController>().setBackgroundManager(this);
        }
    }

    /// <summary>
    /// Returns the direction flow
    /// </summary>
    /// <returns></returns>
    public Vector3 getDirection()
    {
        return direction.normalized;
    }
}
