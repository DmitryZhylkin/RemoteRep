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
		if(Input.GetKeyDown(KeyCode.LeftArrow)) {
			audio.PlayOneShot(move);
			audio.volume = 1F;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			audio.PlayOneShot(move);
			audio.volume = 1F;
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
		if (Input.GetKeyDown (KeyCode.F)) {
						anim.Play ("Attack(sword)");
						audio.PlayOneShot (attack);
						audio.volume = 1F;
				} else if (Input.GetKeyUp (KeyCode.F)) {
					anim.Play("Idle");
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