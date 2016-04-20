using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using ResourceSync.Engine.Entities;

namespace ResourceSync.Engine.Dto
{
    public class ResourceKey
    {
        public int ID { get; set; }

        public Guid ResourceKeyID { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public bool PlainText { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }

        public DateTime? Deleted { get; set; }

        public int? TextResourcesEnvironment_TextResourcesEnvironmentID { get; set; }

        public int? ResourceFile_ID { get; set; }

        public ResourceValue[] ResourceValues { get; set; }
    }
}