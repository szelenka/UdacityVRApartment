using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinGlobe : MonoBehaviour {

    [Tooltip("The name of the Animator trigger parameter")]
    public string triggerName;

    Animator m_Animator;

	// Use this for initialization
    void Start () {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
        // If the player pressed the cardboard button (or touched the screen), set the trigger parameter to active (until it has been used in a transition)
        if (Input.GetMouseButtonDown(0))
        {
            if (m_Animator.GetBool(triggerName) == true)
            {
                m_Animator.ResetTrigger(triggerName);
            }
            else
            {
                m_Animator.SetTrigger(triggerName);
            }
        }
	}
}
