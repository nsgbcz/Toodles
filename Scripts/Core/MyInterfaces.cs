using UnityEngine;
//using UnityEngine.Purchasing;
using System;

public interface IAction
{
    void Action();
}

public interface IInvoke<T>
{
    T Invoke();
}
public interface IGet<T>
{
    T Get { get; }
}
public interface ISet<T>
{
    T Set { set; }
}
public interface IVar<T> : IGet<T>, ISet<T> { }

/*public interface IIAPListener
{
    string ID { get; }

    PurchaseProcessingResult Action();
}*/

public interface ISigner
{
    void Subscribe(params Action[] acts);
    void Unsubscribe(params Action[] acts);
}

#region Collider's
public interface IColl
{
    void OnCollisionEnter2D(Collision2D coll);

    void OnCollisionExit2D(Collision2D coll);

    void OnCollisionStay2D(Collision2D coll);

    void OnTriggerEnter2D(Collider2D coll);

    void OnTriggerExit2D(Collider2D coll);

    void OnTriggerStay2D(Collider2D coll);
}

public interface ICollision
{
    void Action(Collision2D coll);
}
public interface ICollisionEnter
{
    void EnterAction(Collision2D coll);
}
public interface ICollisionExit
{
    void ExitAction(Collision2D coll);
}
public interface ICollisionStay
{
    void StayAction(Collision2D coll);
}

public interface ITrigger
{
    void Action(Collider2D coll);
}
public interface ITriggerEnter
{
    void EnterAction(Collider2D coll);
}
public interface ITriggerExit
{
    void ExitAction(Collider2D coll);
}
public interface ITriggerStay
{
    void StayAction(Collider2D coll);
}
#endregion

