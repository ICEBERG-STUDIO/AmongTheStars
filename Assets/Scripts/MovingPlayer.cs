using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovingPlayer : MonoBehaviour
{
    [SerializeField] private float mSpeed = 3.0f;
    [SerializeField] private GameObject mPlayer;
    [SerializeField] private GameObject mPlayerCamera;
    private Vector2 mMoveVector;
    private CharacterController mCharacter;

    private Rigidbody2D rgbd2D;
    #region Initialization
    private void Awake()
    {
        //mCharacter = gameObject.AddComponent<CharacterController>();
        //mCharacter.radius = 1.0f;
        //mCharacter.detectCollisions = true;
        

        // Find the character object
        Transform childObject = transform.Find("scope");
        rgbd2D = GetComponent<Rigidbody2D>();
    }

    private void OnDisable()
    {
        Destroy(mCharacter);
    }
    #endregion
    private void FixedUpdate()
    {
        Move();
    }

    public void ReadMoveInput(InputAction.CallbackContext context)
    {
        mMoveVector = context.ReadValue<Vector2>();
    }

    public void ReadJumpInput(InputAction.CallbackContext context)
    {
        mMoveVector.y = context.ReadValue<float>();
    }
    public void ReadAttackInput(InputAction.CallbackContext context)
        {
            Debug.Log("Player Attacked");
        }

     public void ReadDashnput(InputAction.CallbackContext context)
            {
                Debug.Log("Player Dashed");
            }
    public void Move()
    {
        // Find the direction
        Vector2 direction = new Vector2(mMoveVector.x, mMoveVector.y).normalized;

        if (direction.magnitude >= 0.1f)
        {

            // Use normalized vector to move the character


            // Apply the movement
            rgbd2D.position += (Vector2)transform.right * mSpeed;
            //mCharacter.Move(moveDirection.normalized * mSpeed * Time.deltaTime);
            //m_Animator.SetBool("isWalkin", true);
        }
        else
        {
            // If the character don't move, set the isWalkin parameter to false
            //m_Animator.SetBool("isWalkin", false);
        }
    }

    public void Rotate()
    {
        
    }
}