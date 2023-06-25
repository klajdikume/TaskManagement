﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM.Domain.Primitives
{
    public abstract class Entity
    {
        protected Entity(Guid id) => Id = id;

        public Entity()
        {

        }

        public Guid Id { get; protected set; }
    }
}
