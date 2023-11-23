using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*[SerializeField]
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
    }*/
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //Follow player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    private void Update()
    {
        //Room camera
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);

        //Follow player
        //transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        //lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
