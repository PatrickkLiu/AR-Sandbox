using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiAssigner : MonoBehaviour
{
    public GameObject TearsOfJoy;
    //public Transform assignTarget;
    public Camera assignCamera;

    private Transform emotionHolder;
    
    void OnTriggerEnter (Collider other) 
    {
        if (other.CompareTag ("SandToy")) 
        {
            //Access the emotionholder of the player by getting the "EmotionHolder" child of the colliding body's parent  
            emotionHolder = other.gameObject.transform.parent.GetChild(1);
            
            //Destroy previously attached emotion 
            foreach (Transform child in emotionHolder) {
                GameObject.Destroy(child.gameObject);
            }

            //Attach a new Emotion
            GameObject ThoughtBubble = Instantiate(TearsOfJoy, other.gameObject.transform.position, Quaternion.identity,emotionHolder);

            //Make the  Emoji follow the colliding sandtoy
            BubbleFollow MyBubbleFollow = ThoughtBubble.GetComponent<BubbleFollow>();
            MyBubbleFollow.followTarget = other.gameObject.transform;

            //Make the Emoji face the assigned camera
            CameraFacingBillboard MyBillboardScript = ThoughtBubble.GetComponent<CameraFacingBillboard>();
            MyBillboardScript.facingCamera = assignCamera;



            //firework.GetComponent<ParticleSystem>().Play();
            //this.GetComponent<AudioSource>().Play();
        }
    }

}
