using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {
	
	public float gravity = 20.0F;
	public float defaultRunSpeed = 7.0f;
	public float speedUpRate = 5.0f;
	public Text elapseTimeGUIText;
	public Text distanceGUIText;
	public Text pointGUIText;
	int Score;
	private float runSpeed;
	private	int runDirection;
	private Vector3 startpoint;
	private Rigidbody rgbody;
	public float movementForce;
	public float movementForceDevice;
	string currentDirection = "Front";
	private Vector3 moveDirection = Vector3.zero;

	private Animator anim;
	//Jump
	//public float heightToJump = 8.0f;
	private bool isFalling = false;
	public float jumpforce;
	public static PlayerController player;
	CharacterController controller;

	[Header("Debug Data")]
	public float initHeight;
	public float currentHeight;
	float lastYPosition;
	void Start()
	{
		controller = GetComponent<CharacterController>();
		initHeight = gameObject.transform.position.y;
		anim = this.GetComponent<Animator> ();
		player = this;
		startpoint = this.transform.position;
		this.runSpeed = this.defaultRunSpeed;
		rgbody = this.GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update()
	{
		//---------------------------Screen
		this.processKeyInput();
		this.processTouchInput();
		//----------------------------Movement
		this.move();
		this.updateElapsedTimeLabel();
		this.speedUp();
		this.calcDistance ();
		currentHeight = gameObject.transform.position.y;
		if(currentHeight > initHeight){
			if (currentHeight < lastYPosition) {
				anim.SetBool ("falling",true);
				//rgbody.velocity = new Vector3(0,-jumpforce + 5,0);
			} else {
				lastYPosition = currentHeight;
				anim.SetBool ("falling",false);
				anim.SetBool("OnGround",false);
				anim.SetBool ("landing",false);
				anim.SetBool ("Jump",true);

			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
	public void plusPoints(int coin){
		Score += coin;
		pointGUIText.text = Score.ToString ();
	}
	private void calcDistance(){
		float distance;
		distance = Vector3.Distance (startpoint, this.transform.position);
		float distanceMeters = (distance * (2.54f / 96)) * 10;
		distanceGUIText.text = "Distance:" + distance.ToString ();
	}
	// touch
	private Vector2 touchStartPos;

	private void processTouchInput()
	{
		if (Input.touchCount > 0) {

		Touch touch = Input.touches [0];
		TouchPhase phase = touch.phase;
		if (phase == TouchPhase.Began) {
			touchStartPos = touch.position;
		} else if (phase == TouchPhase.Ended || phase == TouchPhase.Canceled) {
				if(isFalling == false){
					if (touch.position.x < (touchStartPos.x - 75)) {
						runDirection -= 90;
					} else if (touch.position.x > (touchStartPos.x + 75)){
						runDirection += 90;

					}
				}

				if (touch.position.y > (touchStartPos.y + 85) && isFalling == false) {
						Jump ();
						isFalling = true;
						arrowKeyPressed = true;

				} else if (touch.position.y < (touchStartPos.y - 85) && isFalling == false) {
					StartCoroutine ("DownMovement");

					arrowKeyPressed = true;
				}
		}
		}
		/*case "Front":
		Vector3 moveFront = new Vector3 (-movementForce, 0, 0);
		controller.SimpleMove (moveFront);
		//rgbody.AddForce (-movementForce * 100, 0, 0);
		break;
		case "Left":
		Vector3 moveLeft = new Vector3 (0, 0, movementForce);
		controller.SimpleMove (moveLeft);
		//rgbody.AddForce (0, 0, movementForce * 100);
		break;
		case "Back":
		Vector3 moveBack = new Vector3 (movementForce, 0, 0);
		controller.SimpleMove (moveBack);
		//rgbody.AddForce (movementForce * 100, 0, 0);
		break;
		case "Right":
		Vector3 moveRight = new Vector3 (0, 0, -movementForce);
		controller.SimpleMove (moveRight);*/
		//rgbody.AddForce (0, 0, -movementForce * 100);
		if (Input.acceleration.x < 0) {
			switch(currentDirection){
			case "Front":
				Vector3 moveFrontDevice = new Vector3 (-movementForceDevice, 0, 0);
				controller.Move (moveFrontDevice);
				//rgbody.AddForce (Input.acceleration.x * 500, 0, 0);
				break;
			case "Left":
				Vector3 moveLeftDevice = new Vector3 (0, 0,movementForceDevice);
				controller.Move (moveLeftDevice);
				//rgbody.AddForce (0, 0, Input.acceleration.x * 500);
				break;
			case "Back":
				Vector3 moveBackDevice = new Vector3 (movementForceDevice, 0,0);
				controller.Move (moveBackDevice);
				//rgbody.AddForce (Input.acceleration.x * 500, 0, 0);
				break;
			case "Right":
				Vector3 moveRightDevice = new Vector3 (0, 0,-movementForceDevice);
				controller.Move (moveRightDevice);
				//rgbody.AddForce (0, 0, Input.acceleration.x * 500);
				break;
			}
		} else if(Input.acceleration.x > 0){
			switch(currentDirection){
			case "Front":
				Vector3 moveFrontDevice = new Vector3 (movementForceDevice, 0, 0);
				controller.Move (moveFrontDevice);
				//rgbody.AddForce (movementForceDevice, 0, 0);
				break;
			case "Left":
				Vector3 moveLeftDevice = new Vector3 (0, 0,-movementForceDevice);
				controller.Move (moveLeftDevice);
				break;
			case "Back":
				Vector3 moveBackDevice = new Vector3 (-movementForceDevice, 0,0);
				controller.Move (moveBackDevice);
				break;
			case "Right":
				Vector3 moveRightDevice = new Vector3 (0, 0,movementForceDevice);
				controller.Move (moveRightDevice);
				break;
			}

		}
	}

	//keyborad
	private float lastRotateTime;
	private bool  arrowKeyPressed;

	private void processKeyInput()
	{
		if (!arrowKeyPressed && Time.time - lastRotateTime > 0.1f) {
			if (Input.GetKey(KeyCode.LeftArrow)) {
				
					runDirection -= 90;  
					lastRotateTime = Time.time;
					arrowKeyPressed = true;
					Debug.Log (runDirection);


			} else if (Input.GetKey(KeyCode.RightArrow)) {
					
					runDirection += 90;
					lastRotateTime = Time.time;
					arrowKeyPressed = true;
					Debug.Log (runDirection);

			}
			if (Input.GetKey(KeyCode.UpArrow) && isFalling == false) { 
				Jump ();
				isFalling = true;
				arrowKeyPressed = true;

			} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
				//StartCoroutine ("DownMovement");
				//NO NOW  
				arrowKeyPressed = true;

			}
			if (Input.GetKey(KeyCode.A)) {
				
				switch(currentDirection){
				case "Front":
					Vector3 moveFront = new Vector3 (-movementForce, 0, 0);
					//controller.SimpleMove (moveFront);
					controller.Move(moveFront);
					//rgbody.AddForce (-movementForce * 10000, 0, 0);
					break;
				case "Left":
					Vector3 moveLeft = new Vector3 (0, 0, movementForce);
					controller.Move (moveLeft);
					//rgbody.AddForce (0, 0, movementForce * 100);
					break;
				case "Back":
					Vector3 moveBack = new Vector3 (movementForce, 0, 0);
					controller.Move (moveBack);
					//rgbody.AddForce (movementForce * 100, 0, 0);
					break;
				case "Right":
					Vector3 moveRight = new Vector3 (0, 0, -movementForce);
					controller.Move (moveRight);
					//rgbody.AddForce (0, 0, -movementForce * 100);
					break;
				}

			
			}
			if (Input.GetKey(KeyCode.D)) {
				switch(currentDirection){
				case "Front":
					Vector3 moveFront = new Vector3 (movementForce, 0, 0);
					controller.Move (moveFront);
					//rgbody.AddForce (movementForce * 100, 0, 0);
					break;
				case "Left":
					Vector3 moveLeft = new Vector3 (0, 0, -movementForce);
					controller.Move (moveLeft);
					//rgbody.AddForce (0, 0, -movementForce * 100);
					break;
				case "Back":
					Vector3 moveBack = new Vector3 (-movementForce, 0, 0);
					controller.Move (moveBack);
					//rgbody.AddForce (-movementForce * 100, 0, 0);
					break;
				case "Right":
					Vector3 moveRight = new Vector3 (0, 0, movementForce);
					controller.Move (moveRight);
					//rgbody.AddForce (0, 0, movementForce * 100);
					break;
				}

			}
		}

		if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow)) {
			arrowKeyPressed = false;
		}
	}

	private void move()
	{


		Vector3 forward = transform.TransformDirection(0,0,runSpeed);
		controller.SimpleMove (forward);

		this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, runDirection, 0), 0.25f);

		//Vector3 v = transform.forward * this.runSpeed;
		//v.y = this.GetComponent<Rigidbody>().velocity.y;
		//this.GetComponent<Rigidbody>().velocity = v;
	}

	private void speedUp()
	{
		//speed up 0.1 per 10sec.
		this.runSpeed = defaultRunSpeed + Time.time / 10.0f * this.speedUpRate;
	}

	void Jump(){
		lastYPosition = initHeight;
		moveDirection.y = jumpforce;
	
		//rgbody.velocity = new Vector3(0,jumpforce,0);
		//rgbody.AddForce (0,jumpforce * 120,0);
		anim.SetBool ("landing",false);
		anim.SetBool ("Jump",true);
		anim.SetBool ("OnGround",false);


	}
	IEnumerator DownMovement(){
		Debug.Log ("abajo");
		anim.SetBool ("Down",true);
		yield return new WaitForSeconds (1);
		anim.SetBool ("Down",false);
	}
	private void updateElapsedTimeLabel()
	{
		float now = Time.time;
		int sec = (int)now;
		float mil = (now - (float)sec) * 100.0f;
		this.elapseTimeGUIText.text = "Time: " + sec.ToString() + mil.ToString(":00");
			//string.Format("{0:00}:{1:00}", sec, mil);
	}
	void OnControllerColliderHit(ControllerColliderHit collision) {

		if(collision.gameObject.tag == "Ground"){
			isFalling = false;
			anim.SetBool ("Jump", false);
			anim.SetBool ("landing", false);
			anim.SetBool ("OnGround",true);
		}else{
			anim.SetBool ("OnGround",false);

		}
		/*switch(collision.gameObject.tag){
		case "Ground":
			isFalling = false;
			anim.SetBool ("Jump", false);
			anim.SetBool ("landing", false);
			anim.SetBool ("OnGround",true);
			break;
		case "Obstacle":
			Death ();
			break;
		 
		}*/



	}

	void OnTriggerEnter(Collider other) {
		switch (other.tag) {
		case "LeftDirection":
			currentDirection = "Left";
			break;
		case "FrontDirection":
			currentDirection = "Front";
			break;
		case "BackDirection":
			currentDirection = "Back";
			break;
		case "RightDirection":
			currentDirection = "Right";
			break;
		}
	}
	public void Death(){
		Debug.Log ("Dead");
		anim.SetBool ("Dead", true);
		Invoke ("Reset",1.5f);
	}
	//void OnCollisionEnter(Collision coll){
	//	if(){
			
	//	}
	//}
	void Reset (){
		GameManager.gmanager.ResetScene ();
	}
	//private void checkFail() {
	//	if (transform.position.y < -10) {
	//		transform.position = new Vector3(0, 5, 0);
	////		this.runSpeed = this.defaultRunSpeed;

		////	GroundControl con = obj.GetComponent("GroundControl") as GroundControl;
			//con.resetGame();
	//	}
	}

