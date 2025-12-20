using System.Collections;
using Unity.Mathematics;
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
        topRight = cam.ViewportToWorldPoint(new Vector3(1f, 0.9f, cam.nearClipPlane));
        bottomLeft = cam.ViewportToWorldPoint(new Vector3(0f, 0.1f, cam.nearClipPlane));

        topY = topRight.y;
        bottomY = bottomLeft.y;
        midY = (topY + bottomY) / 2;

        destroyerCollider = destroyer.GetComponent<BoxCollider2D>();
        StartCoroutine(SpawnLoop());
    }

    // Update is called once per frame
    void Update()
    {

    }


    void SpawnLaser()
    {
        float angle = UnityEngine.Random.Range(0f, 180f);
        float angleRad = math.radians(angle);
        float sinAngle = math.max(0.1f, math.sin(angleRad));

        float yPos = UnityEngine.Random.Range(topY, bottomY);
        float maxHeight = math.min(topY - yPos, yPos - bottomY);

        float randomLen = UnityEngine.Random.Range(2.5f, 6f);
        float length = math.min(randomLen, maxHeight / sinAngle);


        Debug.Log(@$"Laser no.: {numLasers}
        Angle: {angle}
        y Position: {yPos}
        topY - yPos: {topY - yPos}
        yPos - bottomY: {yPos - bottomY}
        MaxHeight: {maxHeight}
        Random len: {randomLen}
        Length: {length}");
        
        if (length < 1.5f) {
            Debug.Log($"Skipping spawn - laser {numLasers}");
            return;
        }; // skipping spawn if length is too small.

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

            yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 3f));
        }
    }
}
