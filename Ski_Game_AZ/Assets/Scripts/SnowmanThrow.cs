using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanThrow : MonoBehaviour
{
    public GameObject snowBall;
    public float throwDistance;
    public int throwSpeed;
    private bool justThown = false;
    private GameObject target;
    [SerializeField] private Vector3 upwardsOffset = new Vector3(0, 0.33f, 0);

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }
    void Update()
    {
        if (Time.frameCount % 5 == 0)
        {
            float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
            
            if (distanceToTarget < throwDistance && justThown == false)
            {
                ThrowSnowball();
            }
        }
    }
    void ThrowOver()
    {
        justThown = false;
    }

    void ThrowSnowball()
    {
        justThown = true;
        GameObject tempSnowBall = Instantiate(snowBall, transform.position, transform.rotation);
        Rigidbody tempRb = tempSnowBall.GetComponent<Rigidbody>();
        Vector3 targetDirection = Vector3.Normalize(target.transform.position - transform.position);
                
        targetDirection += upwardsOffset;
        tempRb.AddForce(targetDirection * throwSpeed);
        Invoke("ThrowOver", 0.1f);
    }
}
