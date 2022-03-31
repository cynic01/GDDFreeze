using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryShooter : MonoBehaviour
{

    #region hackable_variables
    [SerializeField]
    [Tooltip("The angle at which this enemy shoots.")]
    public Quaternion player_pos;
    #endregion

    #region angle_variables
    double epsilon = 1.0e-5;
    float rotation_speed = 5.0f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Quaternion.Dot(player_pos, transform.rotation) < epsilon) {
            var step = rotation_speed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, player_pos,  step);
        }
    }
}
