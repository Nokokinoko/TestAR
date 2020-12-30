using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyModelTrackableEventHandler : DefaultTrackableEventHandler
{
  protected override void OnTrackingFound()
  {
    base.OnTrackingFound();

    if (mTrackableBehaviour.gameObject.GetComponentInChildren<MyModelController>() != null)
    {
      mTrackableBehaviour.gameObject.GetComponentInChildren<MyModelController>().StartAnime();
    }
  }

  protected override void OnTrackingLost()
  {
    base.OnTrackingLost();

    if (mTrackableBehaviour.gameObject.GetComponentInChildren<MyModelController>() != null)
    {
      mTrackableBehaviour.gameObject.GetComponentInChildren<MyModelController>().EndAnime();
    }
  }
}
