using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{

    Rigidbody2D rb2D;
    BoxCollider2D bc2D, floorCollider;

    public GameObject floor;
    public float thrust = 20f;

    public float maxUpSpeed = 100f;
    bool isJetpackPressed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        bc2D = GetComponent<BoxCollider2D>();
        floorCollider = floor.GetComponent<BoxCollider2D>();

    }

    void Update()
    {
        isJetpackPressed = Keyboard.current.spaceKey.isPressed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isJetpackPressed && rb2D.linearVelocityY < maxUpSpeed)
        {
            rb2D.AddForce(transform.up * thrust);
        }
    }

    
}
