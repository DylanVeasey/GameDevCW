using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGuardState
{
    public void OnEnter(GuardStateController controller);
    public void OnExit(GuardStateController controller);

    public void UpdateState(GuardStateController controller);
}
