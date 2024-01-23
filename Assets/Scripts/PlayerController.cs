using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 1000f;
    public int health = 5;
    private int score = 0;

    void Start()
    {

    }

 
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed * Time.deltaTime);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup")){

				score ++;
				Debug.Log("Score: " + score);

				Destroy(other.gameObject);

		}

        if (other.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Health: " + health);
        }

        if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }

    }


    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
            health = 5;
            score = 0;
        }
    }
}
