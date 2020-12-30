using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyModelController : MonoBehaviour
{
  // Idle -> Walk -> Wait -> Pose
  private static readonly int ID_BASE_LAYER = 0;
  private static readonly string STATE_WALK = "Walk";
  private static readonly string PRM_TO_IDLE = "toIdle";
  private static readonly string PRM_TO_WALK = "toWalk";
  private static readonly Vector3 POS_INIT = new Vector3(0.0f, 0.5f, -0.25f);

  private bool m_IsAnime = false;

  private Animator m_Animator = null;
  private Animator acs_Animator
  {
    get
    {
      if(m_Animator == null)
      {
        m_Animator = GetComponent<Animator>();
      }
      return m_Animator;
    }
  }

  private void Start()
  {
    m_IsAnime = false;

    this.transform.position = POS_INIT;
  }

  private void Update()
  {
    if(m_IsAnime && acs_Animator.GetCurrentAnimatorStateInfo(ID_BASE_LAYER).IsName(STATE_WALK))
    {
      Vector3 _Pos = this.transform.position;
      _Pos.y += 0.01f;
      this.transform.position = _Pos;
    }
  }

  public void StartAnime()
  {
    acs_Animator.ResetTrigger(PRM_TO_IDLE);

    this.transform.position = POS_INIT;

    m_IsAnime = true;
    acs_Animator.SetTrigger(PRM_TO_WALK);
  }

  public void EndAnime()
  {
    acs_Animator.ResetTrigger(PRM_TO_WALK);

    m_IsAnime = false;
    acs_Animator.SetTrigger(PRM_TO_IDLE);
  }
}
