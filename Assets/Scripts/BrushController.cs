using UnityEngine;

namespace PaintIn3D
{
    public class BrushController : MonoBehaviour
    {
        public static BrushController instance;

        public Joystick redJoystick;
        public Joystick greenJoystick;
        public GameObject redBrushCircle;
        public GameObject redCharacter;
        public GameObject greenBrushCircle;
        public GameObject greenCharacter;
        public float redBrushSpeed = 0.02f;
        public float redBrushRotationSpeed = 100f;
        public float greenBrushSpeed = 0.02f;
        public float greenBrushRotationSpeed = 100f;
        public float brushX = 1.34f;
        public float brushZ = 0.642f;

        private void Start()
        {
            redBrushCircle.GetComponent<MeshRenderer>().material.color = Color.red;
            greenBrushCircle.GetComponent<MeshRenderer>().material.color = Color.green;
        }

        private void Update()
        {
            float redHorizontal = redJoystick.Horizontal;
            float redVertical = redJoystick.Vertical;
            float greenHorizontal = greenJoystick.Horizontal;
            float greenVertical = greenJoystick.Vertical;
            redBrushCircle.transform.Translate(redHorizontal * redBrushSpeed, 0, redVertical * redBrushSpeed);
            redBrushCircle.transform.position = new(Mathf.Clamp(
                redBrushCircle.transform.position.x, -brushX, brushX),
                redBrushCircle.transform.position.y, Mathf.Clamp(
                redBrushCircle.transform.position.z, -brushZ, brushZ));
            greenBrushCircle.transform.Translate(greenHorizontal * greenBrushSpeed, 0, greenVertical * greenBrushSpeed);
            greenBrushCircle.transform.position = new(Mathf.Clamp(
                greenBrushCircle.transform.position.x, -brushX, brushX),
                greenBrushCircle.transform.position.y, Mathf.Clamp(
                greenBrushCircle.transform.position.z, -brushZ, brushZ));

            // Get the direction from the joystick
            Vector3 redDirection = new Vector3(redJoystick.Horizontal, 0, redJoystick.Vertical);

            // If the direction is not zero, rotate the game object
            if (redDirection.magnitude > 0)
            {
                // Create a rotation based on the direction
                Quaternion targetRotation = Quaternion.LookRotation(redDirection, Vector3.up);

                // Rotate the game object smoothly towards the target rotation
                redCharacter.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, redBrushRotationSpeed * Time.deltaTime);
            }

            // Get the direction from the joystick
            Vector3 greenDirection = new Vector3(greenJoystick.Horizontal, 0, greenJoystick.Vertical);

            // If the direction is not zero, rotate the game object
            if (greenDirection.magnitude > 0)
            {
                // Create a rotation based on the direction
                Quaternion targetRotation = Quaternion.LookRotation(greenDirection, Vector3.up);

                // Rotate the game object smoothly towards the target rotation
                greenCharacter.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, greenBrushRotationSpeed * Time.deltaTime);
            }
        }
    }
}
