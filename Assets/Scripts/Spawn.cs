using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public Sprite laserSprite;
    Camera cam;
    Vector3 topRight, bottomLeft;
    float topY, bottomY, midY;

    int numLasers = 0;
    public float speed = 1f;

    public GameObject destroyer;
    BoxCollider2D destroyerCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        topRight = cam.ViewportToWorldPoint(new Vector3(1f, 1f, cam.nearClipPlane));
        bottomLeft = cam.ViewportToWorldPoint(new Vector3(0f, 0.1f, cam.nearClipPlane));

        topY = topRight.y;
        bottomY = bottomLeft.y;
        midY = (topY + bottomY) / 2;

        destroyerCollider = destroyer.GetComponent<BoxCollider2D>();
        if (destroyerCollider)
        {
            Debug.Log("destroyer collider found");
        }

        StartCoroutine(SpawnLoop());
    }

    // Update is called once per frame
    void Update()
    {

    }


    void SpawnLaser()
    {
        float length = Random.Range(2.5f, 6f);
        float angle = Random.Range(0f, 180f);
        float yPos = Random.Range(topY, bottomY);

        var laser = new GameObject("Laser" + numLasers);
        laser.AddComponent<Laser>();

        var sr = laser.AddComponent<SpriteRenderer>();
        sr.sprite = laserSprite;

        laser.transform.rotation = Quaternion.Euler(0, 0, angle);
        laser.transform.localScale = new Vector3(length, 0.5f, 1f);
        laser.transform.position = new Vector3(gameObject.transform.position.x - 2f, yPos, 0);

        
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnLaser();
            numLasers++;

            yield return new WaitForSeconds(Random.Range(0.5f, 3f));
        }
    }
}
