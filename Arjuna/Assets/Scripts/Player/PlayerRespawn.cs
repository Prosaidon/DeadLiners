using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
   // [SerializeField] private AudioClip checkpoint;
    private Transform currentCheckpoint;
    private Health playerHealth;
   // private UIManager uIManager;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        //uIManager = FindObjectOfType<UIManager>();
    }

    public void CheckRespawn()
    {
        if (currentCheckpoint != null) 
        {
            //uIManager.GameOver();
            
            //return;

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
                //SoundManager.instance.PlaySound(checkpoint);
                collision.GetComponent<Collider2D>().enabled = false;

                /*Animator animator = collision.GetComponent<Animator>();
                if (animator != null) // Periksa apakah Animator terpasang sebelum menggunakan SetTrigger
                {
                    animator.SetTrigger("activate");
                }
                else
                {
                    Debug.LogWarning("Animator tidak terpasang pada checkpoint!");
                }*/
            }
        }
}