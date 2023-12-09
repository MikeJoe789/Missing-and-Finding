using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Adjust this value to control the movement speed
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator component is missing!");
        }
    }

    void Update()
    {
        // Get user input for movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Set the animator parameters based on input
        float movementSpeed = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
        animator.SetFloat("Speed", movementSpeed);

        // Move the character using Transform.Translate
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        transform.Translate(movement * speed * Time.deltaTime);

        // Rotate the character to face the direction of movement
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 500f * Time.deltaTime);
        }
    }
}
