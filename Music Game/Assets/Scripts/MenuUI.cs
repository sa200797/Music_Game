using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuUI : MonoBehaviour
{
    public GameObject infopannel;

    private void Start()
    {
        infopannel.SetActive(false);
    }
    public void PlayNext()
    {
        SceneManager.LoadScene(1);
    }

    public void infogame()
    {
        infopannel.SetActive(true);

    }
    
    public void infogameExit()
    {
        infopannel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
}
