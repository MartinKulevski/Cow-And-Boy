using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public AudioClip levelSong;  // Reference to the level song audio clip
    private AudioSource audioSource;

    private static Music instance;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of GameManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = levelSong;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Handle audio behavior based on the loaded scene
        if (scene.name.StartsWith("Stage"))
        {
            // Continue playing the level song if it's not already playing
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // Pause or stop audio for other scenes if needed
            audioSource.Stop();
        }
    }
}
