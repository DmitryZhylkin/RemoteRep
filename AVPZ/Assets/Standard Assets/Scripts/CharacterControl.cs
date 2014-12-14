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
	
	/// <summary>
	/// ��������� �������������
	/// </summary>

	private void Start()
	{
		jump = (AudioClip)Resources.Load ("jump");
		move = (AudioClip)Resources.Load ("steps");
		anim = GetComponent<Animator>();
		attack = (AudioClip)Resources.Load ("sword");
		Time.timeScale = 1;
	}

	/// <summary>
	/// ��������� �������� � ������ FixedUpdate, �. �. � ���������� Animator ���������
	/// ���������� �������� Animate Physics = true � �������� ���������������� � ��������� ������
	/// </summary>
	private void FixedUpdate()
	{
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
		if (Input.GetButtonDown("Attack")) {
			anim.Play("Attack(sword)");
			audio.PlayOneShot(attack);
			audio.volume = 1F;
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