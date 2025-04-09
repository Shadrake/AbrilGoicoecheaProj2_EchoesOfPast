using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public Animator _crystalAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        _crystalAnimator = GetComponent<Animator>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            _crystalAnimator.SetBool("Break", true);
        }
    }
}
