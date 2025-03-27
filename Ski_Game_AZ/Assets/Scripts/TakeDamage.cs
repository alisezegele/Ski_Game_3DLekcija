using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public bool isHurt = false;
    [SerializeField] private float backForce, upForce, stunTime;
    
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        PlayerEvents.onHitEvent += TakeDmg;
    }
    private void OnDisable()
    {
        PlayerEvents.onHitEvent -= TakeDmg;
    }
    private void TakeDmg()
    {
        if (rb != null)
        {
            rb.AddForce(transform.up * upForce);
            rb.AddForce(transform.forward * -backForce);
        }
        isHurt = true;
        StartCoroutine(Recover());
        Debug.Log("Player took damage");
    }

    private IEnumerator Recover()
    {
        yield return new WaitForSeconds(stunTime);
        isHurt = false;
    }
}