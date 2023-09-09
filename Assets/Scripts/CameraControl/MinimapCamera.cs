
using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;
    public GameObject currCharacter;

    [SerializeField] private Transform playerIcon; 
 
    private Vector3 distance;
    private Vector3 ve;
    // Start is called before the first frame update
    void Start()
    {
        currCharacter = character1;
        distance = new Vector3(0, 120, -10);
        playerIcon.rotation = Quaternion.Euler(new Vector3(90, 0, -90));
    }

    // Update is called once per frame
    void Update()
    {
        //Let the camera move smoothly
        transform.position = Vector3.SmoothDamp(transform.position, currCharacter.transform.position + distance, ref ve, 0.1f);
        transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));

        playerIcon.position = currCharacter.transform.position;
        playerIcon.eulerAngles = new Vector3(90, 0, -currCharacter.transform.eulerAngles.y+90);
    }
}