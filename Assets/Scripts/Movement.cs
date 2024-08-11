using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 1000f;
    [SerializeField] private float RotationSpeed;
    [SerializeField] private AudioClip MainEngine;

    [SerializeField] private ParticleSystem RightParticles;
    [SerializeField] private ParticleSystem LeftParticles;
    [SerializeField] private ParticleSystem JetEngine;

    [SerializeField] private Image Right, left;

    [SerializeField] float time_To_up;

    private Rigidbody rb;
    AudioSource source;

    public bool isTouching;
    public bool isLeft, isRight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();

        
    }

    // Update is called once per frame
    void Update()
    {
          //    PressedThrust();
         //   ProcessRotation();
        //TouchingInput();
         TouchingInput();
    }

    void PressedThrust()
    {
        ThrustingForce();
    }
    void ProcessRotation()
    {
        ThrustingRotation();
    }

    private void ThrustingForce()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * speed * Time.deltaTime);
            if (!source.isPlaying)
            {
                source.PlayOneShot(MainEngine);
            }
            if (!JetEngine.isPlaying)
            {
                JetEngine.Play();
            }
        }
        else
        {
            StopThrusting();
        }
    }

    private void StopThrusting()
    {
        source.Stop();
        JetEngine.Stop();
    }

    private void ThrustingRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Rotation(RotationSpeed);
            if (!LeftParticles.isPlaying)
            {
                LeftParticles.Play();
            }

        }
        else if (Input.GetKey(KeyCode.D))
        {
            Rotation(-RotationSpeed);
            if (!RightParticles.isPlaying)
            {
                RightParticles.Play();
            }
        }
        else
        {
            RightParticles.Stop();
            LeftParticles.Stop();
        }
    }

    void Rotation(float rotation_)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotation_ * Time.deltaTime);
        rb.freezeRotation = false;
    }

    public void Touch(bool touch)
    {
        isTouching = touch;
    }

    void TouchingInput()
    {
        if (isTouching)
        {
            rb.AddRelativeForce(Vector3.up * speed * Time.deltaTime);
            if (!source.isPlaying)
            {
                source.PlayOneShot(MainEngine);
            }
            if (!JetEngine.isPlaying)
            {
                JetEngine.Play();
            }
        }
        else
        {
            source.Stop();
            JetEngine.Stop();
        }

        if (isRight)
        {
            Rotation(-RotationSpeed);
            if (!RightParticles.isPlaying)
            {
                RightParticles.Play();
            }
            Right.DOFade(0.3f, 1f);
        }
        else if (isLeft)
        {
            Rotation(RotationSpeed);
            if (!LeftParticles.isPlaying)
            {
                LeftParticles.Play();
            }
            left.DOFade(0.3f, 1f);
        }
        else
        {
            RightParticles.Stop();
            LeftParticles.Stop();
            Right.DOFade(0f, 1f);
            left.DOFade(0f, 1f);
        }
    }

    public void TouchingLeft(bool touch)
    {
        isLeft = touch;
    }

    public void TouchingRight(bool touch)
    {
        isRight = touch;
    }

    public void MainScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");

        GameObject audioManager = GameObject.Find("Audio Manager");

        if(audioManager != null)
        {
            audioManager.SetActive(false);
        } 
    }
}