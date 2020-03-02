using System;

namespace Toodles.Variables
{
    public interface ISigner
    {
        void Subscribe(params Action[] acts);
        void Unsubscribe(params Action[] acts);
    }

}
