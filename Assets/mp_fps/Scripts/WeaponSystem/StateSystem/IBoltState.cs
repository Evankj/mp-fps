using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoltState
{
   IBoltState DoState(Gun gun);
   void OnEnter(Gun gun, IBoltState previousState);
   void OnExit(Gun gun, IBoltState nextState);
} 
