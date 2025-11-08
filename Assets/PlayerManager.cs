using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance;
    [SerializeField] private int playerHealth;
    private Rigidbody playerRB;
    private float accelFactor = 10f;

    public static PlayerManager Instance {  get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this) { Destroy(this.gameObject); }
        else {  _instance = this; }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRB.transform.Translate(accelFactor * Time.deltaTime * transform.forward * Input.GetAxis("Vertical"));
        playerRB.transform.Translate(accelFactor * Time.deltaTime * transform.right * Input.GetAxis("Horizontal"));
        if (Input.GetButtonDown("Jump")) 
        {
            playerRB.AddForce(Vector3.up / Time.deltaTime); 
        }
    }
}
