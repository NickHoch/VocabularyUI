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
    public class MappingDictionary
    {
        public static DictionaryDC CredentialDTOtoDC(DictionaryDTO dictionaryDTO)
        {
            MapperConfiguration configDTOtoDM = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DictionaryDTO, DictionaryDC>();
            });
            IMapper iMapper = configDTOtoDM.CreateMapper();
            return iMapper.Map<DictionaryDTO, DictionaryDC>(dictionaryDTO);
        }
    }
}
