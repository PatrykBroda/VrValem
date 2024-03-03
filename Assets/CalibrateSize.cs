using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrateSize : MonoBehaviour
{
    public float scalepct = 0.05f;
    private float scaleHeight;

    private float scaleArms;
    public Transform lowerArmBoneLeft, upperArmBoneLeft;
    public Transform upperArmBoneRight, lowerArmBoneRight;

   public void GrowHeight()
   {
        scaleHeight = this.transform.localScale.y + scalepct;
        this.gameObject.transform.localScale = new Vector3(scaleHeight, scaleHeight, scaleHeight);
   }

    public void ShrinkHeight()
    {
        scaleHeight = this.transform.localScale.y - scalepct;
        this.gameObject.transform.localScale = new Vector3(scaleHeight, scaleHeight, scaleHeight);
    }

    public void GrowArms()
    {
        scaleArms = lowerArmBoneLeft.localScale.y + scalepct;
        lowerArmBoneLeft.localScale = upperArmBoneLeft.localScale =
          lowerArmBoneRight.localScale = upperArmBoneRight.localScale = 
          new Vector3(scaleArms, scaleArms, scaleArms);
    }

    public void ShirnkArms()
    {
        scaleArms = lowerArmBoneLeft.localScale.y - scalepct;
        lowerArmBoneLeft.localScale = upperArmBoneLeft.localScale =
          lowerArmBoneRight.localScale = upperArmBoneRight.localScale =
          new Vector3(scaleArms, scaleArms, scaleArms);
    }
}
