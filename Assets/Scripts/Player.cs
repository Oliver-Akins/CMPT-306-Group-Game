using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//Player movement// can change as needed
	// move speed baseline
    public float moveSpeed = 5f;

    // used to manipluate the driver/rigid body
    public Rigidbody2D rb;

    public Rigidbody2D firePointRb;

	// for animations this can be used with the blend tree
    public Animator animator; 
    
    // Camera reference to handle aiming weapon attacks
    public Camera cam;

    Vector2 movement;
    Vector2 mousePosition;
    
    // player max health
    public int maxHealth;

    // player current health - initializes to max health at start
    public int currentHealth;

    // player health bar
    public HealthBar healthBar;

    // player strength
    public int strength;

    //player agility
    public int agility;

    //player stamina
    public int stamina;

    //player skill coins
    public int skillCoins;


    // Start() is called when script is enabled
    void Start() {
        // initialize max health to inspector value input
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    // not good for physics D: but great for inputs
    void Update() {

        // gives a value between -1 and 1 depending on which key left or right,
		// but if no move in this direction will return 0
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

		// Sets the animation when we need it
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        // more optimized with square root magnitude as we won't need to calculate it on the vector
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // for testing - delete if needed
        if(Input.GetKeyDown(KeyCode.Space))
            if(currentHealth > 0)
                TakeDamage(100);

        if(Input.GetKeyDown(KeyCode.H))
            if(currentHealth < maxHealth)
                HealPlayer(100);

        if(Input.GetKeyDown(KeyCode.N))
            DecreaseMaxHealth(100);

        if(Input.GetKeyDown(KeyCode.M))
            IncreaseMaxHealth(100);
    }

    // works the same way, but executed on a fixed timer and stuck to the frame rate
    // approx 50 times a second
    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 aimDirection = mousePosition - rb.position;
        // calculate the angle so the firepoint can rotate to correctly shoot from the player
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        // because the original implementation was on the sprite and rotated the sprite
        // this is instead rotating the fire point at the center of the player
        // note this isn't perfect when we start adding colliders onto the player
        firePointRb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        firePointRb.rotation = angle;
    }

    public void TakeDamage(int damageValue) {
        currentHealth -= damageValue;
        healthBar.SetCurrentHealth(currentHealth);
    }

    public void HealPlayer(int healValue) {
        currentHealth += healValue;
        healthBar.SetCurrentHealth(currentHealth);
    }

    public void DecreaseMaxHealth(int healthDown) {
        maxHealth -= healthDown;

        if(currentHealth > maxHealth)
            currentHealth = maxHealth;;

        healthBar.DecreaseMaxHealth(currentHealth, maxHealth);
    }

    public void IncreaseMaxHealth(int healthUp) {
        maxHealth += healthUp;
        currentHealth += healthUp;
        healthBar.IncreaseMaxHealth(currentHealth, maxHealth);
    }
}
