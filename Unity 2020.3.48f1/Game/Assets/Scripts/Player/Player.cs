using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController cc;
    public Vector3 moveVector = Vector3.zero;
    public float speed;
    public float acceleration;
    public Vector3 gravity;
    public float interactionDistance;

    bool interact = false;
    bool frozen;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        interact = false;
    }

    void Control()
    {
        Vector3 newVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveVector = Vector3.Lerp(moveVector, newVector * speed + gravity, acceleration * Time.deltaTime);
        Vector3 lookVector = new Vector3(moveVector.x, 0, moveVector.z);
        if (lookVector != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(lookVector);
        }
        cc.Move(moveVector * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            interact = true;
        }
    }

    public void Freeze()
    {
        moveVector = Vector3.zero;
        frozen = true;
    }

    public void Unfreeze()
    {
        moveVector = Vector3.zero;
        frozen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!frozen)
        {
            Control();
        }
    }

    void Interact()
    {
        if (interact)
        {
            Ray interactionRay = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(interactionRay, out RaycastHit hit, interactionDistance))
            {
                if (hit.collider.CompareTag("Interactable"))
                {
                    hit.collider.gameObject.GetComponent<Interactable>().Interact();
                }
            }
            interact = false;
        }
    }

    private void FixedUpdate()
    {
        if (!frozen)
        {
            Interact();
        }
    }
}
