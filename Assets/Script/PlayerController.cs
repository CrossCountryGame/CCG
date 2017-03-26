using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {


	#region [VARIABLES]
	[Header("Physics ambient")]
	public float gravity = 20.0F;
	public float defaultRunSpeed = 7.0f;
	public float speedUpRate = 5.0f;
	private Vector3 startpoint;
	public float movementForce;
	public float movementForceDevice;
	float MetersFromStart;
	[Header("GUI")]
	//public Text elapseTimeGUIText;
	//public Text distanceGUIText;
	public Text pointGUIText;
	public Text ScoreGUIText;
	[Header("Data")]
	int ScoreCoins;
	int Score;
	[Header("Character")]
	public CameraController cam;
	private float runSpeed;
	private	int runDirection;
	private Rigidbody rgbody;
	public string currentDirection = "Front";
	private Vector3 moveDirection = Vector3.zero;
	private bool canCurve;
	private Animator anim;
	//Jump
	//public float heightToJump = 8.0f;
	private bool isFalling = false;
	public float jumpforce;
	public static PlayerController player;
	public CharacterController controller;

	[Header("Items Objects")]
	public Transform roadManagaer;//Object with the tag Magnet

	[Header("Magnet")]
	public GameObject MagnerAbility;//Object with the tag Magnet
	public int MagnetDuringTime = 3; // in seconds
	[Header ("Speed Up")]
	public int SpeedBoost = 3;
	public int SpeedUpDuringTime = 3; // in seconds
	bool SpeedBoostActive= false;
	[Header ("Coins multiplier")]
	public int MultiplierNumber = 2;
	public int CoinsMultiplierDuration = 3; // in seconds

	//-------------------------------
	[Header("Debug Data")]
	public float initHeight;
	public float currentHeight;
	float lastYPosition;
	private Vector2 touchStartPos;
	private float lastRotateTime;
	private bool  arrowKeyPressed;
	public GameObject LoadingScreen;
	public PlayerCustomizer Customizer;
	bool canmove= true;
	bool isSlide = false;
	bool isdead= false;
	#endregion
	/// <summary>
	// Variables of  the class.
	/// </summary>
	//---------------
	public string CurrentDirection{
		get{ 
			return currentDirection;
		}
	}
	#region [StartFunction]
	void Start(){
		if(Manager.mng.isPaused){
			Manager.mng.Pause ();
		}
	
		canmove = true;
		//gameObject.transform.position = roadManagaer.position + new Vector3 (0,0.097f,0);
		Customizer.ApplyColors (this);
		controller = gameObject.GetComponent<CharacterController>();
		initHeight = gameObject.transform.position.y;
		anim = gameObject.GetComponent<Animator> ();
		player = this;
		startpoint = this.transform.position;
		this.runSpeed = this.defaultRunSpeed;
		rgbody = this.GetComponent<Rigidbody> ();
	}
	#endregion
	/// <summary>
	// Calling starting methods.
	/// </summary>
	//-------------
	#region [UpdateFunction]
	void Update(){
		if(controller == null){
			Debug.Log("sap");
			gameObject.GetComponent<CharacterController>();
		}
			//---------------------------Screen
		if (canmove) {
			this.processKeyInput ();
			this.processTouchInput ();
			//----------------------------Movement
			this.move ();
			this.updateElapsedTimeLabel ();
			this.speedUp ();
			this.calcDistance ();
		
		}


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
	#endregion
	/// <summary>
	// Call more functions frame by frame.
	/// </summary>
	//------------
	#region [Items]
	public void activeMagnet(){
		StartCoroutine ("MagnetWorking");
	}
	IEnumerator MagnetWorking(){
		MagnerAbility.SetActive (true);
		yield return new WaitForSeconds (MagnetDuringTime);
		MagnerAbility.SetActive (false);
	}
	//------------------------------------
	public void activeSpeedUp(){
		StartCoroutine ("SpeedUpWorking");
	}
	IEnumerator SpeedUpWorking(){
		SpeedBoostActive = true;

		yield return new WaitForSeconds (SpeedUpDuringTime);

		SpeedBoostActive = false;
	}
	//----------------------------------
	public void activeCoinsMultiplier(){
		StartCoroutine ("CoinsMultiplierWorking");
	}
	IEnumerator CoinsMultiplierWorking(){
		Coin[] objects = GameObject.FindObjectsOfType<Coin>();
		foreach(Coin coins in objects){
			coins.CoinValue *= MultiplierNumber;
		}
		yield return new WaitForSeconds (SpeedUpDuringTime);

		SpeedBoostActive = false;
	}
	#endregion

	#region [Plus Point Function]
	public void plusPoints(int coin){
		ScoreCoins += coin;
		pointGUIText.text = ScoreCoins.ToString ();
	}
	#endregion
	/// <summary>
	// increase the coins.
	/// </summary>
	#region [Distance Calculation Function]
	private void calcDistance(){
		float distance;
		distance = Vector3.Distance (startpoint, this.transform.position);
		float distanceMeters = (distance * (2.54f / 96)) * 10;
		MetersFromStart = distanceMeters;
		//distanceGUIText.text = "Distance:" + distance.ToString ();
	}
	#endregion
	// touch

	// Touching Android Screen process.
	private void processTouchInput()
	{
		#region [Android Rotation]
		if (Input.touchCount > 0) {

		Touch touch = Input.touches [0];
		TouchPhase phase = touch.phase;
		if (phase == TouchPhase.Began) {
			touchStartPos = touch.position;
		} else if (phase == TouchPhase.Ended || phase == TouchPhase.Canceled) {
				if(isFalling == false){
					if (touch.position.x < (touchStartPos.x - 75) && canCurve) {
						runDirection -= 90;
					} else if (touch.position.x > (touchStartPos.x + 75) && canCurve){
						runDirection += 90;

					}
				}

				if (touch.position.y > (touchStartPos.y + 130) && isFalling == false) {
						Jump ();
						isFalling = true;
						arrowKeyPressed = true;

				} else if (touch.position.y < (touchStartPos.y - 130) && isFalling == false) {
					StartCoroutine ("DownMovement");

					arrowKeyPressed = true;
				}
		}
		}
		#endregion
		#region [Androoid moving Device]
		if (Input.acceleration.x < -0.3f) {
			
			switch(currentDirection){
			case "Front":
				Vector3 moveFront = new Vector3 (-movementForce * 2, 0, 0);
				//controller.SimpleMove (moveFront);
				controller.Move(moveFront);
				//rgbody.AddForce (-movementForce * 10000, 0, 0);
				break;
			case "Left":
				Vector3 moveLeft = new Vector3 (0, 0, movementForce * 2);
				controller.Move (moveLeft);
				//rgbody.AddForce (0, 0, movementForce * 100);
				break;
			case "Back":
				Vector3 moveBack = new Vector3 (movementForce * 2, 0, 0);
				controller.Move (moveBack);
				//rgbody.AddForce (movementForce * 100, 0, 0);
				break;
			case "Right":
				Vector3 moveRight = new Vector3 (0, 0, -movementForce * 2);
				controller.Move (moveRight);
				//rgbody.AddForce (0, 0, -movementForce * 100);
				break;
			}
		} else if(Input.acceleration.x > 0.3){
			
			switch(currentDirection){
			case "Front":
				Vector3 moveFront = new Vector3 (movementForce * 2, 0, 0);
				controller.Move (moveFront);
				//rgbody.AddForce (movementForce * 100, 0, 0);
				break;
			case "Left":
				Vector3 moveLeft = new Vector3 (0, 0, -movementForce * 2);
				controller.Move (moveLeft);
				//rgbody.AddForce (0, 0, -movementForce * 100);
				break;
			case "Back":
				Vector3 moveBack = new Vector3 (-movementForce * 2, 0, 0);
				controller.Move (moveBack);
				//rgbody.AddForce (-movementForce * 100, 0, 0);
				break;
			case "Right":
				Vector3 moveRight = new Vector3 (0, 0, movementForce * 2);
				controller.Move (moveRight);
				//rgbody.AddForce (0, 0, movementForce * 100);
				break;
			}

		}
		#endregion
	}

	//keyborad function for debug.
	#region [Key Inputs]
	private void processKeyInput()
	{
		if (!arrowKeyPressed && Time.time - lastRotateTime > 0.1f) {
			if (Input.GetKey(KeyCode.LeftArrow) && canCurve) {
				switch(currentDirection){
				case "Front":
					currentDirection = "Right";
					cam.Direction = "Right";
					break;
				case "Left":
					currentDirection = "Front";
					cam.Direction = "Front";
					break;
				case "Right":
					currentDirection = "Back";
					cam.Direction = "Back";
					break;
				case "Back":
					currentDirection = "Left";
					cam.Direction = "Left";
					break;
				}
					runDirection -= 90;  
					lastRotateTime = Time.time;
					arrowKeyPressed = true;
					Debug.Log (runDirection);
					canCurve = false;


			} else if (Input.GetKey(KeyCode.RightArrow)&& canCurve) {
				switch(currentDirection){
				case "Front":
					currentDirection = "Left";
					cam.Direction = "Left";
					break;
				case "Left":
					currentDirection = "Back";
					cam.Direction = "Back";
					break;
				case "Right":
					currentDirection = "Front";
					cam.Direction = "Front";
					break;
				case "Back":
					currentDirection = "Right";
					cam.Direction = "Right";
					break;
				}
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
				StartCoroutine ("DownMovement");
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
	#endregion

	// move funcition.
	private void move()
	{
		Vector3 forward;
		if (SpeedBoostActive) {
			forward = transform.TransformDirection(0,0,runSpeed * SpeedBoost);

		} else {
			forward = transform.TransformDirection(0,0,runSpeed);

		}
		 forward = transform.TransformDirection(0,0,runSpeed);
		LoadingScreen.SetActive (false);
		controller.SimpleMove (forward);
		//Debug.Log ("Running");
		if(!Manager.mng.isPaused){

			Score += 1;
		}
		InfoCCG.infoccg.Puntuation = Score;
		//ScoreGUIText.text = Score.ToString ();
		this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, runDirection, 0), 0.25f);
	}

	//Increase speed mean the game is playing. little by little.
	private void speedUp()
	{
		//speed up 0.1 per 10sec.
		this.runSpeed = defaultRunSpeed + Time.time / 10.0f * this.speedUpRate;
	}

	// players juping function.
	void Jump(){
		if(!isSlide){
			lastYPosition = initHeight;
			moveDirection.y = jumpforce;
			anim.SetBool ("landing",false);
			anim.SetBool ("Jump",true);
			anim.SetBool ("OnGround",false);
		}


	}
	IEnumerator DownMovement(){
		//Todo esta aqui solo cambia por las variables del momento ;)
		anim.SetBool ("Slide",true);
		isSlide = true;
		yield return new WaitForSeconds (0.5f);
		anim.SetBool ("Slide",false);
		isSlide = false;
	
	}
	private void updateElapsedTimeLabel()
	{
		float now = Time.time;
		int sec = (int)now;
		float mil = (now - (float)sec) * 100.0f;
		//this.elapseTimeGUIText.text = "Time: " + sec.ToString() + mil.ToString(":00");
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

		if(collision.gameObject.tag == "Obstacle"){
			Death ();
		}
	}
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Obstacle"){
			Death ();
		}
	}


	void OnTriggerExit(Collider other){
		if(other.tag == "Curve"){
			canCurve = false;
		}
	}
	void OnTriggerEnter(Collider other) {

	
		if(other.tag == "Curve"){
			canCurve = true;
		}
		switch (other.tag) {
		case "LeftDirection":
			currentDirection = "Left";
			cam.Direction = "Left";
			break;
		case "FrontDirection":
			currentDirection = "Front";
			cam.Direction = "Front";

			break;
		case "BackDirection":
			currentDirection = "Back";
			cam.Direction = "Back";

			break;
		case "RightDirection":
			currentDirection = "Right";
			cam.Direction = "Right";

			break;
		case "MagnetItem":
			activeMagnet ();
			Destroy (other.gameObject);
			break;
		case "SpeedItem":
			activeSpeedUp ();
			Destroy (other.gameObject);
			break;
		case "CoinsItem":
			activeCoinsMultiplier ();
			Destroy (other.gameObject);
			break;
		case "Obstacle":
			
			Death ();
			break;
		case "ObstacleSlide":
			if(!isSlide){
				Death ();
			}
			break;
		}
	}
	public void Death(){
		if(!isdead){
			canmove = false;
			anim.SetBool ("Dead",true);
			InfoCCG.infoccg.CompareData (Score,(int)MetersFromStart,ScoreCoins);
			Manager.mng.Gameover ();
		}

	}
	void stopDeathBool(){
		isdead = true;
		anim.SetBool ("OnGround",false);
		anim.SetBool ("falling",false);
		anim.SetBool ("Jump",false);
		Debug.Log (isdead + "ASOASJOJDOSJ");
	}

}