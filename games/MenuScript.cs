using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    public AudioClip dullClip;
    

    // Start is called before the first frame update
    public void PlayGame()
    {
        Debug.Log("Play");
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


}
