using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Enemy _enemy;
    public Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<Enemy>();
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Weapon"))
        {
            StartCoroutine(EnemyDamaged());
        }
    }

    private IEnumerator EnemyDamaged()
    {
        _enemy.enemyLife -= 1f;;
        _animator.SetBool("Damaged", true);

        yield return new WaitForSeconds(1f);

        _animator.SetBool("Damaged", false);


        if(_enemy.enemyLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}
