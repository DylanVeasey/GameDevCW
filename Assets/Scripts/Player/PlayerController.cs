using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;
    public Inventory inventory;

    private UIController uiController;

    private GameObject _mainCamera;

    public bool interact = false;

    private int playerHealth = 100;
    public InventoryUIController playerHealthUI;
    private float baseSpeed = 8f;
    private float gravity = 9.81f;
    private float jumpHeight = 20f;
    private float sprintSpeed = 5f;
    private float verticalSpeed = 0;


    private void Awake()
    {
        // get a reference to our main camera
        if (_mainCamera == null)
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
        uiController = GameObject.Find("UIController").GetComponent<UIController>();
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        Interact();
    }

    // Checks for when the player collides with an object.
    private void OnTriggerEnter(Collider other) 
    {
        if(other.TryGetComponent(out InstanceItemContainer foundItem)){
            inventory.AddItem(foundItem.TakeItem());
        }
    }

    public void dealDamage(int damage)
    {
        // If the damage would take the players health to 0 or below, set the health to 0 and kill the player
        if(playerHealth - damage <= 0)
        {
            // Update health
            playerHealth = 0;
            // Update UI
            playerHealthUI.updateUI(playerHealth);

            // Kill the player
            GameOver();
        }
        else
        {
            playerHealth = playerHealth - damage;
            // Update UI
            playerHealthUI.updateUI(playerHealth);

        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        playerHealth = 100;
        uiController.ActivateGameOverScreen();
    }


    private void OnInteract(InputValue value)
    {
        interact = value.isPressed;
    }

    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float vertiacalMove = Input.GetAxis("Vertical");
         
        if (characterController.isGrounded)
        {
            verticalSpeed = 0f;
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }
        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);
        Vector3 move = transform.forward * vertiacalMove + transform.right * horizontalMove;
        characterController.Move(baseSpeed * Time.deltaTime * move + gravityMove * Time.deltaTime);
    }

    private void OnDropItem()
    {
        inventory.RemoveCurrentItem();
    }

    // TODO: This section needs to be re built in order to account for objects that are a different type of interactable,
    // such as items that can be picked up.
    private void Interact()
    {
        if (interact)
        {
            int layerMask = 1 << 8;

            RaycastHit hit;
            // Check if a forward raycast hits an object on the 'Interactable' Layer
            if (Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.TransformDirection(Vector3.forward), out hit, 3.0f, layerMask))
            {
                Debug.DrawRay(_mainCamera.transform.position, _mainCamera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow, 40);

                    IInteractable possibleInteractableObject = hit.collider.gameObject.GetComponent<IInteractable>();
                    if (possibleInteractableObject != null)
                    {
                        possibleInteractableObject.TryInteract();
                    }
                
            }

            // Check if a foward raycast hits an object on any layer
            if (Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.TransformDirection(Vector3.forward), out hit, 3.0f))
            {
                // Check if the object hit has an 'InstanceItemContainer' Class
                if (hit.collider.gameObject.TryGetComponent(out InstanceItemContainer foundInstanceItemContainer))
                {
                    inventory.AddItem(foundInstanceItemContainer.TakeItem());
                }
            }



            interact = false;
        }
    }

    private void OnPause()
    {
        uiController.ActivatePausedScreen();
    }

    private void OnSelectSlot1()
    {
        inventory.setCurrentSlot(0);
    }

    private void OnSelectSlot2()
    {
        inventory.setCurrentSlot(1);
    }

    private void OnSelectSlot3()
    {
        inventory.setCurrentSlot(2);
    }
}
