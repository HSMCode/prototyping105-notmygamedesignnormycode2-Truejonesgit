using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public float movementSpeed;
    public Rigidbody2D rb;

    private Vector2 moveDirection;
    public int countToWin;
    public int foodCount;

    public ParticleSystem footstepsEffect, impactEffect;
    public ParticleSystem.EmissionModule footEmission;

    public float dashSpeed;
    public float dashTime;
    public float startDashTime;
    public bool isDashing;


    private void Start()
    {
        footEmission = footstepsEffect.emission;
        dashTime = startDashTime;
    }


    // Update is called once per frame
    void Update()
    {
        ProcessInput();

        if (moveDirection.x != 0 || moveDirection.y != 0)
        {
            footEmission.rateOverTime = 35f;
        }
        else
        {
            footEmission.rateOverTime = 0f;
        }


        if (dashTime <= 0f)
        {
            isDashing = false;
            dashTime = startDashTime;
        }
        else
        {
            dashTime -= Time.deltaTime;
        }


    }

        private void FixedUpdate()
    {
        Move();
        
        if (Input.GetKey(KeyCode.Space) && !isDashing)
            
        {
            isDashing = true;
            rb.velocity = new Vector2(moveDirection.x * dashSpeed, moveDirection.y * dashSpeed);
        }
        
    }

    void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized; 
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);  
    }

    private void OnTriggerEnter2D (Collider2D collision){
        if(collision.CompareTag("Food")){
            print("I FOUND SOME FOOD!");

            impactEffect.gameObject.SetActive(true);
            impactEffect.Stop();
            impactEffect.transform.position = collision.transform.position;
            impactEffect.Play();

            Destroy(collision.gameObject);
            foodCount += 1;
            
            if(foodCount == countToWin && !gameManager.lastLevel)
            {
                Debug.Log("I GOT ALL OF THE FOOD!");
                gameManager.Win();       
            }
            else if(foodCount == countToWin && gameManager.lastLevel)
            {
                gameManager.WinGame();
            }

            }


        }

    }

