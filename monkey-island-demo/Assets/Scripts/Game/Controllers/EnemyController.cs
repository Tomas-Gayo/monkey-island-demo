using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator EnemyAnimator;
    [SerializeField] RectTransform healthUI;

    private float heartSize = 48f;


    // Animator controller -> depending on the static variable the animation starts or stops
    void Update()
    {
        if (AnimatorStates.isEnemyAttacking == true)
        {
            EnemyAnimator.SetBool("isAttacking", true);
        } 
        else
        {
            EnemyAnimator.SetBool("isAttacking", false);
        }

        if (AnimatorStates.isEnemyDeath == true)
        {
            EnemyAnimator.SetBool("isDeath", true);
        }
        else
        {
            EnemyAnimator.SetBool("isDeath", false);
        }

        if (AnimatorStates.isEnemyHurt == true)
        {
            EnemyAnimator.SetBool("isHurt", true);
        }
        else
        {
            EnemyAnimator.SetBool("isHurt", false);
        }
    }

    // Method to controll the life bar by passing a count which corresponds to the number of lifes of the enemy
    // basically the heart UI has a fix size and when the enemy loses we substract 1/3 of this size
    public void AddDamage(int count)
    {
        healthUI.sizeDelta = new Vector2(heartSize * count, heartSize);
    }
}
