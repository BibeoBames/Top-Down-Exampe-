using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private Transform playerPosition;
    [SerializeField] private Vector3 offset = new Vector3(0,7,-5); 

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerPosition.position + offset;
    }
}
