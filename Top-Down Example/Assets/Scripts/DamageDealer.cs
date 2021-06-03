using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour, IInteractable
{
    [SerializeField] private int damage = 25;
    [SerializeField] private IntercationTrigger interactionTrigger;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void Interact()
    {

        playerController.TakeDamage(damage);
    }

    public bool IsAvailable()
    {
        return interactionTrigger.IsInRange;
    }
}
