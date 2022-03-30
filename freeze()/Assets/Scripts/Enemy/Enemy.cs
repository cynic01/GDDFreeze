using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int curHealth;
    public int maxHealh;

    #region health_functions
    public void TakeDamage(int val)
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
