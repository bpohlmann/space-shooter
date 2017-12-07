using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;
    


    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float bonusRate;
    public GUIText bonusText;
	public float speedAdd;
    
    


    


    private float nextFire;
   

    private void Start()
    {
        bonusText.text = "";
       
        

    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();



        }
		// musik für bonus ggf play on awake
		//speed bei enemys asteroids ggf dem backround anpassen
		// Hier soll bei einem Score von 1000 und einer tastenbetätigung ein Doppelschuss implementiert werden
		//dazu taste bzw text anzeigen ( bei score = 1000) und bei tastendruck anderen shot spawn wählen(hierzu in if Input.GetButton ..... eine if Auswahl Anweisund implemenieren die den shotSpawn auswählt bei dem 
		//Parameter bool doubleShot (true) bzw doubleShot(false)
		//if (DestroyByContact.score < 1000) 
		//{
			
		//	gameController.AddScore (-DestroyByContact.score);
		//}

		speed = speed + speedAdd;
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
                Mathf.Clamp(GetComponent<Rigidbody>().position.x,
                    boundary.xMin, boundary.xMax),
           0.0f,
                Mathf.Clamp(GetComponent<Rigidbody>().position.z,
                        boundary.zMin, boundary.zMax)
        );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
        
    }

    void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Bonus"))
        {
            fireRate = fireRate - bonusRate;
            bonusText.text = "Firerate increase";
            Destroy(other.gameObject);
        }

        if (other.CompareTag("non bonus"))
        {
            fireRate = fireRate + bonusRate;
            bonusText.text = "Firerate decrease";
            
            Destroy(other.gameObject);
            
            

            
        }

        

       
    }
}
