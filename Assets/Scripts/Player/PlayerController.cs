using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;

    private GameObject _mainCamera;

    public bool interact = false;

    public float baseSpeed = 12f;
    public float gravity = 9.81f;
    public float jumpHeight = 3f;
    public float sprintSpeed = 5f;
    public float verticalSpeed = 0;


    private void Awake()
    {
        // get a reference to our main camera
        if (_mainCamera == null)
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }

    private void OnInteract(InputValue value)
    {
        interact = value.isPressed;
       
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        Interact();
    }

    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float vertiacalMove = Input.GetAxis("Vertical");

        if (characterController.isGrounded)
        {
            verticalSpeed = 0;
        }
        else
        {
            verticalSpeed -= gravity * Time.deltaTime;
        }

        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);
        Vector3 move = transform.forward * vertiacalMove + transform.right * horizontalMove;
        characterController.Move(baseSpeed * Time.deltaTime * move + gravityMove * Time.deltaTime);
    }

    private void Interact()
    {
        if (interact)
        {
            int layerMask = 1 << 8;

            RaycastHit hit;
            if (Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log("HIt");
                Debug.DrawRay(_mainCamera.transform.position, _mainCamera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow, 40);
                IInteractable possibleInteractableObject = hit.collider.gameObject.GetComponent<IInteractable>();
                if (possibleInteractableObject != null)
                    possibleInteractableObject.TryInteract();
            }

            interact = false;
        }
    }

}
