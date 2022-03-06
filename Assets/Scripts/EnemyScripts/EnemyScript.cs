using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody myBody;
    private Animator anim;

    private float enemy_Speed = 10f;
    private float enemy_Watch_Threshold = 70f; //if the distance between the player and the enemey is lesser than this, the enemy will start walking towards the player
    private float enemy_Attack_Threshold = 6f; //the enemy will start attacking the player

    void Awake() {
        player = GameObject.FindGameObjectWithTag(GameTags.PLAYER_TAG); //add the player tag here

        myBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
		EnemyAI();
	}

    void EnemyAI() {

		Vector3 direction = player.transform.position - transform.position; 
		float distance = direction.magnitude; //to check if the player is close enough to the enemy
		direction.Normalize(); //to chase the player in that direction

		Vector3 velocity = direction * enemy_Speed;

		if (distance > enemy_Attack_Threshold && distance < enemy_Watch_Threshold)
		{
			//run
			myBody.velocity = new Vector3(velocity.x, myBody.velocity.y, velocity.z);

			if (anim.GetCurrentAnimatorStateInfo(0).IsName(GameTags.ATTACK_ANIMATION))
			{
				anim.SetTrigger(GameTags.STOP_TRIGGER);
			}

			anim.SetTrigger(GameTags.RUN_TRIGGER);

			transform.LookAt(new Vector3(player.transform.position.x,
				transform.position.y, player.transform.position.z));


		}
		else if (distance < enemy_Attack_Threshold)
		{
			//attack
			if (anim.GetCurrentAnimatorStateInfo(0).IsName(GameTags.RUN_ANIMATION))
			{
				anim.SetTrigger(GameTags.STOP_TRIGGER);
			}

			anim.SetTrigger(GameTags.ATTACK_TRIGGER);


			transform.LookAt(new Vector3(player.transform.position.x,
				transform.position.y, player.transform.position.z));

		}
		else
		{

			myBody.velocity = new Vector3(0f, 0f, 0f);

			if (anim.GetCurrentAnimatorStateInfo(0).IsName(GameTags.RUN_ANIMATION) ||
			   anim.GetCurrentAnimatorStateInfo(0).IsName(GameTags.ATTACK_ANIMATION))
			{

				anim.SetTrigger(GameTags.STOP_TRIGGER);

			}


		}
	}
}
