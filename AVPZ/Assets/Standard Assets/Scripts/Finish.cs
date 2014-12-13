using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Data;
using Mono.Data.SqliteClient;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class Finish : MonoBehaviour {
	public static string nick="";
	int checkpoint;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "konez")
		{
			checkpoint=2;
			Shop.Checkpoint=checkpoint;
			int score = coinsCollect.score;
			Debug.Log("in trigger");
			string _strDBName = "URI=file:Assets/DB/Unity.db";
			IDbConnection _connection = new SqliteConnection (_strDBName);
			IDbCommand _command = _connection .CreateCommand ();
			string sql;
			
			_connection .Open ();
			
			sql = "UPDATE Players SET Score= Score+'"+score+"', Checkpoint='"+checkpoint+"'WHERE Login='"+nick+"';";
			_command.CommandText = sql;
			_command.ExecuteNonQuery ();
			_command.Dispose ();
			_command = null;
			_connection .Close ();
			_connection = null;
			Application.LoadLevel("Shop");
		}
	} 
}
