# Toodles

Набор инструментов для редактора Unity в связке с Odin Serializer.
Подразумевается, что объекты будут создаваться непосредственно в редакторе Unity, а не в коде.
Структура разделена на 4 блока:
+ Core
+ Mono
+ Ecs
+ GamePieces

# Core
Содержит базовый набор интерфейсов и классов.

+ **Variables**

``` C#
    public interface IGet<T>
    {
        T Value { get; }
    }
    public interface ISet<T>
    {
        T Value { set; }
    }
    public interface IVar<T> : IGet<T>, ISet<T>
    {
        new T Value { get; set; }
    }
```
Позволяют гибко реализовать паттерн декоратор.
К примеру, у нас есть следующий код:
``` C#
    public class Value<T> : IVar<T>
    {
        [SerializeField, Required, HideLabel]
        T value;

        T IVar<T>.Value { get => value; set => this.value = value; }
        T IGet<T>.Value { get => value; }
        T ISet<T>.Value { set => this.value = value; }
    }
    public class TimeScaledVector3 : IGet<Vector3>
    {
        [SerializeField, Required, HideLabel]
        IVar<Vector3> value;

        T IGet<T>.Value { get => value * Time.TimeScale; }
    }
    
    void Translate(IGet<Vector3> translation)
    {
        transform.Translate(translation);
    }
```
Допустим, мы хотим чтобы объект переместился на строго определённое расстояние, тогда мы передадим в Translate объект класса Value с нужным значением. Если же нам нужно передать зависимое от времени расстояние, нам нужно просто обернуть Value объект в TimeScaledVector3.
Odin сериализация позволяет редактировать такие цепочки в редакторе.

+ **Global Variables**

Следующий класс позволяет сохранять все IVar объекты как ScriptableObject. 
``` C#
    public class GlobalVariable<T> : SerializedScriptableObject, IVar<T>
    {
        [SerializeField, Required, HideLabel]
        IVar<T> value;
        public T Value { get => value.Value; set => this.value.Value = value; }
    }
```
Но нужно обязательно обязательно иметь унаследованный от GlobalVariable не generic класс, например:
``` C#
    [CreateAssetMenu(menuName = "Toodles/Variables/Float")]
    public class GlobalFloat : GlobalVariable<float> { }
```
+ **Getters**

Это своего рода реализация паттерна адаптер.
``` C#
    public struct SpriteRendererGet : IGet<Color>, IGet<SpriteRenderer>
    {
        [SerializeField, Required, HideLabel]
        IGet<SpriteRenderer> value;
        
        Color IGet<Color>.Value => value.Value.color;
        SpriteRenderer IGet<SpriteRenderer>.Value => value.Value;
    }
```
+ **Injection**

Инъекция зависимостей. IContent нужен для того, чтобы Odin предлагал лишь определённые варианты объектов, которые могут быть инъецированы. Напоминаю, что инъецируемые объекты создаются в Unity.
``` C#
    public interface IContainer
    {
        void SetValue<T>(string key, T value) where T: IContent;
        bool TryGetValue<T>(string key, out T value) where T : IContent;
    }
    public interface IContent { }
    
    public class Container : IContainer
    {
        [SerializeField] Dictionary<string, IVar<IContent>> values = new Dictionary<string, IVar<IContent>>();

        public void SetValue<T>(string key, T value) where T : IContent
        {
            if (values.ContainsKey(key))
            {
                values.Remove(key);
            }
            values.Add(key, new Value<IContent>(value));
        }

        public bool TryGetValue<T>(string key, out T value) where T : IContent
        {
            if (values.TryGetValue(key, out var var))
            {
                var temp = var.Value;
                if (temp is T)
                {
                    value = (T)temp;
                    return true;
                }
            }
            value = default;
            return false;
        }
    }
 ```
 Контейнеры также можно создавать как ScriptableObject. 
``` C#
    [CreateAssetMenu(menuName = "Toodles/Variables/Container")]
    public class GlobalContainer : SerializedScriptableObject, IVar<IContainer> 
    {
        [SerializeField, HideLabel, Required]
        IContainer Container;
        public IContainer Value { get => Container; set => Container = value; }
    }
```
+ **Filters**

``` C#
    public interface IFilter<T>
    {
        bool Filter(T subject);
    }
```
Фильтры предназначены для определения валидности. Например, следующий код валидирует тег передаваемого объекта, что можно использовать для валидации столкновения:
``` C#
    public struct TagFilter : IFilter<string>, IFilter<GameObject>, IFilter<Collider2D>, IFilter<Collider>, IFilter<Collision2D>,IFilter<Collision>
    {
        [SerializeField]
        string[] tags;

        public bool Filter(string tag)
        {
            return tags.Contains(tag);
        }
        public bool Filter(Collider2D subject)
        {
            return Filter(subject.tag);
        }
        public bool Filter(Collider subject)
        {
            return Filter(subject.tag);
        }
        public bool Filter(Collision2D subject)
        {
            return Filter(subject.gameObject.tag);
        }
        public bool Filter(Collision subject)
        {
            return Filter(subject.gameObject.tag);
        }
        public bool Filter(GameObject subject)
        {
            return Filter(subject.tag);
        }
    }
``` 
+ **Poolling**

