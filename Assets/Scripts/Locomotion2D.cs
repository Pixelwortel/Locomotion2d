using UnityEngine;

public class Locomotion2D : MonoBehaviour/* ADDED */, ILocomotion {
	[SerializeField] bool ShowDebugLog = false;

	// Dependencies
	public ILocomotion _locomotion;

	/* ADDED */
	public float Horizontal { get; set; }
	/* ADDED */
	public float Vertical { get; set; }

	// Start is called before the first frame update
	void Start() {
		_locomotion = transform.GetComponent<ILocomotion>();

		if (_locomotion == null) {
			Debug.LogError("ILocomotion not found on " + gameObject.name);
		}
	}

	// Update is called once per frame
	void Update() {
		if (_locomotion != null) {
			_locomotion.Horizontal = Input.GetAxisRaw("Horizontal");
			_locomotion.Vertical = Input.GetAxisRaw("Vertical");
		}
	}
	/* ADDED */
	void FixedUpdate() {
		Vector2 moveVector = new Vector2(_locomotion.Horizontal, _locomotion.Vertical).normalized;
		gameObject.transform.Translate(moveVector * Time.fixedDeltaTime);
	}

}
