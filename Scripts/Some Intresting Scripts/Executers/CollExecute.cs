using MyDelegates;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollExecute : Execute, ICollision, ITrigger, IColl
{
    public MyEnumMask EventMask = new MyEnumMask(typeof(EventTime));

    void FreshPermissions()
    {
        var enums = Enum.GetValues(typeof(EventTime)).Cast<Enum>().ToArray();
        for (int i = 0; i < permissions.Length; i++) permissions[i] = EventMask.IsExecuteAble(enums[i]);
    }

    public enum EventTime
    {
        CollisionEnter, CollisionExit, CollisionStay, TriggerEnter, TriggerExit, TriggerStay
    }

    [Tooltip("Copy/Paste >Reference< of ISetValue<Collision2D> from MethList (for collision)")]
    public List<ISet<Collision2D>> SetCollision = new List<ISet<Collision2D>>();

    [Tooltip("Copy/Paste >Reference< of ISetValue<Collider2D> from MethList (for trigger)")]
    public List<ISet<Collider2D>> SetCollider = new List<ISet<Collider2D>>();

    public bool useLayer = true;
    [ShowIf("useLayer")]
    public bool ignoreLayer = false;
    [ShowIf("useLayer")]
    public LayerMask collisionLayer = 0;

    public bool useTags = false;
    [ShowIf("useTags")]
    public bool ignore = false;
    [ShowIf("useTags")]
    public string[] collisionTags = new string[] { "Ball", "Explosion" };

    private bool enable;

    void Awake()
    {
        enable = isActiveAndEnabled;
        FreshPermissions();
        if (!permissions.Contains(true)) Destroy(this);
    }

    void OnEnable()
    {
        enable = true;
    }
    void OnDisable()
    {
        enable = false;
    }

    public void Action(Collision2D coll)
    {
        foreach (var item in SetCollision) { item.Set = coll; }
        Action();
    }

    public void Action(Collider2D coll)
    {
        foreach (var item in SetCollider) item.Set = coll;
        Action();
    }

    bool[] permissions = new bool[6];
    public virtual void OnCollisionEnter2D(Collision2D coll)
    {
        if (enable && permissions[0]) 
        {
            var go = coll.collider.gameObject;
            if(IsCollideAble(go.layer, go.tag)) Action(coll);
        }
    }

    public virtual void OnCollisionExit2D(Collision2D coll)
    {
        if (enable && permissions[1])
        {
            var go = coll.collider.gameObject;
            if (IsCollideAble(go.layer, go.tag)) Action(coll);
        }
    }

    public virtual void OnCollisionStay2D(Collision2D coll)
    {
        if (enable && permissions[2])
        {
            var go = coll.collider.gameObject;
            if (IsCollideAble(go.layer, go.tag)) Action(coll);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if (enable && permissions[3] && IsCollideAble(coll.gameObject.layer, coll.tag)) Action(coll);
    }

    public virtual void OnTriggerExit2D(Collider2D coll)
    {
        if (enable && permissions[4] && IsCollideAble(coll.gameObject.layer, coll.tag)) Action(coll);
    }

    public virtual void OnTriggerStay2D(Collider2D coll)
    {
        if (enable && permissions[5] && IsCollideAble(coll.gameObject.layer, coll.tag)) Action(coll);
    }

    public bool IsCollideAble(int layer, string tag)
    {
        return (!useLayer || ((collisionLayer.value == (collisionLayer.value | (1 << layer))) != ignoreLayer))
            && (!useTags || collisionTags.Contains(tag) != ignore);
    }
}
