using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerUFO : MonoBehaviour
{
    public float speed;
    public Text scoreText;
    public Text gameOverText;
    private Rigidbody2D rb2d;
    private int count;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        SetCount(count);
        gameOverText.text = "";
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCount(count);
            if (count == 6)
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        gameOverText.text = "GameOver";
        Time.timeScale = 0;
    }

    private void SetCount(int count)
    {
        scoreText.text = "Score: " + count.ToString();
    }
}
