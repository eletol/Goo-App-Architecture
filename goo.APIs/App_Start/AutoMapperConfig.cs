using System.Collections.Generic;
using System.Linq;

using AutoMapper;

namespace Assistance.APIs
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; set; }

        public static void RegisterMappings()
        {
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
          

            });

            Mapper = config.CreateMapper();
        }
    }
}