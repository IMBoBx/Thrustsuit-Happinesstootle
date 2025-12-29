using System;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum GameState
    {
        Running,
        Paused,
        Menu
    }

    public float score = 0f;
    public float speed = 1f;
    public GameState state = GameState.Running;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        speed = Math.Min(3.5f, 1f + Time.timeSinceLevelLoad / 30f);
        if (state == GameState.Running)
        {
            score += Time.fixedDeltaTime * 10 * speed;
        }
    }
}
