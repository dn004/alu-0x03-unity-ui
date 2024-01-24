using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 1000f;
    public int health = 5;
    private int score = 0;
    public Text scoreText;
    public Text healthText;
    public Text WinLoseText;
    public Image WinLoseBG;
    void Start()
    {

    }

 
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup")){

				SetScoreText();
				//Debug.Log("Score: " + score);

				Destroy(other.gameObject);

		}

        if (other.CompareTag("Trap"))
        {
            SetHealthText();
            //Debug.Log("Health: " + health);
        }

        if (other.CompareTag("Goal"))
        {
            SetWinText();
            WinLoseBG.gameObject.SetActive(true);
            //Debug.Log("You win!");
            StartCoroutine(LoadSceneAfterDelay(3f));
        }

    }


    void Update()
    {
        if (health == 0)
        {
            SetLoseText();
            //Debug.Log("Game Over!");

            WinLoseBG.gameObject.SetActive(true);
            StartCoroutine(LoadSceneAfterDelay(3f));
        }
    }

    IEnumerator LoadSceneAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        health = 5;
        score = 0;
        WinLoseBG.gameObject.SetActive(false); // Deactivate WinLoseBG after restarting
    }


    void SetScoreText()
    {
        score ++;
        scoreText.text = "Score: " + score.ToString();
 

    }

    void SetHealthText()
    {
        health --;
        healthText.text = "Health: " + health.ToString();
    }

    void SetWinText()
    {
        WinLoseText.text = "You Win!";
        WinLoseText.color = Color.black;
        WinLoseBG.color = Color.green;
    }

    void SetLoseText()
    {
        WinLoseText.text = "Game Over!";
        WinLoseText.color = Color.white;
        WinLoseBG.color = Color.red;
    }
    
}
