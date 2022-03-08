using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount =1;
    public LayerMask playerLayer;
	public float hit_radius=1;

	void FixedUpdate()
	{

		Collider[] hits = Physics.OverlapSphere(transform.position, hit_radius, playerLayer);

		if (hits.Length > 0)
		{

			if (hits[0].gameObject.tag == GameTags.PLAYER_TAG)
			{
				hits[0].gameObject.GetComponent<TimeLeftController>().ApplyDamage(damageAmount);

			}

		}

	}
}
