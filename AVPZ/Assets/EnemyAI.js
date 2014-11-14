private var Player : Transform; //This get the Player Transform

var Speed : float = 1; //This is the Enemy Speed
var Distance : float = 15; //The Distance before he can see the player

var Smooth : float = 2; //This is how fast the Enemy Rotate

function Awake ()
{
Player = GameObject.FindGameObjectWithTag("Player").transform;
//Set our private var Player to find a GameObject with tag "Player"
}

function Update () 
{
//Check the Distance
if (Vector3.Distance(Player.position,transform.position) <= Distance)
{

renderer.material.color = Color.red; //If he see you his color change to Red

transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Player.position - transform.position), Time.deltaTime * Smooth);
//Look At the Player

transform.position = Vector3.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
//Move Towards the Player
}

else

{
 renderer.material.color = Color.green; //if he don't see you his color change to green
}

}
