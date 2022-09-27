
using UnityEngine;

public class RaycastFPS : MonoBehaviour
{

    RaycastHit hitInfo;

    AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start(){
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetButtonDown("Fire1")){
            Debug.Log("I pressed the left button of the mouse");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo)){
                if (!myAudioSource.isPlaying){
                    myAudioSource.Play();
                }

                //Cursor.visible = true;
                Debug.Log($"GameObjectName : {hitInfo.collider.gameObject.name}");

                if (hitInfo.collider.gameObject.tag != "Ground"){
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
    }
}
