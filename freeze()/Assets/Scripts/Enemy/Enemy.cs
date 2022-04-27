using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // override these if wanted
    [SerializeField]
    [Tooltip("The maximum health of this enemy.")]
    protected int maxHealth = 100;
    protected int curHealth;

    #region hackable_variables
    [SerializeField]
	[Tooltip("Whether this enemy tracking anything.")]
	public bool on = true;

    [SerializeField]
    [Tooltip("The GameObject tag this enemy chases.")]
    protected string attackTag = "Player";
    #endregion

    #region abstract_functions
    public abstract void Attack(GameObject other);
    #endregion

    #region hacking_functions
    public virtual void ChangeAttackTag(string newTag) {
        attackTag = newTag;
    }
    #endregion

    #region health_functions
    public virtual void TakeDamage(int val)
    {
        curHealth -= val;
        if (curHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
    #endregion


}
