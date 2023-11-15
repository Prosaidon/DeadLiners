using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        if (target != null) // Periksa apakah target tidak null sebelum mengakses posisinya
        {
            Vector3 newPosition = new Vector2(target.position.x, target.position.y + 2);
            transform.position = newPosition;
        }
    }
}
