using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

public class QTEUI : MonoBehaviour
{
    public Sprite up;
    public Sprite left;
    public Sprite right;
    public Sprite down;
    public Sprite success;
    public Sprite fail;
    private QTE qteSystem;
    private Image image;
    private State state;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get the state of the current QTE system
        state = (State)qteSystem.getState();

        if (state == State.inProgress)
        {
            List<KeyCode> QTEOrder = qteSystem.getQTEOrder();
            switch (QTEOrder[0])
            {
                case KeyCode.W:
                    image.sprite = up;
                    break;
                case KeyCode.A:
                    image.sprite = left;
                    break;
                case KeyCode.S:
                    image.sprite = down;
                    break;
                case KeyCode.D:
                    image.sprite = right;
                    break;
            }
        } else if (state == State.fail)
        {
            image.sprite = fail;
        } else
        {
            image.sprite = success;
        }
        
    }

    private void OnEnable()
    {
        
        image = GetComponent<Image>();
        qteSystem = transform.parent.GetComponentInParent<QTE>();
        state = (State)qteSystem.getState();
    }
    public enum State
    {
        successful,
        fail,
        inProgress
    }

}
