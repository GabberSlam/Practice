using System.Threading;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    private Rigidbody rb;
    private GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        if(Horizontal!=0 || Vertical != 0)
        {
            Spin(Vertical,0,Horizontal);
        }
    }

    private void Spin(float x, float y, float z)
    {
        Vector3 torque = new Vector3(x, y, z*-1);
        rb.AddTorque(torque*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            gameManager.Win();
        }
        if (other.CompareTag("Danger")) { 
            gameManager.Lose();
        }
    }
}
