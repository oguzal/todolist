using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Exceptions
{
    public class ObjectNotExistsInRepoException<T> : Exception where T : Entity
    {
        public int objectId { get; set; }
    }
}
