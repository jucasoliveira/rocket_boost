using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 1.5f;
    [SerializeField] AudioClip crashAudio;
    [SerializeField] AudioClip successAudio;

    private Movements player;
    private AudioSource audioSource;

    void Start()
    {
        player = GetComponent<Movements>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                Debug.Log("You win!");
                MoveToNextLevel();
                break;
            case "Fuel":
                Debug.Log("You got fuel!");
                break;
            default:
                Debug.Log("You died!");
                StartCrashSequence();
                break;
        }
    }

    void MoveToNextLevel()
    {
        player.enabled = false; // Disable player movement
        audioSource.PlayOneShot(successAudio); // Play success audio
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void StartCrashSequence()
    {
        // Add crash effects here (e.g., play sound, show explosion, etc.)
        player.enabled = false; // Disable player movement
        audioSource.PlayOneShot(crashAudio); // Play crash audio
        Invoke("ReloadLevel", levelLoadDelay); // Reload the level after a delay
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0; // Loop back to the first level
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}


