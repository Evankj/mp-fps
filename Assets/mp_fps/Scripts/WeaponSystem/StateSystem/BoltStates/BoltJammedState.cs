using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltJammedState : IBoltState
{
    public IBoltState DoState(Gun gun) {
        return this;
    }
    public void OnEnter(Gun gun, IBoltState previousState) {}
    public void OnExit(Gun gun, IBoltState nextState) {}
}
