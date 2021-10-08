using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float movement;
    public float MovementSpeed = 8f;
    public float jumpForce = 24f;

    public AudioSource jumpAudio, dieAudio;

    bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    Rigidbody2D characterRigid;
    Animator animator;
    BoxCollider2D collision;
    SpriteRenderer sprite;
    
    // Start is called before the first frame update
    void Start()
    {
        characterRigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collision = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        FlipCharacter();
       
        isGrounded = Physics2D.BoxCast(collision.bounds.center,collision.bounds.size,0f,Vector2.down,.1f,groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
            isGrounded = false;
        }

        Animation();
    }

    void Move()
    {
        movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0f, 0f) * Time.deltaTime * MovementSpeed;
    }


    //FlipCharacter
    void FlipCharacter()
    {
        if (movement < 0)
        {
            sprite.flipX = true;
        }
        else if (movement > 0)
        {
            sprite.flipX = false;
        }
    }

    void Jump()
    {
        characterRigid.velocity = Vector2.up * jumpForce;
        jumpAudio.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trap"))
        {
            PlayerDie();
        }
    }

    void PlayerDie()
    {
        animator.SetTrigger("IsDeath");
        characterRigid.bodyType = RigidbodyType2D.Static;
        dieAudio.Play();
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Animation()
    {
        animator.SetFloat("Speed", Mathf.Abs(movement));
        animator.SetBool("IsJump", !isGrounded);
    }

}