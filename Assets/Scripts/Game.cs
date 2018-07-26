using UnityEngine;

public class Game : MonoBehaviour
{
    public GlobalStateContext Context;

    public void Start()
    {
        var unitFactory = new UnitFactory(Context, new MockFactory(Context));
        var unit = unitFactory.CreateUnit();
        Context.VirtualCamera.Follow = unit.transform;
        Context.VirtualCamera.LookAt = unit.transform;
    }

}