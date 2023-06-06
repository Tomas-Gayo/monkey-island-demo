using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator PlayerAnimator;
    [SerializeField] RectTransform healthUI;

    private float heartSize = 48f;

    // Animator controller -> depending on the static variable the animation starts or stops
    void Update()
    {
        if (AnimatorStates.isPlayerAttacking == true)
        {
            PlayerAnimator.SetBool("isAttacking", true);
        } 
        else
        {
            PlayerAnimator.SetBool("isAttacking", false);
        }

        if (AnimatorStates.isPlayerDeath == true)
        {
            PlayerAnimator.SetBool("isDeath", true);
        }
        else
        {
            PlayerAnimator.SetBool("isDeath", false);
        }

        if (AnimatorStates.isPlayerHurt == true)
        {
            PlayerAnimator.SetBool("isHurt", true);
        }
        else
        {
            PlayerAnimator.SetBool("isHurt", false);
        }
    }

    // Method to controll the life bar by passing a count which corresponds to the number of lifes of the player
    // basically the heart UI has a fix size and when the player loses we substract 1/3 of this size
    public void AddDamage(int count)
    {
        healthUI.sizeDelta = new Vector2(heartSize*count, heartSize);
    }
}
