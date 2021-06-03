using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private int neededExp = 70;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int health = 100;
    [SerializeField] private int lvl = 1;
    [SerializeField] private int exp = 0;
    private UiManager uiManager;
    private Camera cam;
    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        navMeshAgent = GetComponent<NavMeshAgent>();
        uiManager = FindObjectOfType<UiManager>();
        IncreaseExp(0);
        TakeDamage(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                bool interacted = false;
                IInteractable[] interactables = hit.collider.GetComponents<IInteractable>();
                foreach (IInteractable interactable in interactables)
                {
                    if (interactable.IsAvailable())
                    {
                        interactable.Interact();
                        interacted = true;
                    }
                }
                if(!interacted)navMeshAgent.SetDestination(hit.point);
            }
        }
    }

    public void IncreaseExp(int amt)
    {
        exp += amt;
        if (exp > neededExp)
        {
            lvl++;
            exp -= neededExp;
            neededExp *= lvl;
        }
        uiManager.UpdateXpUi(lvl, neededExp, exp);
    }

    public void TakeDamage(int amt)
    {
        health -= amt;
        if (health <= 0)
        {
            health = 0;
            uiManager.ShowGameOverScreen();
        }
        if (health > maxHealth) health = maxHealth;
        uiManager.UpdateHpUi(health, maxHealth);
    }
}
