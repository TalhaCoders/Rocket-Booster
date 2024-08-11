using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private AudioManager instance;

    [SerializeField] private AudioSource audioSource;

    [SerializeField] private Toggle soundCheck;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (audioSource != null && soundCheck != null)
        {
            audioSource.enabled = soundCheck.isOn;
        }
    }
}
