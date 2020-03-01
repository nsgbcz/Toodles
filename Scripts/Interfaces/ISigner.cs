using System;

namespace Toodles
{
    public interface ISigner
    {
        void Subscribe(params Action[] acts);
        void Unsubscribe(params Action[] acts);
    }

}
