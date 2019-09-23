using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    private PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerInput.actions.FindAction("Attack").triggered && !animator.GetBool("isAttacking"))
        {
            StartCoroutine(AttackCo());
        }
    }
    private IEnumerator AttackCo()
    {
        animator.SetBool("isAttacking", true);
        yield return null;
        yield return new WaitForSeconds(.33f);
        animator.SetBool("isAttacking", false);

    }
    void FixedUpdate()
    {
        if(!animator.GetBool("isAttacking"))
        {
            UpdateAnimationAndMove();
        }
    }

    void UpdateAnimationAndMove()
    {
        MoveCharacter();
        if (change != Vector3.zero)
        {
            // If the player is moving (change) then set the values on the animator so it can check the best direction and walking state.
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("isWalking", true);
        }
        else
        {
            // At this point the player is not walking so make the animation not walking, this will leave the last direction the player was looking for the idle animation.
            animator.SetBool("isWalking", false);
        }
    }

    void MoveCharacter()
    {
        // This is a good way to just check on the current state of the particular action.
        change = playerInput.actions.FindAction("Move").ReadValue<Vector2>();

        myRigidbody.MovePosition(
            transform.position + (change * speed * Time.fixedDeltaTime));
    }
}
