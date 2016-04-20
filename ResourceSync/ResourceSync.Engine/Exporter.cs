using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AutoMapper;
using Newtonsoft.Json;
using ResourceSync.Engine.Dto;
using ResourceSync.Engine.Entities;

namespace ResourceSync.Engine
{
    public class Exporter
    {
        private MapperConfiguration _config;

        public Exporter()
        {
            _config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<TextResources__ResourceFile, ResourceFile>()
                    .ForMember(dest => dest.ResourceKeys, opt => opt.MapFrom(src => src.TextResources__ResourceKey));
                cfg.CreateMap<TextResources__ResourceKey, ResourceKey>()
                    .ForMember(dest => dest.ResourceValues, opt => opt.MapFrom(src => src.TextResources__ResourceValue));
                cfg.CreateMap<TextResources__ResourceValue, ResourceValue>();
            });
        }

        public string Export()
        {
            using (var context = new ResourcesModel())
            {
                var files = context.TextResources__ResourceFile
                    .Include(x => x.TextResources__ResourceKey.Select(y => y.TextResources__ResourceValue))
                    .ToList();

                var dto = _config.CreateMapper().Map<ResourceFile[]>(files);

                return JsonConvert.SerializeObject(dto, Formatting.Indented);
            }
            return string.Empty;
        }
    }
}
