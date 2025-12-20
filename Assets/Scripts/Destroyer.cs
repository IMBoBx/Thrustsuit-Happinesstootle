using UnityEngine;

public class Destroyer : MonoBehaviour
{
    BoxCollider2D bc2D;

    void Start()
    {
        bc2D = GetComponent<BoxCollider2D>();
        bc2D.isTrigger = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}