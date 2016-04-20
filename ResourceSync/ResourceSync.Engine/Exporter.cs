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
        private IMapper _mapper;

        public Exporter()
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<TextResources__ResourceFile, ResourceFile>()
                    .ForMember(dest => dest.ResourceKeys, opt => opt.MapFrom(src => src.TextResources__ResourceKey))
                    .ReverseMap();
                cfg.CreateMap<TextResources__ResourceKey, ResourceKey>()
                    .ForMember(dest => dest.ResourceValues, opt => opt.MapFrom(src => src.TextResources__ResourceValue))
                     .ReverseMap();
                cfg.CreateMap<TextResources__ResourceValue, ResourceValue>()
                 .ReverseMap();
            });
            _mapper = config.CreateMapper();
        }

        public string Export()
        {
            using (var context = new ResourcesModel())
            {
                var files = context.TextResources__ResourceFile
                    .Include(x => x.TextResources__ResourceKey.Select(y => y.TextResources__ResourceValue))
                    .ToList();

                var dto = _mapper.Map<ResourceFile[]>(files);

                return JsonConvert.SerializeObject(dto, Formatting.Indented);
            }
        }


        public void Import(string input)
        {
            var files = JsonConvert.DeserializeObject<ResourceFile[]>(input);
            using (var context = new ResourcesModel())
            {

                context.Configuration.AutoDetectChangesEnabled = false;

                var fileEntities = context.TextResources__ResourceFile
                    .Include(x => x.TextResources__ResourceKey.Select(y => y.TextResources__ResourceValue))
                    .ToList();

                var existingLanguageIds = context.TextResources__Language.Select(x => x.LanguageID).ToArray();

                var existingEnvironmentIds = context.TextResources__Environment.Select(x => x.TextResourcesEnvironmentID).ToArray();

                foreach (var resourceFile in files.Where(x=> existingEnvironmentIds.Contains(x.TextResourcesEnvironment_TextResourcesEnvironmentID.GetValueOrDefault())))
                {
                    var fileEntity = fileEntities.FirstOrDefault(x => x.ResourceFileID == resourceFile.ResourceFileID);
                    if (fileEntity == null)
                    {
                        fileEntity = _mapper.Map<TextResources__ResourceFile>(resourceFile);
                        context.TextResources__ResourceFile.Add(fileEntity);
                    }

                    foreach (var resourceKey in resourceFile.ResourceKeys.Where(x => existingEnvironmentIds.Contains(x.TextResourcesEnvironment_TextResourcesEnvironmentID.GetValueOrDefault())))
                    {
                        var keyEntity = fileEntity.TextResources__ResourceKey.FirstOrDefault(x => x.ResourceKeyID == resourceKey.ResourceKeyID);
                        if (keyEntity == null)
                        {
                            keyEntity = _mapper.Map<TextResources__ResourceKey>(resourceKey);
                            context.TextResources__ResourceKey.Add(keyEntity);
                            fileEntity.TextResources__ResourceKey.Add(keyEntity);
                        }
                        foreach (var resourceValue in resourceKey.ResourceValues.Where(x=>existingLanguageIds.Contains(x.Language_LanguageID.GetValueOrDefault())))
                        {
                            var valueEntity = keyEntity.TextResources__ResourceValue.FirstOrDefault(x => x.Language_LanguageID == resourceValue.Language_LanguageID);
                            if (valueEntity == null)
                            {
                                valueEntity = _mapper.Map<TextResources__ResourceValue>(resourceValue);
                                context.TextResources__ResourceValue.Add(valueEntity);
                                keyEntity.TextResources__ResourceValue.Add(valueEntity);
                            }

                        }
                    }
                }
                
                //var fileEntities = _mapper.Map<TextResources__ResourceFile[]>(files);
                //context.TextResources__ResourceFile.AddRange(fileEntities);
                context.ChangeTracker.DetectChanges();
                try
                {
                    context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    
                }

            }
        }
    }
}
