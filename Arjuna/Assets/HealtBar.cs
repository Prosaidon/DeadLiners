using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private Health playerHealth;
   [SerializeField] private Image totalhealthBar;
   [SerializeFIeld] private Image currenthealthBar;

   private void Start()
   {

   }
   private void update()
   {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10
   }
}
