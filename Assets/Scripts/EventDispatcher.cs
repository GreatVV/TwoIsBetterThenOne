using System;
using System.Collections.Generic;

public class EventDispatcher
{
    public static EventDispatcher Instance;

    private Dictionary<Type, Action<GameEvent>> Callbacks = new Dictionary<Type, Action<GameEvent>>();

    public EventDispatcher()
    {
        Callbacks[typeof(DealDamage)] = DealDamageCallback;
    }

    private void DealDamageCallback(GameEvent obj)
    {
        var dealDamage = obj as DealDamage;
        var unitId = dealDamage.UnitID;
        var amount = dealDamage.Amount;
        UnitManager.Instance.GetById(unitId).Health.Amount -= (int)amount;
    }

    public void Enqueue(GameEvent gameEvent)
    {
        Callbacks[gameEvent.GetType()]?.Invoke(gameEvent);
    }

}