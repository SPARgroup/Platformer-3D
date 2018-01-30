 using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float LookSensitivity = 3f;

    private PlayerMotor Motor;

	// Use this for initialization
	void Start () {
        Motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {

        //calculate velocity magnitude and direction
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        //horizontal and vertical vectors
        Vector3 MovHorizontal = transform.right * xMov;
        Vector3 MovVertical = transform.forward * zMov;

        //calculate final velocity vector 
        Vector3 _velocity = (MovHorizontal + MovVertical).normalized * speed;

        //apply movement
        Motor.Move(_velocity);

        //calculate rotation as a 3D vector; turning around
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot , 0f) * LookSensitivity;

        //apply player rotation
        Motor.rotate(_rotation);

        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(0f, _xRot, 0f) * LookSensitivity;

        Motor.rotateCamera(_cameraRotation);


    }
}
