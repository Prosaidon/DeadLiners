using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpoint;
    private Transform currentCheckpoint;
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }

    public void Respawn()
    {
        if (currentCheckpoint != null) 
        {
            playerHealth.Respawn();
            transform.position = currentCheckpoint.position;

            Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint); // Mengirim transformasi checkpoint ke kamera
        }
        else
        {
            Debug.LogWarning("Checkpoint belum diatur!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("ChackPoint")) // Periksa tag dengan CompareTag
            {
                currentCheckpoint = collision.transform;
                SoundManager.instance.PlaySound(checkpoint);
                collision.GetComponent<Collider2D>().enabled = false;

                Animator animator = collision.GetComponent<Animator>();
                if (animator != null) // Periksa apakah Animator terpasang sebelum menggunakan SetTrigger
                {
                    animator.SetTrigger("activate");
                }
                else
                {
                    Debug.LogWarning("Animator tidak terpasang pada checkpoint!");
                }
            }
        }
}