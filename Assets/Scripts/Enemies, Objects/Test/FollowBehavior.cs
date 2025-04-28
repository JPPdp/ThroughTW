using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehavior : StateMachineBehaviour {

    private AudioSource source;
    public Transform playerPos;
    public float speed;

    // Start
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    source = animator.GetComponent<AudioSource>();
    if (source != null) {
        source.Play();
    } else {
        Debug.LogWarning("No AudioSource component found on Animator.");
    }

    GameObject player = GameObject.FindGameObjectWithTag("Player");
    if (player != null) {
        playerPos = player.transform;
    } else {
        Debug.LogWarning("No GameObject with 'Player' tag found.");
    }
        
	}

    // Update
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        if (playerPos != null) {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetBool("isFollowing", false);
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            animator.SetBool("isPatrolling", true);
        }
	}

    //Stops
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
