using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfo : MonoBehaviour, IInteractable
{
    [SerializeField] private IntercationTrigger interactionTrigger;
    private UiManager uiManager;
    private string info = "";

    private void Awake()
    {
        uiManager = FindObjectOfType<UiManager>();

        info += "Name: " + gameObject.name + "\n";
        info += "Children: \n";
        foreach (Transform child in transform)
        {
            info += child.name + "\n";
        }
        info += "Position: " + transform.position.ToString();
    }

    public void Interact()
    {

        uiManager.ShowInfo(info, 3);
    }

    public bool IsAvailable()
    {
        return interactionTrigger.IsInRange;
    }
}
