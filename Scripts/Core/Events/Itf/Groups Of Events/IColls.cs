using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles
{
    #region 2D
    public interface ICollision2D
    {
        bool OnCollision2D(Collision2D coll);
    }
    public interface ICollisionEnter2D
    {
        bool OnCollisionEnter2D(Collision2D coll);
    }
    public interface ICollisionExit2D
    {
        bool OnCollisionExit2D(Collision2D coll);
    }
    public interface ICollisionStay2D
    {
        bool OnCollisionStay2D(Collision2D coll);
    }

    public interface ITrigger2D
    {
        bool OnTrigger2D(Collider2D coll);
    }
    public interface ITriggerEnter2D
    {
        bool OnTriggerEnter2D(Collider2D coll);
    }
    public interface ITriggerExit2D
    {
        bool OnTriggerExit2D(Collider2D coll);
    }
    public interface ITriggerStay2D
    {
        bool OnTriggerStay2D(Collider2D coll);
    }
    #endregion
    #region 3D
    public interface ICollision
    {
        bool OnCollision(Collision coll);
    }
    public interface ICollisionEnter
    {
        bool OnCollisionEnter(Collision coll);
    }
    public interface ICollisionExit 
    {
        bool OnCollisionExit(Collision coll);
    }
    public interface ICollisionStay 
    {
        bool OnCollisionStay(Collision coll);
    }

    public interface ITrigger
    {
        bool OnTrigger(Collider coll);
    }
    public interface ITriggerEnter 
    {
        bool OnTriggerEnter(Collider coll);
    }
    public interface ITriggerExit 
    {
        bool OnTriggerExit(Collider coll);
    }
    public interface ITriggerStay 
    {
        bool OnTriggerStay(Collider coll);
    }
    #endregion
}