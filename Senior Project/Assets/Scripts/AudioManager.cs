using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public AudioSource currentAudioSource; // Current scene's audio
    public AudioSource nextAudioSource; // Next scene's audio
    public float fadeDuration = 1f; // Duration of fade effect
    private bool isFirstScene = true; // Track if this is the first scene

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // Keep this object alive across scenes
        SceneManager.sceneLoaded += OnSceneLoaded; // Listen for scene changes
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (isFirstScene)
        {
            // If no audio is playing at start, only fade in the new scene's audio
            StartCoroutine(FadeInAudio(currentAudioSource));
            isFirstScene = false;
        }
        else
        {
            // Fade out previous scene's audio and fade in the new audio
            StartCoroutine(FadeOutAudio(currentAudioSource));
            StartCoroutine(FadeInAudio(nextAudioSource));

            // Update the current audio source reference
            currentAudioSource = nextAudioSource;
        }
    }

    IEnumerator FadeOutAudio(AudioSource audioSource)
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            float startVolume = audioSource.volume;
            float timer = 0f;

            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(startVolume, 0f, timer / fadeDuration);
                yield return null;
            }

            audioSource.Stop();
        }
    }

    IEnumerator FadeInAudio(AudioSource audioSource)
    {
        if (audioSource != null)
        {
            audioSource.volume = 0f;
            audioSource.Play();

            float timer = 0f;
            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(0f, 1f, timer / fadeDuration);
                yield return null;
            }
        }
    }
}