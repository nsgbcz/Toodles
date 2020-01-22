using System.Collections.Generic;
using System;
using System.Linq;

namespace BP
{
    [Serializable]
    public class MyEnumMask
    {
        public Enum[] enums = new Enum[0];
        public int EventMask = 0;

        public MyEnumMask(params Type[] enums)
        {
            List<Enum> listEnums = new List<Enum>();
            foreach (var item in enums)
            {
                listEnums.AddRange(Enum.GetValues(item).Cast<Enum>());
            }
            this.enums = listEnums.ToArray();
        }
        public MyEnumMask(Type enums)
        {
            this.enums = Enum.GetValues(enums).Cast<Enum>().ToArray();
        }
        //public MyEnumMask()
        //{
        //    throw new Exception("You can use only overloaded constructor. Otherwise will troubles in Unity.");
        //}
        public void AddMask(Enum layer)
        {
            var index = Array.IndexOf(enums, layer);
            if (index < 0) return;

            EventMask = EventMask | (1 << index);
        }
        public bool IsExecuteAble(Enum layer)
        {
            return IsExecuteAble(Array.IndexOf(enums, layer));
        }
        public bool IsExecuteAble(int layer)
        {
            //if (layer < 0 || layer > 31) throw new Exception("Enums doesn't contain " + layer.ToString());
            return (EventMask == (EventMask | (1 << layer)));
        }
    }
}
