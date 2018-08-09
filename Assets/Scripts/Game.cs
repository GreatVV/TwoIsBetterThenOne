using UnityEngine;

public class Game : MonoBehaviour
{
    public GlobalStateContext Context;

    public void Awake()
    {
        UnitManager.Instance = new UnitManager();
        EventDispatcher.Instance = new EventDispatcher();
    }

    public void Start()
    {
        var unitFactory = new UnitFactory(Context, new MockFactory(Context));
        var unit = unitFactory.CreateUnit();
        UnitManager.Instance.AddUnit(unit);
    }

}