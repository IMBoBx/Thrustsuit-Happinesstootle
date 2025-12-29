using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TMP_Text scoreText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {GameManager.Instance.score:F0}";
    }
}
