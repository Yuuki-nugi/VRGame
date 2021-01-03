using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class MagicHand : MonoBehaviour
{
    GameObject YellowCharge;
    GameObject OrangeCharge;

    public GameObject Hand;
    public GameObject YellowEne;
    public GameObject OrangeEne;

    float chargecount1;
    bool charge1 = false;
    bool charge2 = false;


    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            YellowCharge = (GameObject)Instantiate(YellowEne, this.transform.position, Quaternion.identity);
            YellowCharge.transform.parent = Hand.transform;

            charge1 = true;
        }


        if (charge1 == true)
        {
            chargecount1 += Time.deltaTime;
            
            if(chargecount1 > 5)
            {
                Destroy(YellowCharge);

                OrangeCharge = (GameObject)Instantiate(OrangeEne, this.transform.position, Quaternion.identity);
                OrangeCharge.transform.parent = Hand.transform;

                chargecount1 = 0;

                charge1 = false;
                charge2 = true;
            }

            if (OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                charge1 = false;
                Destroy(YellowCharge);
            }
        }

        if(charge2 == true)
        {
            if (OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.RTouch))
            {
                charge2 = false;
                Destroy(OrangeCharge);
            }
        }

    }

}
