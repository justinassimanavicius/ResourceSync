using System;

namespace ResourceSync.Engine.Dto
{
    public class ResourceFile
    {
        public int ID { get; set; }

        public Guid ResourceFileID { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }

        public DateTime? Deleted { get; set; }

        public int? TextResourcesEnvironment_TextResourcesEnvironmentID { get; set; }

        public bool IsFilledManualy { get; set; }

        public ResourceKey[] ResourceKeys { get; set; }
    }
}