using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour, IInteractable
{
    [SerializeField] private float maxHealth = 40f;
    [SerializeField] private float pointsPerHit = 15f;
    [SerializeField] private GameObject model;
    [SerializeField] private GameObject pieces;
    [SerializeField] private IntercationTrigger interactionTrigger;
    private float health;


    private void Awake()
    {
        health = maxHealth;
        
    }

    public void Interact()
    {
        health -= pointsPerHit;
        if (health <= 0)
        {
            StartCoroutine(Breack());
        }
    }

    public bool IsAvailable()
    {
        return interactionTrigger.IsInRange;
    }

    private IEnumerator Breack()
    {
        model.active = false;
        pieces.active = true;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
