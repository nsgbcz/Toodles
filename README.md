# UnityBlueprintSystem
Blueprint system for Unity, that **REQUIRES [Odin Inspector](https://odininspector.com)**

# Why use Odin?
  **Odin Inspector** allow as simply and conveniently show interfaces, delegates, types and other variables. So we can do a lot more things that makes our developing easier. This asset is one of them.
  
  **But *Odin* limits us cause he can't work with neasted prefabs, and all components that we want to change in our chilren we should copy/paste.**
  
# Core
  There is several main files:
* **MyInterfaces.cs** declarates interfaces for extensions and handlings.
* **MyDelegates.cs** implements some classes to containing of delegates and the arguments to use them. It is very dirty for observing but useful for system at all.
* **MyContainers.cs** implements several containers, that handle the executing of MyDelegates, and builder, that assembles MyDelegates.
  
  **Hereinafter "MyDelegates" means classes and them instances, that are contained in *MyDelegates.cs* and correspond to its appointment.**

## IInvoke`<bool>`
  
  All MyDelegates are inherited from this interface, that forced implement them **bool Invoke()** method.
  
  In MyDelegates the **Invoke** returnes true when the delegate contained in MyDelegate is completely executed (returned true or the MyDelegate is marked as **oneInvocation**)
  
## IContainer
  All containers have a kind of array with MyDelegates and builders in them. 
  
  All of them have a method that makes builders the MyDelegates and this method is shown in Inspector as button. 
  
  ![ListContainer](https://github.com/nsgbcz/UnityBlueprintSystem/blob/master/Screens/ListContainer.jpg)
  
  They all are inherited from **IInvoke`<bool>`**. 
  
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
  
