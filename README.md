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

+ Variables
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

+ Global Variables
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
+ Getters
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
+ Injection
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
