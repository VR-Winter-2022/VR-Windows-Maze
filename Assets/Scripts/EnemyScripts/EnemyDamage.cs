using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 2;
    public LayerMask playerLayer;
	public int hit_radius=5;

	void Update()
	{

		Collider[] hits = Physics.OverlapSphere(transform.position, hit_radius, playerLayer);

		if (hits.Length > 0)
		{

			if (hits[0].gameObject.tag == GameTags.PLAYER_TAG)
			{
				//hits[0].gameObject.GetComponent<PlayerHealth>().ApplyDamage(damageAmount);

			}

		}

	}
}
