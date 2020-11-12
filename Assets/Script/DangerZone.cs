using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    /// <summary>
    /// Direction of launch
    /// </summary>
    private Vector2 launchDirection;

    /// <summary>
    /// Force
    /// </summary>
    [Range(0, 100)]
    public float ejectForce = 1;

    /// <summary>
    /// When something start to collide the zone
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":

                launchDirection = (Vector3.zero - collision.transform.position).normalized;
                break;

            default:
                break;

        }

    }

    /// <summary>
    /// When something is inside the zone
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":

                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (rb)
                    rb.AddForce(launchDirection * ejectForce);

                break;

            default:
                break;

        }
    }

    /// <summary>
    /// When something exit the zone
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":

                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (rb)
                    rb.AddForce(launchDirection * ejectForce * 2);
                break;

            default:
                break;

        }
    }

}
