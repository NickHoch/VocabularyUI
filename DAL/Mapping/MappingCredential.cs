using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.DTOs;
using DAL.ServiceVocabulary;

namespace DAL.Mapping
{
    public class MappingCredential
    {
        public static CredentialDC CredentialDTOtoDC(CredentialDTO credentialDTO)
        {
            MapperConfiguration configDTOtoDM = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CredentialDTO, CredentialDC>();
            });
            IMapper iMapper = configDTOtoDM.CreateMapper();
            return iMapper.Map<CredentialDTO, CredentialDC>(credentialDTO);
        }
    }
}
