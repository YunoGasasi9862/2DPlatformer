
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{
    private AudioSource Completesound;

    private bool istouchedtheflag = false;
    // Update is called once per frame
    void Update()
    {
        Completesound = GetComponent<AudioSource>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !istouchedtheflag)
        {
            istouchedtheflag = true;
            Completesound.Play();
            Invoke("LoadNextLevel",2f);
        }
    }



    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
