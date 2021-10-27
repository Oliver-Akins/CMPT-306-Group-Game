using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//Player movement// can change as needed
	// move speed baseline
    public float moveSpeed = 5f;

    // used to manipluate the driver/rigid body
    public Rigidbody2D rb;

	// for animations this can be used with the blend tree
    public Animator animator; 

    Vector2 movement;

    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private int damageValue;
    [SerializeField] private int healValue;
    [SerializeField] private int healthUp;
    [SerializeField] private HealthBar healthBar;

    void Start() {

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    // not good for physics D: but great for inputs
    void Update()
    {
        // gives a value between -1 and 1 depending on which key left or right, 
		// but if no move in this direction will return 0 
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

		// Sets the animation when we need it
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        // more optimized with square root magnitude as we won't need to calculate it on the vector
        animator.SetFloat("Speed", movement.sqrMagnitude);



        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(currentHealth > 0)
            {
                TakeDamage();
            }
        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            if(currentHealth < maxHealth)
            {
                HealPlayer();
            }
        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            DecreaseMaxHealth();
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            IncreaseMaxHealth();
        }

    }

    // works the same way, but executed on a fixed timer and stuck to the frame rate
    // approx 50 times a second
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    private void TakeDamage() {

        currentHealth = currentHealth - damageValue;
        healthBar.SetCurrentHealth(currentHealth);
    }
    
    private void HealPlayer() {

        currentHealth = currentHealth + healValue;
        healthBar.SetCurrentHealth(currentHealth);
    }
    
    private void DecreaseMaxHealth() {

        maxHealth = maxHealth - healthUp;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;;
        }
            
        healthBar.DecreaseMaxHealth(currentHealth, maxHealth);
    }

    private void IncreaseMaxHealth() {
        
        maxHealth = maxHealth + healthUp;

        currentHealth = maxHealth;

        healthBar.IncreaseMaxHealth(currentHealth, maxHealth);
    }
}