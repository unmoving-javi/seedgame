using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicGrowth : MonoBehaviour
{
    float currentGrowSeconds = 0;

    public float timeToGrow = 10;
    public float scaleWhenGrown = 1f;

    Transform thisTrans = null;
    Vector3 initialScale = new Vector3(1,1,1);

    public bool physWhenGrown = false;
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
        
        if (!(currentGrowSeconds >= timeToGrow
)) {
            currentGrowSeconds += Time.deltaTime;
            float scale = Mathf.Lerp(0.001f, scaleWhenGrown, currentGrowSeconds/timeToGrow
    );


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
