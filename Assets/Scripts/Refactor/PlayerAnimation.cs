using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Vampire
{
    public class PlayerAnimation : MonoBehaviour
    {

        //References
        Animator animator;
        SpriteRenderer spriteRenderer;
        PlayerInput playerInput;
        PlayerMovement playerMovement;

        // Start is called before the first frame update
        void Start()
        {
            animator= GetComponent<Animator>();
            spriteRenderer= GetComponent<SpriteRenderer>();
            playerInput = GetComponent<PlayerInput>();
            playerMovement = GetComponent<PlayerMovement>();
        }

        // Update is called once per frame
        void Update()
        {
            if(playerMovement.MoveDir.x != 0 || playerMovement.MoveDir.y != 0)
            {
                animator.SetBool("Move", true);

                SpriteDirectionChecker();
            }
            else
            {
                animator.SetBool("Move", false); 
            }

        }

        void SpriteDirectionChecker()
        {
            if (playerInput.LastHorizontalVec < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
    }
}