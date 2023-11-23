using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; } // Ubah "currentHealt" menjadi "currentHealth"
    private Animator anim;
    private bool dead;

    [Header("Component")]
    [SerializeField] private Behaviour[] components;

    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;

    private void Awake()
    {
        currentHealth = startingHealth; // Ubah "currentHealt" menjadi "currentHealth"
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            // iframes
        }
        else
        {
            //anim.SetTrigger("die");
            if (!dead)
            {
                anim.SetTrigger("die");

                //Player
                /*if(GetComponent<Player>() != null)
                   GetComponent<Player>().enabled = false;

                //Enemy
                if(GetComponentInParent <EnemyPatrol>() != null)
                    GetComponentInParent<EnemyPatrol>().enabled = false;
                
                if(GetComponent<MeleeEnemy>() != null)
                    GetComponent<MeleeEnemy>().enabled = false;
                */
                foreach(Behaviour compinent in components)
                    compinent.enabled = false;
                dead = true;
                SoundManager.instance.PlaySound(deathSound);
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
