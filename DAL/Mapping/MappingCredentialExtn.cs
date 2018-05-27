using AutoMapper;
using DAL.DTOs;
using DAL.ServiceVocabulary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapping
{
    public class MappingCredentialExtn
    {
        public static CredentialExtnDC CredentialDTOtoDC(CredentialExtnDTO credentialDTO)
        {
            MapperConfiguration configDTOtoDM = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CredentialExtnDTO, CredentialExtnDC>();
            });
            IMapper iMapper = configDTOtoDM.CreateMapper();
            return iMapper.Map<CredentialExtnDTO, CredentialExtnDC>(credentialDTO);
        }
    }
}
