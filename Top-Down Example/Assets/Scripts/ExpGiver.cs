using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpGiver : MonoBehaviour, IInteractable
{
    [SerializeField] private int expPerClick = 25;
    [SerializeField] private IntercationTrigger interactionTrigger;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void Interact()
    {
        playerController.IncreaseExp(expPerClick);
    }

    public bool IsAvailable()
    {
        return interactionTrigger.IsInRange;
    }
}
