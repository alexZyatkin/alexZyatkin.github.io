using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button restartButton;
    public Button menuButton;
    public TextMeshProUGUI scoreText;

    private AudioSource playerAudio;
    public AudioClip trashSound;
    public AudioClip gameoverSound;

    private int score;

    //this use in other scripts
    public bool isGameActive;
    
    // Start is called before the first frame update
    void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        isGameActive = true;
        UpdateScore(0);
    }

    //trigger player with other object
    private void OnTriggerEnter(Collider other)
    {
        // get a trash
        if (other.gameObject.CompareTag("Trash"))
        {
            UpdateScore(10);
            playerAudio.PlayOneShot(trashSound, 1f);
            Destroy(other.gameObject);
        }
        //gameover
        else if (other.gameObject.CompareTag("Rock"))
        {
            GameOver();
            playerAudio.PlayOneShot(gameoverSound, .8f);
            //Debug.Log("Rock-Rock!");
        }
    }

    private void UpdateScore(int scoreAdd)
    {
        score += scoreAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        menuButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitToMenu()
    {
        isGameActive = false;
        SceneManager.LoadScene(0);
    }
}
