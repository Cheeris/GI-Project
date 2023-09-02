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
            switch (QTEOrder.Count)
            {
                case 5:
                    image.color = Color.black;
                    break;
                case 4:
                    image.color = Color.blue;
                    break;
                case 3:
                    image.color = Color.green;
                    break;
                case 2:
                    image.color = new Color(1.0f, 0.5f, 0.0f);
                    break;
                case 1:
                    image.color = Color.red;
                    break;
                case 0:
                    image.color = Color.black;
                    break;
            }
               
            if (QTEOrder.Count != 0)
            {
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
            }
            
        } else if (state == State.shutdownFail)
        {
            image.sprite = fail;
        } else if (state == State.shutdownSuccessful)
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
        inProgress,
        shutdownSuccessful,
        shutdownFail
    }

}
