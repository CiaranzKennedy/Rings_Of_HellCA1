using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Player : MonoBehaviour
{
    public int direction = 0;
    public int speed;
    public int JumpHeight = 0;
    bool isJumping = false;

    Animator animator;
    new Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        float move = Input.GetAxis("Horizontal");
        float jump = Input.GetAxis("Vertical");
        position.x = position.x + speed * Time.deltaTime * move;
        transform.position = position;

        if (move != 0)
        {
            direction = move < 0 ? -1 : 1;
            animator.SetFloat("MoveX", direction);
            animator.SetFloat("MoveY", (direction < 0 ? -0.8f : 0.8f));
        }
        else
        {
            animator.SetFloat("MoveX", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(new Vector2(0, Mathf.Sqrt(-2 * Physics2D.gravity.y * JumpHeight)), ForceMode2D.Impulse);
            if (isJumping == true)
            {
                animator.SetBool("onJump", true);
            }
            else
            {
                animator.SetBool("onJump", false);
            }
            if (jump != 0)
            {
                direction = jump < 0 ? -1 : 1;
                animator.SetFloat("JumpX", direction);
                animator.SetFloat("JumpY", (direction < 0 ? -0.8f : 0.8f));
            }
            else
            {
                animator.SetFloat("JumpX", 0);
            }
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("ifAttack", true);
            animator.SetFloat("MoveX", direction);
            
        }
        else
        {
            animator.SetBool("ifAttack", false);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
           isJumping = false;
        if (isJumping == false)
        {
            animator.SetTrigger("onGround");
        }
        else
        {
            animator.SetTrigger("onGround");
        }
        
        
    }
    int enemys = 0;

    public void addLife() { }

    public void addEnemy()
    {
        enemys++;
    }
}
