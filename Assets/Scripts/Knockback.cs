using System.Collections;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("enemy"))
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();

            if(enemy != null && enemy.velocity == Vector2.zero)
            {
                enemy.GetComponent<Animator>().SetBool("isStunned", true);
                StartCoroutine(KnockCo(enemy));
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if(enemy != null)
        {
            Vector2 difference = (enemy.transform.position - transform.position).normalized * thrust;
            enemy.velocity = difference;
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<Animator>().SetBool("isStunned", false);
        }
    }
}
