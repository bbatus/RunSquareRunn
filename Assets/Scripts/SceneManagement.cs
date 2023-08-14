using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneManagement : MonoBehaviour
{
    bool gameOver = false;
    public GameObject restartButton;

    void Start()
    {
        restartButton.SetActive(false);
    }


    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            restartButton.SetActive(true);
        }
    }

    public void ResetScene()
    {

        SceneManager.LoadScene(1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TriggerFinish"))
        {
            gameOver = true;
            Debug.Log("Congrats");
            restartButton.SetActive(true);
        }

    }
}
