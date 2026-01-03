using UnityEngine;
using TMPro;

public class PlayerTest : MonoBehaviour
{
    [SerializeField]
    public float speed;
    private Rigidbody rb;
    private int count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }
 
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);  //Deactivate making it disappears
            count = count+1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count:"+count.ToString();
        if(count == 4)
        {
            winTextObject.SetActive(true);
        }
    }
}
