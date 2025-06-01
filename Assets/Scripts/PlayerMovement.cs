using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sp;

    private Vector2 inputVector;
    private bool isPressingW = false;
    private bool wasPressingW = false;
    private bool isPressingS = false;
    private bool wasPressingS = false;

    private void Start()
    {
        animator.SetBool("IsMoveX", false);
        animator.SetBool("IsMoveZ", false);
        animator.SetBool("IdleBack", false);

        if (SoundManager.instance.BGSound != null)
        {
            SoundManager.instance.BGSound.Play();
        }
    }

    void Update()
    {
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");
        inputVector.Normalize();

    
        if (inputVector.x < 0f)
            sp.flipX = true;
        else if (inputVector.x > 0f)
            sp.flipX = false;

        isPressingW = Input.GetKey(KeyCode.W);
        isPressingS = Input.GetKey(KeyCode.S);

       
        if (wasPressingW && !isPressingW && inputVector == Vector2.zero)
        {
            animator.SetBool("IdleBack", true);
            animator.SetBool("IsIdle", false);
        }
      
        else if (wasPressingS && !isPressingS && inputVector == Vector2.zero)
        {
            animator.SetBool("IdleBack", false);
            animator.SetBool("IsIdle", true);
        }


        wasPressingW = isPressingW;
        wasPressingS = isPressingS;
    }

    void FixedUpdate()
    {
        float moveX = inputVector.x * moveSpeed * Time.fixedDeltaTime;
        float moveZ = inputVector.y * moveSpeed * Time.fixedDeltaTime;

        Vector3 move = new Vector3(moveX, moveZ,0f );
        transform.position += move;

     
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("IsMoveZ", true);
            animator.SetBool("IsMoveX", false);
            animator.SetBool("IdleBack", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("IsMoveZ", false);
            animator.SetBool("IsMoveX", true);
            animator.SetBool("IdleBack", false);
        }
        else if (inputVector.x != 0f)
        {
            animator.SetBool("IsMoveZ", false);
            animator.SetBool("IsMoveX", true);
            animator.SetBool("IdleBack", false);
        }
        else
        {
            animator.SetBool("IsMoveZ", false);
            animator.SetBool("IsMoveX", false);
      
        }
    }
}
