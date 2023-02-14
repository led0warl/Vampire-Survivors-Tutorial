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

        // Start is called before the first frame update
        void Start()
        {
            animator= GetComponent<Animator>();
            spriteRenderer= GetComponent<SpriteRenderer>();
            playerInput = GetComponent<PlayerInput>();
        }

        // Update is called once per frame
        void Update()
        {
            if(playerInput.MoveDir.x != 0 || playerInput.MoveDir.y != 0)
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