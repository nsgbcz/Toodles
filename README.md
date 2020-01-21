# UnityBlueprintSystem
Blueprint system for Unity, that **requires [Odin Inspector](https://odininspector.com)**

# Core
There is several main files:
* **MyInterfaces.cs** declarates interfaces for extensions and handlings.
* **MyDelegates.cs** implements some classes to containing of delegates and the arguments to use them. It is very dirty for observing but useful for system at all.
**MyContainers.cs** implements several containers, that handle the executing of MyDelegates, and builder, that assembles MyDelegates.
##IInvoke<bool>
  All MyDelegates are inherited from this interface, that forced implement them **bool Invoke()** method. In MyDelegates the **Invoke** returnes true when the delegate contained in MyDelegate is completely executed(returned true or the MyDelegate is marked as **oneInvocation**)
##IContainer
All containers have a kind of array with MyDelegates and builders in them. And all of them have a method that makes builders the MyDelegates. 
They all are inherited from **IInvoke<bool>**. 
In all containers the **Invoke** method executes **Invoke** of MyDelegates. Different containers handle it differently. For example: 
⋅⋅* The **ListContainer** just executes all array and remove those of them, who returned true. Its **Invoke** returns true if there is no elements to execute.
⋅⋅* The **Sequence**'s **Invoke** return true when all MyDelegates returned true. Removes MyDelegates if they true. Stops and return false if some MyDelegate has returned false.
