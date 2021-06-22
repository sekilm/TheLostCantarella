using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    public Animator animator;

    private Rigidbody2D playerBody;

    void Start()
    {
        playerBody = gameObject.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (DialogueManager.isActive)
        {
            playerBody.velocity = new Vector2(0, 0);
            playerBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

            enabled = false;
        }

        Vector2 currentVelocity = playerBody.velocity;

        float newVelocityX = 0f;
        float newVelocityY = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            newVelocityX = -speed;
            animator.SetInteger("DirectionX", -1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            newVelocityX = speed;
            animator.SetInteger("DirectionX", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            newVelocityY = -speed;
            animator.SetInteger("DirectionY", -1);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            newVelocityY = speed;
            animator.SetInteger("DirectionY", 1);
        }
        if (currentVelocity.x == 0)
        {
            animator.SetInteger("DirectionX", 0);
        }
        if (currentVelocity.y == 0)
        {
            animator.SetInteger("DirectionY", 0);
        }

        playerBody.velocity = new Vector2(newVelocityX, newVelocityY);
    }
}
