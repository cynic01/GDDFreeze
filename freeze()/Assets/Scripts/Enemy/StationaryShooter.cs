using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryShooter : MonoBehaviour
{

    #region hackable_variables
    [SerializeField]
    [Tooltip("The angle at which this enemy shoots.")]
    public Quaternion angle;
    #endregion

    #region angle_variables
    double epsilon = 1.0e-5;
    float smooth = 5.0f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        angle = Quaternion.Euler(0, -1, 0);;
    }

    // Update is called once per frame
    void Update()
    {
        if (Quaternion.Dot(angle, transform.rotation) < epsilon) {
            transform.rotation = Quaternion.Slerp(transform.rotation, angle,  Time.deltaTime * smooth);
        }
    }
}
