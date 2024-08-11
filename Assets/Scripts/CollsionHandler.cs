using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollsionHandler : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] private AudioClip explosion, winning;

    [SerializeField] private ParticleSystem SuccessParticles;
    [SerializeField] private ParticleSystem ExplosiolParticles;

    [SerializeField] private GameObject ParticlePrefeb;

    [SerializeField] private Text fuelRefill;

    public bool isTransition = false;
    public bool ColisionDisables;

    private int score;

    [SerializeField] private TextMeshProUGUI CompleteText;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        AddCheatKey();
    }

    private void AddCheatKey()
    {
        if (Input.GetKey(KeyCode.L))
        {
            LoadNextLevel();
        }

        if (Input.GetKey(KeyCode.C))
        {
            ColisionDisables = !ColisionDisables;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (isTransition || ColisionDisables) { return; }

            switch (other.gameObject.tag)
            {
                case "Start":
                    break;
                case "Landing":
                    StartSuccessSequence();
                    break;
                default:
                    StartCrashSequence();
                    break;
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Fuel":
                score++;
                fuelRefill.text = score.ToString();
                Destroy(other.gameObject);
                GameObject spawnParticle = Instantiate(ParticlePrefeb, transform.position, Quaternion.identity);
                Destroy(spawnParticle, 2f);
                break;
        }
    }

    private void CompleteBehave()
    {
        CompleteText.transform.localScale = Vector3.zero;
        CompleteText.DOFade(1, 0.5f).SetEase(Ease.InOutQuad);

        CompleteText.transform.DOScale(1, 0.5f).SetEase(Ease.OutBounce);
    }

    private void ReloadLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    private void LoadNextLevel()
    {
        int CurrentIndex = SceneManager.GetActiveScene().buildIndex;
        int NextIndex = CurrentIndex + 1;
        if (NextIndex == SceneManager.sceneCountInBuildSettings)
        {
            NextIndex = 0;
        }
        SceneManager.LoadScene(NextIndex);
    }

    private void StartCrashSequence()
    {
        isTransition = true;
        audioSource.Stop();
        audioSource.PlayOneShot(explosion);
        ExplosiolParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", 1f);
    }

    private void StartSuccessSequence()
    {
        isTransition = true;
        audioSource.Stop();
        audioSource.PlayOneShot(winning);
        SuccessParticles.Play();
        GetComponent<Movement>().enabled = false;
        CompleteBehave();
        Invoke("LoadNextLevel", 1f);
    }
}
