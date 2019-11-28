using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject loseMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Quit()
    {

    }

    public void Retry()
    {

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        GameHandler.paused = false;
    }
}