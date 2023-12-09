using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; } // Ubah "currentHealt" menjadi "currentHealth"
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    
    [Header("Component")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    AudioManager audioManager;
    private RangedBoss rangedBoss;
    //[Header("Death Sound")]
    //[SerializeField] private AudioClip deathSound;

    private void Awake()
    {
        currentHealth = startingHealth;
        rangedBoss = GetComponent<RangedBoss>(); 
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void TakeDamage(float _damage)
    {
        if (invulnerable) return;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if(currentHealth <= startingHealth / 2 && !invulnerable)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
            //SoundManager.instance.PlaySound(hurtSound);
            if (rangedBoss != null)
            {
                rangedBoss.DoubleFireRate(); // Panggil fungsi untuk meningkatkan kecepatan tembakan
            }
        }
        else
        {
            Die();
            //anim.SetTrigger("die");
            /*if (!dead)
            {
                anim.SetTrigger("die");
                foreach(Behaviour compinent in components)
                    compinent.enabled = false;
                dead = true;
                SoundManager.instance.PlaySound(deathSound);
                
            
                
            }*/
        }
    }
    private void Die()
    {
        // Logika yang terjadi saat musuh mati
        if (!dead)
            {
                anim.SetTrigger("die");
                foreach(Behaviour compinent in components)
                    compinent.enabled = false;
                dead = true;
                //SoundManager.instance.PlaySound(deathSound);
                audioManager.PlaySFX(audioManager.death);
            }

        // Panggil UIManager untuk memberi tahu bahwa musuh telah terbunuh
        UIManager uiManager = FindObjectOfType<UIManager>();
        if (uiManager != null)
        {
            uiManager.EnemyKilled();
        }

        // Matikan GameObject musuh
        gameObject.SetActive(false);
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

   public void Respawn()
    {
        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("IdlePlayer"); 
        StartCoroutine(Invunerability());

        foreach (Behaviour component in components)
            component.enabled = true;
        dead = false;
    }
    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}