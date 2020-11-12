using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Background : MonoBehaviour
{

    /// <summary>
    /// Start in the background
    /// </summary>
    private List<GameObject> stars = new List<GameObject>();

    /// <summary>
    /// Number of stars
    /// </summary>
    public int startsNumber;

    /// <summary>
    /// Star prefab
    /// </summary>
    public GameObject star;

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
        for (int i = 0; i < startsNumber; i++)
        {
            stars.Add(Instantiate(star, this.transform));
            stars.Last().GetComponent<Star>().setBackgroundManager(this);
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
