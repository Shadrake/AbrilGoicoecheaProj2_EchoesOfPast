using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Animator _lampAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        _lampAnimator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Weapon"))
        {
            _lampAnimator.SetBool("LightOn", true);
        }
    }
}
