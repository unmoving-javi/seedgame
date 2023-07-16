using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicGrowth : MonoBehaviour
{
    float currentGrowSeconds = 0f;

    // delay in seconds until growth begins
    public float delayToGrow = 0f;

    //seconds it takes to grow fully
    public float timeToGrow = 10f;

    //multiplier to final scale when completely grown
    public float scaleWhenGrown = 1f;

    // for internal use
    Transform thisTrans = null;
    Vector3 initialScale = new Vector3(1,1,1);

    //if true, the child object of this plant will become a physics object when grown
    public bool physWhenGrown = false;

    // for internal use
    bool grown = false;


    // Start is called before the first frame update
    void Start()
    {
        thisTrans = this.gameObject.transform;
        initialScale= thisTrans.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!(currentGrowSeconds >= timeToGrow)) {
            float scale = 0.00001f;
            currentGrowSeconds += Time.deltaTime;
            if (!(currentGrowSeconds < delayToGrow)){
                scale = Mathf.Lerp(0.001f, scaleWhenGrown, (currentGrowSeconds+delayToGrow)/(timeToGrow+delayToGrow));
            }


            thisTrans.localScale = new Vector3(scale*initialScale.x, scale*initialScale.y, scale*initialScale.z);
        } else if (physWhenGrown && thisTrans.childCount >= 1 && !grown){
            Rigidbody2D plantPhys = thisTrans.GetChild(0).gameObject.GetComponent<Rigidbody2D>();

            plantPhys.bodyType = RigidbodyType2D.Dynamic;

            grown = true;


        } else {
            grown = true;
            // idk
        }
    }
}
