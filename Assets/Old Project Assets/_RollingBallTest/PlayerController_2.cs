using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController_2 : MonoBehaviour 
{
	/// <summary>
	/// The Player's speed. This value will be modified from Unity's Inspector panel.
	/// </summary>
	public float speed;
	/// <summary>
	/// Reference to the GUIText component that will display the player's score.
	/// </summary>
	//public Text countText;

	/// <summary>
	/// Reference to the GUIText component that will display when the player has
	/// collected all the pickups.
	/// </summary>
	//public Text winText;

	/// <summary>
	/// The number of Pickup objects that Player has collected.
	/// </summary>
	private int pickupCount = 0;

	void Start()
	{
		//SetPickupCountAndUpdateGUIText(0);

		// The win text should not be visible until the Player has won.
		//winText.text = "";
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		// Y-Axis is 0 because the Player cannot move up.
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
	}	

	void OnTriggerEnter(Collider other) 
	{
		// Note: We can use == to compare string values in C# because of the 
		// overloaded operator.

		// Deactivate the Pickup object when Player collects it.
		if (other.gameObject.tag == "Pickup") 
		{
			other.gameObject.SetActive(false);
			//SetPickupCountAndUpdateGUIText(pickupCount + 1);
		}
	}

	/// <summary>
	/// Sets the pickup count property and updates the GUIText component also.
	/// </summary>
	/// <param name="count">The updated pickup count.</param>
	void SetPickupCountAndUpdateGUIText(int count)
	{
		pickupCount = count;
		//countText.text = string.Format("Count: {0}", pickupCount);

		if (pickupCount >= 12) 
		{
			//winText.text = "Yay! You've won. :-)";
		}
	}
}