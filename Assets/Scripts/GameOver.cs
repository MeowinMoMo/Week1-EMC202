using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text pointText;
    public Text cointext;
    public void Update()
    {
        pointText.text = cointext.text;
    }
     public void Restart ()
    {
        SceneManager.LoadScene("Level 1");
    }

     public void Quit ()
    {
        SceneManager.LoadScene("Start");
    }
}
