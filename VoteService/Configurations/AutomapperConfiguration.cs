using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoteService.Data.Entities;
using VoteService.Models.EntityModels;

namespace VoteService.Configurations
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            VotemodelMappingConfiguration();
        }
        private void VotemodelMappingConfiguration()
        {
            CreateMap<Vote, VoteModel>();
            CreateMap<VoteModel, Vote>();
        }
    }
}
