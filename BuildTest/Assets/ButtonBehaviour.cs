using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{

    //Går til første lagrede scene. Index 0;
    public void GoMainScene()
    {
        SceneManager.LoadScene(0);
    }
    //Åpner den scene du sender index til. 
    public void OpenScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
