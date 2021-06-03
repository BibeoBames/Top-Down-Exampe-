using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs;

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            int i = Random.Range(0, prefabs.Count);
            Instantiate(prefabs[i], child.position, Quaternion.identity);
        }
    }
}
