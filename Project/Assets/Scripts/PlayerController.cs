using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject projectile;
    public GameObject spellBook;
    private GameManager gameManager;
    private float movementX;
    private float movementY;
    public float speed = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void OnFire()
    {
        Instantiate(projectile, spellBook.transform.position, spellBook.transform.rotation);
        
    }

    private void OnGameExit()
    {
        SceneManager.LoadScene("Main Menu");

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed * Time.deltaTime, ForceMode.Impulse);
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("OOB"))

            SceneManager.LoadScene("Main Menu");
        }

    }




