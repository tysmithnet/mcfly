﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McFly.Core;
using Moq;

namespace McFly.Tests
{
    internal class ServerClientBuilder
    {
        public Mock<IServerClient> Mock = new Mock<IServerClient>();
        
        public IServerClient Build()
        {
            return Mock.Object;
        }
    }
}
