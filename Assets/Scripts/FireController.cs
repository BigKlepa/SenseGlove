using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using SG;

public class FireController : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    public float currentHealth;
    [SerializeField] ParticleSystem flameParticle;
    [SerializeField] ParticleSystem sparkParticle;
    [SerializeField] ParticleSystem smokeParticle;
    [SerializeField] ParticleSystem biggerSmokeParticle;
    [SerializeField] ParticleSystem smokeAttackParticle;

    private bool isFireBig = false;
    private bool isFireAlive = true;
    private bool regenerating = false;
    public bool pinRemoved = false;
    private int gameTime;

    [SerializeField] GameObject winScreen;
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] SG_BasicGesture gestures;

    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        StartCoroutine(FireRegeneration());
        StartCoroutine(RegenTimer());
        StartCoroutine(GameTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            smokeAttackParticle.Play();
        }
        else
        {
            smokeAttackParticle.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ResetScene();
        }
        if (pinRemoved)
        {
            if (gestures.IsGesturing)
            {
                smokeAttackParticle.Play();
            }
            else
            {
                smokeAttackParticle.Stop();
            }
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    print("ontriggerenter");
    //    currentHealth--;
    //}
    //private void OnParticleTrigger()
    //{
    //    print("onparticletrigger");
    //    currentHealth--;
    //}
    //private void OnParticleCollision(GameObject other)
    //{
    //    print("onparticlecollision");
    //    currentHealth--;
    
    public void ReduceHealth(float amount)
    {
        currentHealth -= amount;
        regenerating = false;
        if (currentHealth < maxHealth / 2 && !isFireBig && isFireAlive)
        {
            print("fire at half health");
            BiggerSmoke();
        }
        if (currentHealth < 1 && isFireAlive)
        {
            print("Fire is dead");
            KillFire();
        }
    }

    public void KillFire()
    {
        isFireAlive = false;
        flameParticle.Stop();
        sparkParticle.Stop();
        smokeParticle.Stop();
        biggerSmokeParticle.Stop();
        GameWon();
        StartCoroutine(WinTimer());
    }

    public void RemovePin()
    {
        pinRemoved = true;
    }

    public IEnumerator GameTimer()
    {
        yield return new WaitForSeconds(1.0f);
        gameTime += 1;
        StartCoroutine(GameTimer());
    }

    public void GameWon()
    {
        winText.text = "Time: " + gameTime + "s";
        scoreText.text = "Score: " + Random.Range(0, 101);
    }

    public IEnumerator WinTimer()
    {
        yield return new WaitForSeconds(1.5f);
        winScreen.SetActive(true);
    }

    public void BiggerSmoke()
    {
        smokeParticle.Stop();
        biggerSmokeParticle.Play();
    }



    public IEnumerator RegenTimer()
    {
        float hpBeforeTimer = currentHealth;
        yield return new WaitForSeconds(1.0f);
        if (currentHealth == hpBeforeTimer)
        {
            regenerating = true;
        }
        else
        {
            regenerating = false;
        }
        StartCoroutine(RegenTimer());
    }

    public IEnumerator FireRegeneration()
    {
        if (regenerating == true && isFireAlive)
        {
            currentHealth = maxHealth;
            biggerSmokeParticle.Stop();
            isFireBig = false;
            smokeParticle.Play();
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(FireRegeneration());
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(1);
    }

    
}
