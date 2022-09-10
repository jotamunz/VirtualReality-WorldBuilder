using UnityEngine;
using System.Collections;

public class TrolControl : MonoBehaviour {
	
	private Animator anim;
	private CharacterController controller;
	private bool battle_state;
	public float speed = 6.0f;
	public float runSpeed = 1.7f;
	public float turnSpeed = 60.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;


	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
	

		anim.SetInteger ("moving", 1);//run
		runSpeed = 0.7f;
		moveDirection=transform.forward *runSpeed	;
		float turn = 0.0001f;
		transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
		controller.Move(moveDirection * Time.deltaTime);
		moveDirection.y -= gravity * Time.deltaTime;
	}
}
