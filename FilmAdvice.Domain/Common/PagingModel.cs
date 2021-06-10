using System;
using System.Collections.Generic;
using System.Text;

namespace FilmAdvice.Domain.Common
{
    public class PagingModel<T>
    {
        public PagingModel(T value)
        {
            this.Data = value;
        }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }

        public T Data { get; set; }
    }
}
