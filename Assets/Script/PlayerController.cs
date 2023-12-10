using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody component is missing!");
        }

        if (animator == null)
        {
            Debug.LogError("Animator component is missing!");
        }
        else
        {
            // Disable the default Animator rotation
            animator.applyRootMotion = false;
        }
    }

    void Update()
    {
        // Get user input for movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Set animator parameters based on input
        float movementSpeed = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
        animator.SetFloat("Speed", movementSpeed);

        // Move the character using Rigidbody.AddForce
        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        if (rb != null)
        {
            // Apply force for movement
            rb.AddForce(movement * speed);

            // Rotate the character to face the direction of movement
            if (movement != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 500f * Time.deltaTime);
            }
        }
        else
        {
            Debug.LogError("Rigidbody component is missing! Character won't move.");
        }
    }
}
