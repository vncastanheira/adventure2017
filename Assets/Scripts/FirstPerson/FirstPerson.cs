using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPerson : MonoBehaviour
{
    public static FirstPerson singleton;

    #region References
    CharacterController p_character;
    Camera p_Camera;
    #endregion

    #region Settings
    public float Speed;
    #endregion

    #region Unity Methods
    void Start()
    {
        p_character = GetComponent<CharacterController>();
        p_Camera = Camera.main;
        singleton = this;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        CursorLock();

        Look(mouseX, mouseY);

        var walk = Input.GetAxis("Vertical") * p_character.transform.TransformDirection(Vector3.forward);
        var strafe = Input.GetAxis("Horizontal") * p_character.transform.TransformDirection(Vector3.right);

        p_character.SimpleMove((walk + strafe) * Speed);

    }
    #endregion

    #region Private Methods
    void Look(float mouseX, float mouseY)
    {
        p_character.transform.rotation *= Quaternion.Euler(0f, mouseX, 0f);
        p_Camera.transform.localRotation *= Quaternion.Euler(-mouseY, 0f, 0f);
        p_Camera.transform.localRotation = ClampRotation(p_Camera.transform.localRotation, -90f, 90f);
    }

    void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    Quaternion ClampRotation(Quaternion q, float minAngle, float maxAngle)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, minAngle, maxAngle);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }
    #endregion

}