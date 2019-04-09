using System;
using System.Collections.Generic;
using System.Text;

namespace EPS.Common.Models
{
    public class Activity<T> : IActivity
    {
        public Activity(T order)
        {
            this.Order = order;
        }

        public T Order { get; set; }

        public string Type { get; set; }

        public object ChangeStateOrder(string newState)
        {
            return null;
        }

        public object SaveActivity()
        {
            return null;
        }
    }
}
