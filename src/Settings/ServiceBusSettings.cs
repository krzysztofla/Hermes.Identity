﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Identity.Settings
{
    public class ServiceBusSettings
    {
        public string ConnectionString { get; set; }

        public string QueueName { get; set; }
    }
}