/******************************************************************************
Author: Elyas Chua-Aziz

Name of Class: DemoPlayer

Description of Class: This class will control the movement and actions of a 
                        player avatar based on user input.

Date Created: 09/06/2021
******************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SamplePlayer : MonoBehaviour
{
    /// <summary>
    /// The distance this player will travel per second.
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    public float rotationSpeed;


    /// <summary>
    /// The camera attached to the player model.
    /// Should be dragged in from Inspector.
    /// </summary>
    public GameObject playerCamera;

    public string currentState;

    public string nextState;

    private Rigidbody rb;
    [SerializeField]
    public static bool lockCursor = true;

    public int playerhealth = 30;

    //sense pickup object;

    public float pickupdistance = 10f;
    public interactable sensedobject = null;
    public Camera fpscamera = null;
<<<<<<< HEAD
=======


>>>>>>> 98f4f714121b3d3d838896e90442c9f866657496

    public GameObject m_GotHitScreen;





    // Start is called before the first frame update
    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }
        nextState = "Idle";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            gotHurt();
        }
    }

    void gotHurt()
    {
        var color = m_GotHitScreen.GetComponent<Image>().color;
        color.a = 0.8f;

        m_GotHitScreen.GetComponent<Image>().color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextState != currentState)
        {
            SwitchState();
        }

        CheckRotation();

        //world postion of where the mouse curosr is pointing at where we are looking towards to 
        Ray ray = fpscamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, pickupdistance))
        {
            //when hit something 

            interactable obj = hit.collider.GetComponent<interactable>();
            if (obj)
            {
                sensedobject = obj;
            }
            else
            {
                sensedobject = null;
            }
        }
        else
        {
            //if no hit anything 
            sensedobject = null;
        }

        if (Input.GetMouseButton(0) && sensedobject)
        {

            Debug.LogFormat("Used :{0} of type {1} amount :{2}", sensedobject.name, sensedobject.pickuptype, sensedobject.amount);
            //apply amount of the amount of the part by destroy/consume the object 
            if (sensedobject.name == "coins")
            {
                Debug.Log("coinsyay");
                GameManager.coincollect += sensedobject.amount;

            }
            if (sensedobject.name == "ammo")
            {
                Debug.Log("amoosds");
            }
            Destroy(sensedobject.gameObject);
        }

<<<<<<< HEAD
        if (m_GotHitScreen != null)
        {
            if (m_GotHitScreen.GetComponent<Image>().color.a > 0)
            {
                var color = m_GotHitScreen.GetComponent<Image>().color;
                color.a -= 0.01f;
                m_GotHitScreen.GetComponent<Image>().color = color;
            }
        }

=======
>>>>>>> 98f4f714121b3d3d838896e90442c9f866657496
    }

    /// <summary>
    /// Sets the current state of the player
    /// and starts the correct coroutine.
    /// </summary>
    private void SwitchState()
    {
        StopCoroutine(currentState);

        currentState = nextState;
        StartCoroutine(currentState);
    }

    private IEnumerator Idle()
    {
        while (currentState == "Idle")
        {
            if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0)
            {
                nextState = "Moving";
            }
            yield return null;
        }
    }

    private IEnumerator Moving()
    {
        while (currentState == "Moving")
        {
            if (CheckMovement())
            {
                nextState = "Idle";
            }
            yield return null;
        }
    }


    public void CheckRotation()
    {
        Vector3 playerRotation = transform.rotation.eulerAngles;
        playerRotation.y += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(playerRotation);

        Vector3 cameraRotation = playerCamera.transform.rotation.eulerAngles;
        cameraRotation.x += Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        //adjust the rotation to prevent camera turn upside down with adjusted camerarotation

        if (cameraRotation.x < 150 && cameraRotation.x > 0)
        {
            cameraRotation.x = Mathf.Clamp(cameraRotation.x, 0, 90);
        }
        if (cameraRotation.x < -90 && cameraRotation.x < 0)
        {
            cameraRotation.x = Mathf.Clamp(cameraRotation.x, 0, -90);
        }

        playerCamera.transform.rotation = Quaternion.Euler(cameraRotation);
    }

    /// <summary>
    /// Checks and handles movement of the player
    /// </summary>
    /// <returns>True if user input is detected and player is moved.</returns>
    public bool CheckMovement()
    {
        /*return false;*/
        Vector3 newPos = transform.position;

        Vector3 xMovement = transform.right * Input.GetAxis("Horizontal");
        Vector3 zMovement = transform.forward * Input.GetAxis("Vertical");

        Vector3 movementVector = xMovement + zMovement;

        if (movementVector.sqrMagnitude > 0)
        {
            movementVector *= moveSpeed * Time.deltaTime;
            newPos += movementVector;

            transform.position = newPos;
            return false;
        }
        else
        {
            return true;
        }

    }

}
