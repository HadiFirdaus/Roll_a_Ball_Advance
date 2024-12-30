using UnityEngine;

public class Rotator : MonoBehaviour
{
	[SerializeField]
	Vector3 rotation;
    Material[] mat;
    Renderer rend;
	float rotationSpeed=10f;
    int random;

    void Start()
    {
		RandomizeColor ();

    }
		
    void FixedUpdate()
    {
		BoxRotator(rotation);
    }

	void RandomizeColor(){
		rend = GetComponent<Renderer>();
		mat = rend.materials;
		random = Random.Range(0, 3);
		if (random == 0)
		{
			mat[0].color = Color.red;
			transform.gameObject.tag = "Red";
		}
		else if (random == 1)
		{
			mat[0].color = Color.blue;
			transform.gameObject.tag = "Blue";
		}
		else if (random == 2)
		{
			mat[0].color = Color.yellow;
			transform.gameObject.tag = "Yellow";
		}
	}

	void BoxRotator(Vector3 rotate){
		transform.Rotate (rotate *rotationSpeed*Time.deltaTime);
	}

}