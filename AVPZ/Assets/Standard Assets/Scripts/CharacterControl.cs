using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{
	public AudioClip jump;
	public AudioClip move;
	public AudioClip attack;
	//переменная для установки макс. скорости персонажа
	public float maxSpeed = 10f; 
	//переменная для определения направления персонажа вправо/влево
	private bool isFacingRight = true;
	//ссылка на компонент анимаций
	private Animator anim;
	//находится ли персонаж на земле или в прыжке?
	private bool isGrounded = false;
	//ссылка на компонент Transform объекта
	//для определения соприкосновения с землей
	public Transform groundCheck;
	//радиус определения соприкосновения с землей
	private float groundRadius = 0.2f;
	//ссылка на слой, представляющий землю
	public LayerMask whatIsGround;
	public static int Health = 100;
	bool nearEnemy=false;
	bool nearBoss=false;
	public static int selectedDifficult;
	
	/// <summary>
	/// Начальная инициализация
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
	/// Выполняем действия в методе FixedUpdate, т. к. в компоненте Animator персонажа
	/// выставлено значение Animate Physics = true и анимация синхронизируется с расчетами физики
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

			
				//определяем, на земле ли персонаж
				isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround); 
				//устанавливаем соответствующую переменную в аниматоре
				anim.SetBool ("Ground", isGrounded);
				//устанавливаем в аниматоре значение скорости взлета/падения
				anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
				//если персонаж в прыжке - выход из метода, чтобы не выполнялись действия, связанные с бегом
				//if (!isGrounded)
						//return;
				//используем Input.GetAxis для оси Х. метод возвращает значение оси в пределах от -1 до 1.
				//при стандартных настройках проекта 
				//-1 возвращается при нажатии на клавиатуре стрелки влево (или клавиши А),
				//1 возвращается при нажатии на клавиатуре стрелки вправо (или клавиши D)
				float move = Input.GetAxis ("Horizontal");
		
				//в компоненте анимаций изменяем значение параметра Speed на значение оси Х.
				//приэтом нам нужен модуль значения
				anim.SetFloat ("Speed", Mathf.Abs (move));
		
				//обращаемся к компоненту персонажа RigidBody2D. задаем ему скорость по оси Х, 
				//равную значению оси Х умноженное на значение макс. скорости
				rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		
				//если нажали клавишу для перемещения вправо, а персонаж направлен влево
			
				if (move > 0 && !isFacingRight) {
								//отражаем персонажа вправо
								Flip ();
						}
				
				//обратная ситуация. отражаем персонажа влево
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
		//если персонаж на земле и нажат пробел...
		if (isGrounded && Input.GetKeyDown (KeyCode.Space)) 
		{
			//устанавливаем в аниматоре переменную в false
			anim.SetBool("Ground", false);
			//прикладываем силу вверх, чтобы персонаж подпрыгнул
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
	/// Метод для смены направления движения персонажа и его зеркального отражения
	/// </summary>
	private void Flip()
	{
		//меняем направление движения персонажа
		isFacingRight = !isFacingRight;
		//получаем размеры персонажа
		Vector3 theScale = transform.localScale;
		//зеркально отражаем персонажа по оси Х
		theScale.x *= -1;
		//задаем новый размер персонажа, равный старому, но зеркально отраженный
		transform.localScale = theScale;
	}
}