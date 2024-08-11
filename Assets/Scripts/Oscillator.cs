using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Oscillator : MonoBehaviour
{
    private Vector3 StartPosition;

    [SerializeField] private float TimePeriod = 2f;

    [SerializeField] private Vector3 MovementPosition;
    [SerializeField][Range(0, 1)] float MovementFactor;

    private void Start()
    {
        StartPosition = transform.position;
    }

    private void Update()
    {
        if(TimePeriod <=  Mathf.Epsilon) { return; }
        float cycles = Time.time / TimePeriod;

        const float Tau = Mathf.PI * 2;
        float RawSinWave = Mathf.Sin(cycles * Tau);

        MovementFactor = (RawSinWave + 1f) / 2f;

        Vector3 offset = MovementPosition * MovementFactor;
        transform.position = StartPosition + offset;
    }
}
