using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    #region 2D
    /*public interface IColl2D
    {
        void OnCollisionEnter2D(Collision2D coll);

        void OnCollisionExit2D(Collision2D coll);

        void OnCollisionStay2D(Collision2D coll);

        void OnTriggerEnter2D(Collider2D coll);

        void OnTriggerExit2D(Collider2D coll);

        void OnTriggerStay2D(Collider2D coll);
    }*/

    public interface ICollision2D
    {
        void Action(Collision2D coll);
    }
    public interface ICollisionEnter2D
    {
        void EnterAction(Collision2D coll);
    }
    public interface ICollisionExit2D
    {
        void ExitAction(Collision2D coll);
    }
    public interface ICollisionStay2D
    {
        void StayAction(Collision2D coll);
    }

    public interface ITrigger2D
    {
        void Action(Collider2D coll);
    }
    public interface ITriggerEnter2D
    {
        void EnterAction(Collider2D coll);
    }
    public interface ITriggerExit2D
    {
        void ExitAction(Collider2D coll);
    }
    public interface ITriggerStay2D
    {
        void StayAction(Collider2D coll);
    }
    #endregion
    #region 3D
    /*public interface IColl
    {
        void OnCollisionEnter(Collision coll);

        void OnCollisionExit(Collision coll);

        void OnCollisionStay(Collision coll);

        void OnTriggerEnter(Collider coll);

        void OnTriggerExit(Collider coll);

        void OnTriggerStay(Collider coll);
    }*/

    public interface ICollision
    {
        void Action(Collision coll);
    }
    public interface ICollisionEnter
    {
        void EnterAction(Collision coll);
    }
    public interface ICollisionExit
    {
        void ExitAction(Collision coll);
    }
    public interface ICollisionStay
    {
        void StayAction(Collision coll);
    }

    public interface ITrigger
    {
        void Action(Collider coll);
    }
    public interface ITriggerEnter
    {
        void EnterAction(Collider coll);
    }
    public interface ITriggerExit
    {
        void ExitAction(Collider coll);
    }
    public interface ITriggerStay
    {
        void StayAction(Collider coll);
    }
    #endregion
}