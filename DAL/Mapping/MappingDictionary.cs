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
            MapperConfiguration configDTOtoDC = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DictionaryDTO, DictionaryDC>();
            });
            IMapper iMapper = configDTOtoDC.CreateMapper();
            return iMapper.Map<DictionaryDTO, DictionaryDC>(dictionaryDTO);
        }
        public static DictionaryDTO CredentialDCtoDTO(DictionaryDC dictionaryDC)
        {
            MapperConfiguration configDCtoDTO = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DictionaryDC, DictionaryDTO>();
            });
            IMapper iMapper = configDCtoDTO.CreateMapper();
            return iMapper.Map<DictionaryDC, DictionaryDTO>(dictionaryDC);
        }
    }
}
