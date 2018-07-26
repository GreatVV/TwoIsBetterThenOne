using System;
using System.Collections;
using System.Collections.Generic;

public interface IInputController
{
    event Action<UnitCommand> Command;
    void Update();
}