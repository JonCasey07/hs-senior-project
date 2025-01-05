using UnityEngine;
using System.Collections;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager tutorial;
    public event Action LevelComplete;

    public static EventManager level1;


    private void Awake()
    {
        if (tutorial == null)
        {
            tutorial = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void CompleteLevel()
    {
        LevelComplete?.Invoke();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
