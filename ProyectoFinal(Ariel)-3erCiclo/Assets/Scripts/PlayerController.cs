using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float MovementVelocity;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private GaugeData gaugeData;
    [SerializeField] private Canvas Options;
    public AudioSource steps;
    public AudioSource pickup;
    private Vector3 cameraForward;
    private Quaternion targetRotation;
    private Vector3 forwardMovement;
    private Vector3 rightMovement;

    private Animator anim;
    private Vector2 movementInput;
    private bool isPickingUp = false;
    private GameObject currentObject;  

    private void Awake()
    {
        Options = AudioManager.Instance.OptionsCanvas;
        Options.GetComponent<CanvasManager>().MenúCanvas.SetActive(false);
        anim = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
        gaugeData.ResetGauge();
    }

    private void Update()
    {
        cameraForward = cameraTransform.forward;
        cameraForward.y = 0f;

        targetRotation = Quaternion.LookRotation(cameraForward);
        transform.rotation = targetRotation;

        forwardMovement = transform.forward * movementInput.y * MovementVelocity * Time.deltaTime;
        rightMovement = transform.right * movementInput.x * MovementVelocity * Time.deltaTime;
        transform.position += forwardMovement + rightMovement;

        anim.SetInteger("VelX", (int)movementInput.x);
        anim.SetInteger("VelY", (int)movementInput.y);
        anim.SetFloat("VelXF", movementInput.x);
        anim.SetFloat("VelYF", movementInput.y);

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && isPickingUp)
        {
            isPickingUp = false;
            anim.SetBool("Pick", false);
            if (currentObject != null)
            {
                currentObject.GetComponent<EsfumarseAlRecoger>().Esfumarse();
                currentObject = null;  
            }
        }

        if (isPickingUp)
        {
            movementInput = Vector2.zero;
        }
        
        DiagonalAnimations();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        if(context.performed)
        {
            steps.Play();
        }
        else
        {
            steps.Stop();
        }
    }

    public void DiagonalAnimations()
    {
        if (movementInput.x > 0.7f && movementInput.y > 0.7)
        {
            anim.SetBool("DiagonalMirror", true);
        }
        else
        {
            anim.SetBool("DiagonalMirror", false);
        }
        if (movementInput.x < -0.7f && movementInput.y > 0.7)
        {
            anim.SetBool("Diagonal", true);
        }
        else
        {
            anim.SetBool("Diagonal", false);
        }
        if (movementInput.x < -0.7f && movementInput.y < -0.7)
        {
            anim.SetBool("BackDiagonalMirror", true);
        }
        else
        {
            anim.SetBool("BackDiagonalMirror", false);
        }
        if (movementInput.x > 0.7f && movementInput.y < -0.7)
        {
            anim.SetBool("BackDiagonal", true);
        }
        else
        {
            anim.SetBool("BackDiagonal", false);
        }
    }

    public void PickUp(InputAction.CallbackContext context)
    {
        if (context.performed && !isPickingUp)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1f);

            bool foundSafeObject = false;
            bool foundUnSafeObject = false;
            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].tag == "SafeObject")
                {
                    pickup.Play();
                    foundSafeObject = true;
                    isPickingUp = true;
                    anim.SetBool("Pick", true);
                    currentObject = hitColliders[i].gameObject;

                    if (gaugeData != null)
                    {
                        gaugeData.AddToGauge(20f);
                    }
                    break;
                }
                else if (hitColliders[i].tag == "UnSafeObject")
                {
                    pickup.Play();
                    foundUnSafeObject = true;
                    isPickingUp = true;
                    anim.SetBool("Pick", true);
                    currentObject = hitColliders[i].gameObject;

                    if (gaugeData != null)
                    {
                        gaugeData.AddToGauge(-10f);
                    }
                    break;
                }
            }
            if (!foundSafeObject)
            {
                Debug.Log("No se encontraron objetos seguros cerca del jugador.");
            }
            if (!foundUnSafeObject)
            {
                Debug.Log("No se encontraron objetos no seguros cerca del jugador.");
            }
        }
        else if (isPickingUp)
        {
            Debug.Log("Ya se está recogiendo un objeto.");
        }
    }
    public void PauseGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Options.GetComponent<CanvasManager>().ShowAudioSettings();
            Options.GetComponent<CanvasManager>().EnableBacktoMenu();
        }
    }
}







