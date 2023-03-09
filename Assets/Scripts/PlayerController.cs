using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 dir;
    [SerializeField] private float speed;

    private int lineToMove = 1;
    public float lineDistance = 4;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if (SwipeController.swipeRight)
        {
            if (lineToMove < 2)
                lineToMove++;
        }

        if (SwipeController.swipeLeft)
        {
            if (lineToMove > 0)
                lineToMove--;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
            targetPosition += Vector3.left * lineDistance;
        else if (lineToMove == 2)
            targetPosition += Vector3.right * lineDistance;

        transform.position = targetPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        characterController.Move(dir * Time.fixedDeltaTime);
    }
}
