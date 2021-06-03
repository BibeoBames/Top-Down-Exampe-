using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntercationTrigger : MonoBehaviour
{
    public bool IsInRange { get; private set; } = false;

    [SerializeField] private float range = 4;
    [SerializeField] private GameObject indicator;

    private void Awake()
    {
        GetComponent<SphereCollider>().radius = range;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsInRange = true;
            indicator.active = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            IsInRange = false;
            indicator.active = false;
        }
    }
}
