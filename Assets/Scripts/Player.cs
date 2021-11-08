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

    // damage value for testing
    public int damageValue;

    // heal value for testing
    public int healValue;

    // health up for testing
    public int healthUp;

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

        // SPACE to damage player
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(currentHealth > 0)
                TakeDamage();
        }

        // H to heal player
        if(Input.GetKeyDown(KeyCode.H)) {
            if(currentHealth < maxHealth)
                HealPlayer();
        }

        // N to decrease max health
        if(Input.GetKeyDown(KeyCode.N))
            DecreaseMaxHealth();

        // M to increase max health
        if(Input.GetKeyDown(KeyCode.M))
            IncreaseMaxHealth();

    }

    // works the same way, but executed on a fixed timer and stuck to the frame rate
    // approx 50 times a second
    void FixedUpdate() {
        // rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb.velocity = movement.normalized * moveSpeed;
        Vector2 aimDirection = mousePosition - rb.position;
        // calculate the angle so the firepoint can rotate to correctly shoot from the player
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        // because the original implementation was on the sprite and rotated the sprite
        // this is instead rotating the fire point at the center of the player
        // note this isn't perfect when we start adding colliders onto the player
        firePointRb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        firePointRb.rotation = angle;
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
            currentHealth = maxHealth;;

        healthBar.DecreaseMaxHealth(currentHealth, maxHealth);
    }

    private void IncreaseMaxHealth() {
        maxHealth = maxHealth + healthUp;
        currentHealth = maxHealth;
        healthBar.IncreaseMaxHealth(currentHealth, maxHealth);
    }
}
