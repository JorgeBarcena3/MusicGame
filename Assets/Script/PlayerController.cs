using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Movement of the player
/// </summary>
public class PlayerController : MonoBehaviour
{

    public FloatingJoystick variableJoystick;

    /// <summary>
    /// Speed of the player
    /// </summary>
    [Range(0, 50)]
    public float speed = 1;

    /// <summary>
    /// Rigidbody of the player
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// Store the direction of the player
    /// </summary>
    private Vector2 direction;

    /// <summary>
    /// Determines if the player has the movement control
    /// </summary>
    public bool hasControl = true;

    public bool impulso = false;

    public Button impulseBtn;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // Direction
        direction = rb.velocity.normalized;

        

        //Rotation
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, -Vector3.forward);

    }

    void FixedUpdate()
    {
        // Movement
        if (hasControl)
          //  rb.AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed);
            rb.AddForce(new Vector2(variableJoystick.Horizontal, variableJoystick.Vertical) * speed * ( impulso ? 2 : 1) );

        if(impulso)
            StartCoroutine(activeImpulse(2.0f));
    }

    IEnumerator activeImpulse(float time)
    {
        impulseBtn.interactable = false;
        yield return new WaitForSeconds(time);
        impulso = false;
        impulseBtn.interactable = true;

    }

    public void setImpulse(bool a)
    {
        impulso = a;
    }

    /// <summary>
    /// Gives the control to the player, in x time
    /// </summary>
    /// <param name="time"></param>
    /// <param name="control"></param>
    /// <returns></returns>
    public IEnumerator retrunsControl(float time,  bool control = true)
    {
        
        yield return new WaitForSeconds(time);
        hasControl = control;
    }


}
