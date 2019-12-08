using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{

    public GameHandler gh;

    // Start is called before the first frame update

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Resume()
    {
        gh.Resume();
    }
}