using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCloseTarget : MonoBehaviour
{
    public GameObject cactusTargetImageTarget;
    public Animator cactusTargetAnimator;


    bool isCactusTargetClose = false;


    void OnCactusTargetEnter() {
      cactusTargetAnimator.SetBool("closeToTarget", true);
    }

    void OnCacturTargetLeave() {
      cactusTargetAnimator.SetBool("closeToTarget", false);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(
          cactusTargetImageTarget.transform.position, 
          this.transform.position
        );

        bool wasCactusTargetClose = isCactusTargetClose;

        if (Mathf.Abs(distance) <= 0.16 && !wasCactusTargetClose) {
          isCactusTargetClose = true;
          OnCactusTargetEnter();
        }

        if (Mathf.Abs(distance) > 0.16 && wasCactusTargetClose) {
          isCactusTargetClose = false;
          OnCacturTargetLeave();
        }
    }
}
