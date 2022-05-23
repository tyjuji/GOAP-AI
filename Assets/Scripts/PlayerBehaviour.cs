using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public GameObject playerBullet;
    public int walkSpeed = 10;

    CharacterController charCtrl;
    LifeHandler lifeHandler;


    // Start is called before the first frame update
    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
        charCtrl.enableOverlapRecovery = false;
        charCtrl.detectCollisions = false;
        lifeHandler = GetComponent<LifeHandler>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CharacterMovement();
    }

    private void Update()
    {
        LookRotation();
        Shooting();
        Shield();
    }

    private void Shield()
    {
        if (Input.GetButton("Shield") && lifeHandler.ShieldAvailable)
        {
            lifeHandler.ShieldOn();
        }
    }



    private void Shooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (lifeHandler.Ammo > 0)
            {
                Instantiate(playerBullet, gameObject.transform.position, gameObject.transform.rotation);
                lifeHandler.UseAmmo();
            }
            else
            {
                Debug.Log("No ammo left)");
            }
        }
    }

    private void LookRotation()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y);
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        //lookPos = lookPos - transform.position;
        //float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        transform.LookAt(lookPos);
        var oldangles = transform.eulerAngles;
        oldangles.x = 0;
        oldangles.z = 0;
        transform.eulerAngles = oldangles;
    }

    private void CharacterMovement()
    {
        // Get Horizontal and Vertical Input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the Direction to Move based on the tranform of the Player
        //Vector3 moveDirectionForward = transform.forward * verticalInput;
        //Vector3 moveDirectionSide = transform.right * horizontalInput;
        Vector3 moveDirectionForward = Vector3.forward * verticalInput;
        Vector3 moveDirectionSide = Vector3.right * horizontalInput;

        //find the direction
        Vector3 direction = (moveDirectionForward + moveDirectionSide).normalized;
        //find the distance
        Vector3 distance = direction * walkSpeed * Time.deltaTime;

        // Apply Movement to Player

        charCtrl.Move(distance);

    }

    float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
