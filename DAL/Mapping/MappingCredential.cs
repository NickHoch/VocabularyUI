using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.DMs;
using DAL.ServiceVocabulary;

namespace DAL.Mapping
{
    public static class MappingCredential
    {
        public static CredentialDC CredentialDMtoDC(Credential credential)
        {
            MapperConfiguration configDCtoDM = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Credential, CredentialDC>();
            });
            IMapper iMapper = configDCtoDM.CreateMapper();
            return iMapper.Map<Credential, CredentialDC>(credential);
        }
    }
}
