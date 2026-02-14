    using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pursuer : MonoBehaviour
{

    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private Transform target;
    [SerializeField] private float moveSpeed = 5f;

    void LateUpdate()
{
        Vector3 direction = target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        
    }
    private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
               other.GetComponent<PlayerHealth>().TakeDamage();
               transform.position -= new Vector3(15, 5, 15);
                // Implement player caught logic here (e.g., reduce health, restart level, etc.)
            }
        }
}

