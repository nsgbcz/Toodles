# UnityBlueprintSystem
Blueprint system for Unity, that **REQUIRES [Odin Inspector](https://odininspector.com)**. It makes prototyping and developing more easyer.

# Why i use Odin in package?
  **Odin Inspector** allow as simply and conveniently show interfaces, delegates, types and other variables. So we can do a lot more things that makes our developing easier. This asset is one of them.
  
  **But *Odin* limits us cause he can't work with neasted prefabs, and all components that we want to change in our chilren we should copy/paste.**
  
# Core
  There is several main files:
* **MyInterfaces.cs** declarates interfaces for extensions and handlings.
* **MyDelegates.cs** implements some classes to containing of delegates and the arguments to use them. It is very dirty for observing but useful for system at all.
* **MyContainers.cs** implements several containers, that handle the executing of MyDelegates, and builder, that assembles MyDelegates.
  
  **Hereinafter "MyDelegates" means classes and them instances, that are contained in *MyDelegates.cs* and correspond to its appointment.**

## IInvoke`<`bool`>`
  
  All MyDelegates are inherited from this interface, that forced implement them **bool Invoke()** method.
  
  In MyDelegates the **Invoke** returnes true when the delegate contained in MyDelegate is completely executed (returned true or the MyDelegate is marked as **oneInvocation**)
  
## IContainer
  All containers have a kind of array with MyDelegates and builders in them. 
  
  All of them have a method that makes builders the MyDelegates and this method is shown in Inspector as button. 
  
  ![ListContainer](https://github.com/nsgbcz/UnityBlueprintSystem/blob/master/Screens/ListContainer.jpg)
  
  They all are inherited from **IInvoke`<`bool`>`**. 
  
  In all containers the **Invoke** method executes **Invoke** of MyDelegates. Different containers handle it differently. 
  
  For example: 
  * The **ListContainer** just executes all array and remove those of them, who returned true. Its **Invoke** returns true if there is no elements to execute.
  * The **Sequence**'s **Invoke** return if there is no elements to execute, removes MyDelegates if they true, stops and return false if some MyDelegate has returned false.
  
## ReferenceMethodBuilder
  Has two modes:
  * **IsStatic = true**: takes a **TypeInfo** as target class that will be explored and **then** you should choose its static method that you want to implement.
  * **IsStatic = false**: take an **object** as target that will be explored, **then** you choose **Type** of object, **then** choose any method that you want to implement.
  
  ![ReferenceMethodBuilder](https://github.com/nsgbcz/UnityBlueprintSystem/blob/master/Screens/ReferenceMethodBuilder.png)
  
  The **FreshType** button help us if variables "Meth" and "Type" was reset.
  
  When you setted a builder push the "SetAction" button on container, that contain the builder. Builder was replaced by certain MyDelegate. Now you have to fill the properties and it's ready to use.
  
  ![ReadyDelegate](https://github.com/nsgbcz/UnityBlueprintSystem/blob/master/Screens/ReadyDelegate.jpg)
  
# Variables

For easier usage was made several powerful interfaces, they implement the **Decorator Pattern**. Below are they and their inheritors for extension example:

``` C#
public interface IGet<T> { T Get { get; } }
public interface ISet<T> { T Set { set; } }
public interface IVar<T> : IGet<T>, ISet<T> { }

public class Var<T> : IVar<T>
{
    public T Value;
    public virtual T Get => Value;
    public virtual T Set { set => Value = value; }
}
public class Getter<T> : IGet<T>
{
    public T Value;
    public virtual T Get => Value;
}
public class Setter<T> : ISet<T>
{
    public T Value;
    public virtual T Set { set => Value = value; }
}
public struct GetComponent<T> : IGet<T>
{
    public IGet<GameObject> Value;
    public T Get => Value.Get.GetComponent<T>();
}
public struct MousePosition : IGet<Vector2>
{
    public Vector2 Get => CameraHandler.MainCamera.ScreenToWorldPoint(Input.mousePosition);
}
public struct MultiplyFloat : IGet<float>
{
    public IGet<float> First, Second;

    public float Get => First.Get * Second.Get;
}
public struct DeltaTime : IGet<float>
{
    public enum Type { Scaled, Unscaled, Fixed, UnscaledFixed }

    public Type DeltaType;
    public float Get
    {
        get
        {
            switch (DeltaType)
            {
                case Type.Scaled:
                    return Time.deltaTime;
                case Type.Unscaled:
                    return Time.unscaledDeltaTime;
                case Type.Fixed:
                    return Time.fixedDeltaTime;
                default:
                    return Time.fixedUnscaledDeltaTime;
            }
        }
    }
}
```
  
# Executing

Okay, we have some delegate in our container it's time to execute it.

The way is just declare IInvoke`<`bool`>` in an any Odin Serialized script ([see Odin documentation] (https://odininspector.com/odin-serializer)).

I made several scripts for this goal:

* ## Execute
It's implements the
``` C#
public interface IExecute : IAction, IListContainer, IInvoke<bool> { }
```
And has a button for execute from Inspector.

  ![ReadyDelegate](https://github.com/nsgbcz/UnityBlueprintSystem/blob/master/Screens/Execute.jpg)
  
  
Also he has inheritors:
  * ## GeneralExecute
  Except containers has a EventTime mask. It covers a most of MonoBehaviour's events.
  
  ![ReadyDelegate](https://github.com/nsgbcz/UnityBlueprintSystem/blob/master/Screens/GeneralExecute.jpg)
  
  * ## CollExecute
  There we have an EventMask to process collisions and a bunch of settings for layer & tag handling.
  
  ![ReadyDelegate](https://github.com/nsgbcz/UnityBlueprintSystem/blob/master/Screens/CollExecute.jpg)
  
  Also we have **SetCollision** and **SetCollider** properies that will help us transfer collision's data.
  
  Here we will come in handy our variables.
  
  To hand data in delegate we need to did a **CopyReference** of changing property and paste it in the SetCollision or SetCollider in the dependency of the property type (it must be ISet`<`Collision2D`>` or ISet`<`Collider2D`>`).
  
  ![ReadyDelegate](https://github.com/nsgbcz/UnityBlueprintSystem/blob/master/Screens/CopyPasteCollExecute.jpg)
  
  When we do that, our CollExecute will replacing the value of our ISet object with "other" Collision2D or Colllider2D before each execute.
  
