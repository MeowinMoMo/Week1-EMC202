using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    public bool Done = false;
    Animator anim;

    void Awake()
    {
        anim=GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == ("Player"))
        {
            Done = true;
            Player.LastCheckPoint = transform.position;
            anim.Play("CheckPointyay");
            // anim.Play("checkpointdone");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Start");
    }
}
