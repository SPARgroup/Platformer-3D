 using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    [SerializeField]
    private Camera cam;

    private Rigidbody rb;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    //gets a movement vector
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    //gets a rotation vector
    public void rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    //gets a camera rotation vector
    public void rotateCamera(Vector3 _cameraRotation)
    {
       cameraRotation = _cameraRotation;
    }

    //run every physics iteration
    void FixedUpdate () {
        PerformMovement();
        PerformRotation();
	}

    //perform movement based on velocity variable
    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position - velocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }
    }
}
