using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMagazineState
{
   IMagazineState DoState(Gun gun);
   void OnEnter(Gun gun, IMagazineState previousState);
   void OnExit(Gun gun, IMagazineState nextState);
}