using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{
	public AudioClip jump;
	public AudioClip move;
	public AudioClip attack;
	//���������� ��� ��������� ����. �������� ���������
	public float maxSpeed = 10f; 
	//���������� ��� ����������� ����������� ��������� ������/�����
	private bool isFacingRight = true;
	//������ �� ��������� ��������
	private Animator anim;
	//��������� �� �������� �� ����� ��� � ������?
	private bool isGrounded = false;
	//������ �� ��������� Transform �������
	//��� ����������� ��������������� � ������
	public Transform groundCheck;
	//������ ����������� ��������������� � ������
	private float groundRadius = 0.2f;
	//������ �� ����, �������������� �����
	public LayerMask whatIsGround;
	public static int Health = 100;
	bool nearEnemy=false;
	bool nearBoss=false;
	public static int selectedDifficult;
	
	/// <summary>
	/// ��������� �������������
	/// </summary>

	//int selectedDifficult=Difficulty.difficult;
	private void Start()
	{	
		if(Customize.skin==1){
			GameObject char2= GameObject.Find("character2");
			GameObject char3= GameObject.Find("character3");
			Destroy(char2);
			Destroy(char3);
		}
		if(Customize.skin==2){
			GameObject char1= GameObject.Find("character");
			GameObject char3= GameObject.Find("character3");
			Destroy(char1);
			Destroy(char3);
		}
		if(Customize.skin==3){
			GameObject char2= GameObject.Find("character2");
			GameObject char1= GameObject.Find("character");
			Destroy(char2);
			Destroy(char1);
		}
		if (selectedDifficult == 0)
						selectedDifficult = 1;
		print (selectedDifficult);
		jump = (AudioClip)Resources.Load ("jump");
		move = (AudioClip)Resources.Load ("steps");
		anim = GetComponent<Animator>();
		attack = (AudioClip)Resources.Load ("sword");
		Time.timeScale = 1;
		Health = 100;
	}

	/// <summary>
	/// ��������� �������� � ������ FixedUpdate, �. �. � ���������� Animator ���������
	/// ���������� �������� Animate Physics = true � �������� ���������������� � ��������� ������
	/// </summary>
	/// 
	 void OnTriggerEnter2D(Collider2D enemy){
	if (enemy.tag == "Enemy") {
		Debug.Log ("NearEnemy");
		nearEnemy=true;
	}
		if (enemy.tag == "Boss") {
			Debug.Log("NearBoss");
			nearBoss=true;		
		}
}
void OntriggerExit2D(Collider2D enemy){
	if (enemy.tag == "Enemy") {
		nearEnemy=false;		
	}
		if (enemy.tag == "Boss") {
			nearBoss=false;		
		}
}
	private void FixedUpdate(){

			
				//����������, �� ����� �� ��������
				isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround); 
				//������������� ��������������� ���������� � ���������
				anim.SetBool ("Ground", isGrounded);
				//������������� � ��������� �������� �������� ������/�������
				anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
				//���� �������� � ������ - ����� �� ������, ����� �� ����������� ��������, ��������� � �����

				/*if (!isGrounded)
						return;*/

				//if (!isGrounded)
						//return;

				//���������� Input.GetAxis ��� ��� �. ����� ���������� �������� ��� � �������� �� -1 �� 1.
				//��� ����������� ���������� ������� 
				//-1 ������������ ��� ������� �� ���������� ������� ����� (��� ������� �),
				//1 ������������ ��� ������� �� ���������� ������� ������ (��� ������� D)
				float move = Input.GetAxis ("Horizontal");
		
				//� ���������� �������� �������� �������� ��������� Speed �� �������� ��� �.
				//������� ��� ����� ������ ��������
				anim.SetFloat ("Speed", Mathf.Abs (move));
		
				//���������� � ���������� ��������� RigidBody2D. ������ ��� �������� �� ��� �, 
				//������ �������� ��� � ���������� �� �������� ����. ��������
				rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		
				//���� ������ ������� ��� ����������� ������, � �������� ��������� �����
			
				if (move > 0 && !isFacingRight) {
								//�������� ��������� ������
								Flip ();
						}
				
				//�������� ��������. �������� ��������� �����
				else if (move < 0 && isFacingRight) {
								Flip ();
						}
		}

	private void Update()
	{
		if (nearEnemy) {
			if(Input.GetKeyDown(KeyCode.F)){
				if(selectedDifficult==1){
					Health=Health-50;
				}
				else if(selectedDifficult==2){
					Health=Health-35;
				}
				else if(selectedDifficult==3){
					Health=Health-20;
				}
			}
		}
		if(nearBoss){
			if(Input.GetKeyDown(KeyCode.F)){
				if(selectedDifficult==1){
					Health=Health-20;
				}
				else if(selectedDifficult==2){
					Health=Health-10;
				}
				else if(selectedDifficult==3){
					Health=Health-5;
				}
			}
		}
		if (rigidbody2D.velocity.magnitude >= 0.2) {
			
			if (isGrounded) {
				if (!audio.isPlaying) {
					audio.clip = move;
					audio.Play ();
				}
			}
		}
		//���� �������� �� ����� � ����� ������...
		if (isGrounded && Input.GetKeyDown (KeyCode.Space)) 
		{
			//������������� � ��������� ���������� � false
			anim.SetBool("Ground", false);
			//������������ ���� �����, ����� �������� ����������
			rigidbody2D.AddForce(new Vector2(0, 600));
			audio.Pause ();
			audio.PlayOneShot (jump);
			audio.volume = 2F;
			audio.Play ();
		}
		if (Input.GetKeyDown (KeyCode.F)&&Customize.skin==1) {
						anim.Play ("Attack(sword)");
						audio.PlayOneShot (attack);
						audio.volume = 1F;
				} 
		 else if (Input.GetKeyUp (KeyCode.F)&&Customize.skin==1) {
					anim.Play("Idle");
				}
		if (Input.GetKeyDown (KeyCode.F)&&Customize.skin==2) {
			anim.Play ("attack2");
			audio.PlayOneShot (attack);
			audio.volume = 1F;
		} 
		else if (Input.GetKeyUp (KeyCode.F)&&Customize.skin==2) {
			anim.Play("Idle");
		}
		if (Input.GetKeyDown (KeyCode.F)&&Customize.skin==3) {
			anim.Play ("attack3");
			audio.PlayOneShot (attack);
			audio.volume = 1F;
		} 
		else if (Input.GetKeyUp (KeyCode.F)&&Customize.skin==3) {
			anim.Play("Idle3");
		}
	}
	
	/// <summary>
	/// ����� ��� ����� ����������� �������� ��������� � ��� ����������� ���������
	/// </summary>
	private void Flip()
	{
		//������ ����������� �������� ���������
		isFacingRight = !isFacingRight;
		//�������� ������� ���������
		Vector3 theScale = transform.localScale;
		//��������� �������� ��������� �� ��� �
		theScale.x *= -1;
		//������ ����� ������ ���������, ������ �������, �� ��������� ����������
		transform.localScale = theScale;
	}
}