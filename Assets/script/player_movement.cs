using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float baseSpeed;
    public float rotationSpeed;
    public float stationarySpeed;

    private float currentSpeed;
    private float maxSpeed = 5f; // Set your desired maximum speed here
    private float accelerationRate = 1f; // Adjust the acceleration rate as needed

    Vector2 StartingPosition;
    Vector2 EndingPosition;
    Vector3 mygameobjectPos;
    Vector3 totalMovement;
    Vector2 distanceBetweenTwo;
    bool hasMoved = false;

    private void Start()
    {
        transform.position = new Vector3(0, -0.11f, 0);
        currentSpeed = baseSpeed;
    }

    void Update()
    {
        moveCube();
    }

    private void moveCube()
    {
        if (Input.touchCount > 0)
        {
            Touch touchInput = Input.GetTouch(0);

            switch (touchInput.phase)
            {
                case TouchPhase.Began:
                    StartingPosition = touchInput.position;
                    mygameobjectPos = transform.position;
                    break;

                case TouchPhase.Moved:
                    hasMoved = true;
                    EndingPosition = touchInput.position;
                    distanceBetweenTwo = EndingPosition - StartingPosition;
                    totalMovement = new Vector3(distanceBetweenTwo.x, 0, distanceBetweenTwo.y) * currentSpeed * Time.deltaTime;
                    transform.Translate(totalMovement, Space.World);
                    rotated();
                    StartingPosition = touchInput.position;
                    break;

                case TouchPhase.Stationary:
                    if (hasMoved)
                    {
                        totalMovement = new Vector3(distanceBetweenTwo.x, 0, distanceBetweenTwo.y) * stationarySpeed * Time.deltaTime;
                        transform.Translate(totalMovement, Space.World);
                        rotated();
                    }
                    break;

                case TouchPhase.Ended:
                    hasMoved = false;
                    break;
            }
        }
    }

    private void rotated()
    {
        if (totalMovement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(totalMovement.normalized, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    // Increase speed continuously when the user continuously presses
    private void FixedUpdate()
    {
        if (hasMoved)
        {
            if (currentSpeed < maxSpeed)
            {
                currentSpeed += Time.fixedDeltaTime * accelerationRate; // Smoothly increase speed
            }
            else
            {
                currentSpeed = maxSpeed; // Cap speed at the maximum value
            }
        }
        else
        {
            currentSpeed = baseSpeed; // Reset speed when touch is not pressed
        }
    }
}
