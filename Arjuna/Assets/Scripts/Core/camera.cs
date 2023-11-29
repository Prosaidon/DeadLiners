using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
  [SerializeField] private float speed;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);
    }

    private float currentPosX;

    public void MoveToNewRoom(Transform _newRoom)
    {
        if (_newRoom != null) // Pastikan _newRoom bukan null sebelum menggunakannya
        {
            currentPosX = _newRoom.position.x;
        }
        else
        {
            Debug.LogWarning("Room yang baru belum ditentukan!");
        }
    }
}

