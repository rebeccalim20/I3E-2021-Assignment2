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

    public Transform FirstTarget;
    public Transform SecondTarget;
    public Transform ThirdTarget;
    public Transform FourthTarget;
    public GameObject m_GotHitScreen;

    public GameObject loadingscreen;


    //audio source sound effect
    public AudioClip  coineffect;
    public AudioClip injured;
    public AudioClip Ammopicks;
    public AudioClip teleportsaudio;
    AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
       
        nextState = "Idle";

        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }

        audioSource = GetComponent<AudioSource>();


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            audioSource.PlayOneShot(injured, 0.7F);
            gotHurt();
        }

        void gotHurt()
        {
            var color = m_GotHitScreen.GetComponent<Image>().color;
            color.a = 0.8f;
            m_GotHitScreen.GetComponent<Image>().color = color;
        }
    }


    // Update is called once per frame
    void Update()
    {
       

        if (nextState != currentState)
        {
            SwitchState();
        }

        CheckRotation();
        detectpickupobject();


        if (m_GotHitScreen != null)
        {
            if (m_GotHitScreen.GetComponent<Image>().color.a > 0)
            {
                var color = m_GotHitScreen.GetComponent<Image>().color;
                color.a -= 0.01f;
                m_GotHitScreen.GetComponent<Image>().color = color;
            }
        }

    }

    void detectpickupobject()
    {
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

        if (Input.GetKey(KeyCode.E) && sensedobject)
        {

            Debug.LogFormat("Used :{0} of type {1} amount :{2}", sensedobject.name, sensedobject.pickuptype, sensedobject.amount);
            //apply amount of the amount of the part by destroy/consume the object 
            if (sensedobject.name == "coins")
            {
                GameManager.coincollect += sensedobject.amount;
                audioSource.PlayOneShot(coineffect, 0.7F);
                Destroy(sensedobject.gameObject);

            }
            if (sensedobject.name == "ammopickup")
            {
                audioSource.PlayOneShot(Ammopicks, 0.7F);
                GameManager.ammoleft += sensedobject.amount;
              Destroy(sensedobject.gameObject);
            }
            if (sensedobject.name == "key")
            {
                
                GameManager.key += sensedobject.amount;
                Destroy(sensedobject.gameObject);
            }
            if (sensedobject.name == "healthpickup")
            {

                GameManager.playerhealth += sensedobject.amount;
                Destroy(sensedobject.gameObject);
            }

            if(sensedobject.name =="teleportpad")
            {
                audioSource.PlayOneShot(teleportsaudio, 0.7F);
                loadingscreen.SetActive( true);
                Invoke("teleport1", 2f);
            }
            if (sensedobject.name == "teleportpad3")
            {
                audioSource.PlayOneShot(teleportsaudio, 0.7F);
                loadingscreen.SetActive(true);
                Invoke("teleport3", 2f);
            }
            if (sensedobject.name == "teleportpad4")
            {
                audioSource.PlayOneShot(teleportsaudio, 0.7F);
                loadingscreen.SetActive(true);
                Invoke("teleport4", 2f);
                
            }
            if (sensedobject.name =="gun")
            {
                GameManager.pistol.SetActive(true);
            }

            
        }

    }


    //teleporting class
    void teleport1()
    {
        loadingscreen.SetActive(false);
        this.transform.position = SecondTarget.transform.position;
    }

    void teleport3()
    {
        loadingscreen.SetActive(false);
        this.transform.position = FourthTarget.transform.position;
    }
    void teleport4()
    {
        loadingscreen.SetActive(false);
        this.transform.position = FirstTarget.transform.position;
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
