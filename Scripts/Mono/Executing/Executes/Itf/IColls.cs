using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    #region 2D
    public interface ICollision2D
    {
        bool Action(Collision2D coll);
    }
    public interface ICollisionEnter2D : ICollision2D
    {

    }
    public interface ICollisionExit2D : ICollision2D
    {

    }
    public interface ICollisionStay2D : ICollision2D
    {

    }

    public interface ITrigger2D
    {
        bool Action(Collider2D coll);
    }
    public interface ITriggerEnter2D : ITrigger2D
    {

    }
    public interface ITriggerExit2D : ITrigger2D
    {

    }
    public interface ITriggerStay2D : ITrigger2D
    {

    }
    #endregion
    #region 3D
    public interface ICollision
    {
        bool Action(Collision coll);
    }
    public interface ICollisionEnter : ICollision
    {

    }
    public interface ICollisionExit : ICollision
    {

    }
    public interface ICollisionStay : ICollision
    {

    }
    public interface ITrigger
    {
        bool Action(Collider coll);
    }
    public interface ITriggerEnter : ITrigger
    {

    }
    public interface ITriggerExit : ITrigger
    {

    }
    public interface ITriggerStay : ITrigger
    {

    }
    #endregion
}