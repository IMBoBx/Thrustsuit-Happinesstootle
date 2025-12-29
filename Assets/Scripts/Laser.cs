using UnityEngine; 

public class Laser : MonoBehaviour
{

    BoxCollider2D bc2D;
    Rigidbody2D rb2D;

    public float speed;
    
    void Awake()
    {
        speed = GameManager.Instance.speed;

        bc2D = gameObject.AddComponent<BoxCollider2D>();
        bc2D.isTrigger = true;

        rb2D =  gameObject.AddComponent<Rigidbody2D>();
        rb2D.bodyType = RigidbodyType2D.Kinematic;
        rb2D.linearVelocityX = -1 * speed * 2f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float score = GameManager.Instance.score;
            Debug.Log(@$"Game over. Score = {score}.)");
        }
    }
}