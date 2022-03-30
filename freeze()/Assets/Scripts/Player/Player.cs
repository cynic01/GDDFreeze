using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    #endregion

    #region health_variables
    public float maxHealth;
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
        movePlayer();

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
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
            playerRB.AddForce(new Vector2(0, jumpForce));
        }
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
    }
    #endregion
}


