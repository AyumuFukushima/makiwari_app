using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public void toGame()
    {
        SceneManager.LoadScene("GameCountDown");
    }

    public void toTitle()
    {
        SceneManager.LoadScene("Title");
    }

}
