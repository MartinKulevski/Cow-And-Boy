using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public AudioClip levelSong;  // Reference to the level song audio clip
    private AudioSource audioSource;

    private bool isPaused = false; // Flag to track if the audio is paused

    private void Awake()
    {
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
            if (!audioSource.isPlaying && !isPaused)
            {
                audioSource.Play();
            }
        }
        else
        {
            // Pause or stop audio for other scenes if needed
            audioSource.Pause();
            isPaused = true;
        }
    }

    public void ResumeAudio()
    {
        // Resume audio playback
        if (!audioSource.isPlaying && isPaused)
        {
            audioSource.Play();
            isPaused = false;
        }
    }
}
