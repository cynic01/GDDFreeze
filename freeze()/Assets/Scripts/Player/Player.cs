using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    #region movement_variables
    [SerializeField]
    [Tooltip("speed modifier for the player")]
    private float moveSpeed;
    public float maxSpeed;
    public float jumpForce;
    public bool onGround;
    float MoveHor;
    Rigidbody playerRB;
    private float rotation_speed = 5.0f;
    private float epsilon = 0.01f;
    #endregion

    #region health_variables
    public float maxHealth = 100f;
    float curHealth;
    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        MoveHor = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(MoveHor - transform.forward.x) < epsilon) {
            movePlayer();
        } else {
            rotatePlayer();
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
            playerRB.AddForce(new Vector2(0, jumpForce));
        }
    }

    void movePlayer()
    {
        Vector2 movement = new Vector2(MoveHor * moveSpeed, 0);
        movement = movement * Time.deltaTime;

        playerRB.AddForce(movement);
        if (playerRB.velocity.x > maxSpeed)
        {
            playerRB.velocity = new Vector2(maxSpeed, playerRB.velocity.y);
        }
        if (playerRB.velocity.x < -maxSpeed)
        {
            playerRB.velocity = new Vector2(-maxSpeed, playerRB.velocity.y);
        }
    }

    void rotatePlayer() {
        // Determine which direction to rotate towards
        Vector3 targetDirection = new Vector3(MoveHor, 0, 0);

        // The step size is equal to speed times frame time.
        float singleStep = rotation_speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
    
    #region health_functions
    public void TakeDamage(float val)
    {
        curHealth -= val;
        if (curHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    #endregion
}


