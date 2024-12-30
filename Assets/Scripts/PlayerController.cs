using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
    float speed;
	[SerializeField]
    Text countText;
	[SerializeField]
    Text winText;
    string target;
    public GameObject cubeA=null;
    public GameObject cubeB=null;

    private Rigidbody rb;
    private int count;
    private int redcount=0;
    private int bluecount = 0;
    private int yellowcount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {

        if (cubeA == null)
        {

            cubeA = GameObject.Find(other.name);

        }
        else if(cubeA != null)
        {

            if(other.tag == cubeA.tag && other.name != cubeA.name)
            {

                cubeB = GameObject.Find(other.name);
                Destroy(cubeA);
                Destroy(cubeB);

            }
            else if(other.tag != cubeA.tag)
            {

                cubeA = GameObject.Find(other.name);

            }

        }

        //if (other.gameObject.CompareTag("Red") || other.gameObject.CompareTag("Blue"))
        //{
        //    other.gameObject.SetActive(false);
        //    count = count + 1;
        //    SetCountText();
        //}

        //if (other.gameObject.CompareTag("Red"))
        //{
            
        //    //target = "Red";
        //    //redcount++;
        //    //bluecount = 0;
        //    //yellowcount = 0;
        //    if (cubeA == null || other.tag == "Blue" || other.tag == "Yellow")
        //    {

        //        cubeA = GameObject.Find(other.name);
            
        //    }
        //    else if(cubeA != null && other.tag != "Blue" && other.tag != "Yellow")
        //    {

        //        cubeB = GameObject.Find(other.name);

        //    }
        //    //SetCountText();
        
        //}
        //else if (other.gameObject.CompareTag("Blue"))
        //{

        //    if (cubeA == null || other.tag == "Red" || other.tag == "Yellow")
        //    {

        //        cubeA = GameObject.Find(other.name);

        //    }
        //    else if (cubeA != null && other.tag != "Red" && other.tag != "Yellow")
        //    {

        //        cubeB = GameObject.Find(other.name);

        //    }

        //    //target = "Blue";
        //    //bluecount++;
        //    //redcount = 0;
        //    //yellowcount = 0;
        //    //SetCountText();

        //}
        //else if (other.gameObject.CompareTag("Yellow"))
        //{

        //    if (cubeA == null || other.tag == "Blue" || other.tag == "Red")
        //    {

        //        cubeA = GameObject.Find(other.name);

        //    }
        //    else if (cubeA != null && other.tag != "Blue" && other.tag != "Red")
        //    {

        //        cubeB = GameObject.Find(other.name);

        //    }

        //    //target = "Yellow";
        //    //yellowcount++;
        //    //redcount = 0;
        //    //bluecount = 0;
        //    //SetCountText();

        //}

    }

    void SetCountText()
    {
        if (target == "Red")
        {
            countText.text = "Red Count: " + redcount.ToString();
        }
        else if (target == "Blue")
        {
            countText.text = "Blue Count: " + bluecount.ToString();
        }
        else if (target == "Yellow")
        {
            countText.text = "Yellow Count: " + yellowcount.ToString();
        }
    }
}