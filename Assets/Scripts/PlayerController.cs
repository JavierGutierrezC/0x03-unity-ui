using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Speed in which the ball wil move can be change in Unity
    public float speed;
    public int health = 5;
    private Rigidbody rb;
    private int score = 0;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    
    }
    void FixedUpdate()
    {
        // Get info from User to move in the X and Y axis
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (horizontalInput, 0.0f, verticalInput);
        
        rb.AddForce(movement * speed);
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            score++;
            SetScoreText();
            other.gameObject.SetActive(false);
            // Debug.Log("Score: " + score.ToString());
        }
        if(other.gameObject.CompareTag("Trap"))
        {
            health--;
            other.gameObject.SetActive(true);
            Debug.Log("Health: " + health.ToString());
        }
        if(other.gameObject.CompareTag("Goal"))
        {
            other.gameObject.SetActive(true);
            Debug.Log("You win!");
        }
    }
    void Update()
    {
        if(health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(0);
        }
    }
    void SetScoreText()
    {
    scoreText.text = "Count: " + score.ToString();
    }
}
