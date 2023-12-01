using UnityEngine;

public class EnemyDeathNotifier : MonoBehaviour
{
   private UIManager uiManager; // Referensi ke skrip UIManager
    private bool isDead = false;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>(); // Cari skrip UIManager di scene
    }

    public void NotifyDeath()
    {
        if (!isDead)
        {
            isDead = true;
            if (uiManager != null)
            {
                uiManager.EnemyKilled(); // Panggil metode EnemyKilled() dari UIManager
            }

            gameObject.SetActive(false); // Matikan GameObject musuh
        }
    }
}
