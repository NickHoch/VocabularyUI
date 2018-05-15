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
    public class MappingDictionaryExtn
    {
        public static DictionaryExtnDC CredentialDTOtoDC(DictionaryExtnDTO dictionaryDTO)
        {
            MapperConfiguration configDTOtoDC = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DictionaryExtnDTO, DictionaryExtnDC>();
            });
            IMapper iMapper = configDTOtoDC.CreateMapper();
            return iMapper.Map<DictionaryExtnDTO, DictionaryExtnDC>(dictionaryDTO);
        }
        public static DictionaryExtnDTO CredentialDCtoDTO(DictionaryExtnDC dictionaryDC)
        {
            MapperConfiguration configDCtoDTO = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DictionaryExtnDC, DictionaryExtnDTO>();
            });
            IMapper iMapper = configDCtoDTO.CreateMapper();
            return iMapper.Map<DictionaryExtnDC, DictionaryExtnDTO>(dictionaryDC);
        }
    }
}
