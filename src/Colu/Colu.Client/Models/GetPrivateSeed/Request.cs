﻿using System;

namespace Colu.Models.GetPrivateSeed
{
    public class Request : Colu.Models.Request
    {
        public Request()
        {
            this.Method = "hdwallet.getPrivateSeed";
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
