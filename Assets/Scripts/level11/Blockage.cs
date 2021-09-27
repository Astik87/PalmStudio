using System.Collections.Generic;
using UnityEngine;

public class Blockage : MonoBehaviour
{
    //private float _interval = 0.5f;

    private Stack<Rigidbody2D> _rigidbodies;
    public GameObject[] blockages;
    
    public bool state;
    public Button[] buttons;

    void Start()
    {
        _rigidbodies = new Stack<Rigidbody2D>();
        state = false;

    }
    
    public void setState(bool s) {
    	if(s && !state) addRigidbody();
    	state = s;
    }

    private void addRigidbody()
    {
		for(int i = 0; i < blockages.Length; i++) {
			Rigidbody2D rb = blockages[i].AddComponent<Rigidbody2D>();
        	//rb.useGravity = false;
        	rb.drag = 1;
        	_rigidbodies.Push(rb);	
		}
    }


    private void FixedUpdate()
    {

        bool f = false;

        for (int i = 1; i < buttons.Length; i++)
        {
            if (!buttons[i - 1].state && buttons[i].state) f = true;
        }

        if (f)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].setState(false);
            };
        }

        if (buttons[buttons.Length - 1].state)
        {
            setState(true);
        } else
        {
            setState(false);
        }

    	if (state) {
    		foreach (Rigidbody2D rigidbody in _rigidbodies)
        	{
            	Vector2 dirToCenter = ((Vector2)transform.position - rigidbody.position).normalized;
            	rigidbody.AddForce(dirToCenter, ForceMode2D.Impulse);
        	}
    	}
    }
}
