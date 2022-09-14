
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{
    private AudioSource Completesound;
    // Update is called once per frame
    void Update()
    {
        Completesound = GetComponent<AudioSource>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Completesound.Play();
            LoadNextLevel();
        }
    }



    private void LoadNextLevel()
    {

    }
}