Реализация пула объектов.
``` C# 
    public interface IPool<T>
    {
        void SetValue(T value);
        bool TryGetValue(out T value);
        void Clear();
    }
    public class Pool<T> : IPool<T>
    {
        protected Stack<T> pool = new Stack<T>();
        public virtual bool TryGetValue(out T value)
        {
            if (pool.Count <= 0)
            {
                value = default;
                return false;
            }
            value = pool.Pop();
            return true;
        }

        public virtual void SetValue(T value)
        {
            pool.Push(value);
        }

        public virtual void Clear()
        {
            pool.Clear();
        }
    }
```
+ **IIterable**

Один из важнейших компонентов системы.
``` C#
    public interface IIteratable
    {
        bool Iterate();
    }
```
Метод Iterate возвращает true если он выполнен полностью и его больше не нужно вызывать, после этого вызывающие объекты обычно удаляют этот объект из списка вызываемых. В ином случае, если возвращено false, то объект этого интерфейса продолжают итерировать.

+ **Iterable controllers**

Контроллеры IIterable интерфейса. Представляют собой массив IIterable, сами являются представителями этого интерфейса. Обрабатывают последовательность вызова IIterable.

``` C#
    public interface IIterableController : IIteratable, IDrawGizmosSelected
    {
        void Add(IIteratable act);

        bool IsValide { get; }
    } 
    public class IfElseIteratable : IIterableController
    {
        public IIteratable If, Then, Else;
        public bool Iterate()
        {
            if (If != null && If.Iterate())
            {
                if (Then == null) return Else == null;
                return Then.Iterate();
            }
            else if (Else == null) return Then == null;
            return Else.Iterate();
        }

        public void Add(IIteratable act)
        {
            Then = act;
        }
        public void OnDrawGizmosSelected()
        {
            (If as IDrawGizmosSelected)?.OnDrawGizmosSelected();
            (Then as IDrawGizmosSelected)?.OnDrawGizmosSelected();
            (Else as IDrawGizmosSelected)?.OnDrawGizmosSelected();
        }
        public bool IsValide
        {
            get { return If != null; }
        }
    }
```

+ **IDrawGizmosSelected**

Нужен для дебага. В примере выше контроллер проверяет, нужно ли отрисовывать Gizmos его IIteratable объектов, если да, то делает это.

+ **IExecuteAdapter**

Представляет собой пустой интерфейс, который нужен лишь для индикации. Наследники этого интерфейса представляют собой адаптер,который выполняет свою функцию по отношению к интерфейсам, предназначенным ТОЛЬКО для обработки события. Причём все они адаптируют только к основным архетипам, которые были выбраны на основе событий движка, таким как: void Action(), bool Iterable(), bool OnCollision(Collision coll) и пр.

``` C#
    public class BaseAdapter<T> : IExecuteAdapter
    {
        [SerializeField, HideLabel]
        public T Value;
    }
    public abstract class IteratableAdapterBase<T> : BaseAdapter<T>, IAction, IIteratable, IMouse, IPointer, ICollision, ICollision2D, ITrigger, ITrigger2D
    {
        protected abstract bool Iterate();

        void IAction.Action()
        {
            Iterate();
        }

        bool IIteratable.Iterate()
        {
            return Iterate();
        }

        bool IMouse.OnMouse()
        {
            return Iterate();
        }

        bool IPointer.OnPointer(PointerEventData data)
        {
            return Iterate();
        }

        bool ICollision.OnCollision(Collision coll)
        {
            return Iterate();
        }

        bool ICollision2D.OnCollision2D(Collision2D coll)
        {
            return Iterate();
        }

        bool ITrigger.OnTrigger(Collider coll)
        {
            return Iterate();
        }

        bool ITrigger2D.OnTrigger2D(Collider2D coll)
        {
            return Iterate();
        }
    }
    
    public class IteratableAdapter : IteratableAdapterBase<IIteratable>
    {
        protected override bool Iterate()
        {
            return Value.Iterate();
        }
    }
    
    public class MouseEnterAdapter : IteratableAdapterBase<IMouseEnter>
    {
        protected override bool Iterate()
        {
            return Value.OnMouseEnter();
        }
    }
```
+ **Handlers**

Управленцы представляют собой статические классы или синглетон классы, к которым идёт обращение только через статические методы, причём экземпляр объекта получать не нужно (таких много в Mono части).
Обычно управляют какой-нибудь значимой частью движка (TimeHandler) или представляют собой реакцию на игровые события (Updateб FixedUpdate, OnSceneLoad, OnPause), причём как правило позволяют выбрать порядок выполнения.

