using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 maxSpeed;
    [SerializeField] private Vector2 timeToFullSpeed;
    [SerializeField] private Vector2 timeToStop;
    [SerializeField] private Vector2 stopClamp;

    private Vector2 moveDirection;
    private Vector2 moveVelocity;
    private Vector2 moveFriction;
    private Vector2 stopFriction;
    private Rigidbody2D rb;
    private Vector2 minBound;
    private Vector2 maxBound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * maxSpeed / (timeToStop * timeToStop);

        Camera camera  = GameObject.Find("Main Camera").GetComponent<Camera>();
        float cameraHeight = camera.orthographicSize * 2;
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraWidth = cameraHeight * screenAspect;

        Vector3 cameraPosition = camera.transform.position;
        minBound = new Vector2(cameraPosition.x - cameraWidth / 2, cameraPosition.y - cameraHeight / 2);
        maxBound = new Vector2(cameraPosition.x + cameraWidth / 2, cameraPosition.y + cameraHeight / 2);
    }

    public void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        rb.velocity = moveDirection * maxSpeed;

        if (Mathf.Abs(rb.velocity.x) > stopClamp.x || Mathf.Abs(rb.velocity.y) > stopClamp.y)
        {
            Vector2 friction = GetFriction();
            rb.velocity += friction * Time.deltaTime;
        }

        rb.velocity = new Vector2(
            Mathf.Clamp(rb.velocity.x, -maxSpeed.x, maxSpeed.x),
            Mathf.Clamp(rb.velocity.y, -maxSpeed.y, maxSpeed.y)
        );

        if (Mathf.Abs(rb.velocity.x) < stopClamp.x) rb.velocity = new Vector2(0, rb.velocity.y);
        if (Mathf.Abs(rb.velocity.y) < stopClamp.y) rb.velocity = new Vector2(rb.velocity.x, 0);

        MoveBound();
    }

    private Vector2 GetFriction()
    {
        return moveDirection != Vector2.zero ? moveFriction : stopFriction;
    }

    private void MoveBound()
    {
        rb.position = new Vector2(
            Mathf.Clamp(rb.position.x, minBound.x + 0.25f, maxBound.x - 0.25f),
            Mathf.Clamp(rb.position.y, minBound.y, maxBound.y - 0.5f)
        );
    }

    public bool IsMoving()
    {
        return rb.velocity != Vector2.zero;
    }
}
