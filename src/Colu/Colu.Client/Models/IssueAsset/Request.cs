﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Colu.Client.Models.IssueAsset
{
    public class Request : Response, IRequest
    {
        [JsonProperty("params")]
        public IssueAsset.Params Param { get; set; }

        [JsonProperty("to")]
        public IList<To> to { get; set; }

        public Request()
        {
            this.jsonrpc = "2.0";
            this.Method = "issueAsset";
            this.Param = new IssueAsset.Params();
            this.to = new List<To>();
        }

        public Request(Int32 n)
        {
            this.jsonrpc = "2.0";
            this.Method = "issueAsset";
            this.Param = new IssueAsset.Params();
            this.to = new List<To>(n);
        }
    }
}