using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBook : MonoBehaviour
{
    public float rotationSpeed = 60.0f;
    public GameObject player;

    private Transform playerTransform;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = player.transform;
        offset = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up) * offset.normalized * 2;
        transform.position = playerTransform.position + offset;
        transform.LookAt(playerTransform.position);

    }
}
