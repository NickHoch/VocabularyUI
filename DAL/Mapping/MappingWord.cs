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
    public class MappingWord
    {
        public static WordDTO MappingDCtoDTO(WordDC wordDC)
        {
            MapperConfiguration configDCtoDTO = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WordDC, WordDTO>();
            });
            IMapper iMapper = configDCtoDTO.CreateMapper();
            return iMapper.Map<WordDC, WordDTO>(wordDC);
        }
        public static WordDC MappingDTOtoDC(WordDTO wordDTO)
        {
            MapperConfiguration configDTOtoDC = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<WordDTO, WordDC>();
            });
            IMapper iMapper = configDTOtoDC.CreateMapper();
            return iMapper.Map<WordDTO, WordDC>(wordDTO);
        }
    }
}
