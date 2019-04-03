using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Utils.Enums;
using Utils.Models.Responses;
using VoteService.Core.Services.VoteService;
using VoteService.Data.Entities;
using VoteService.Models.EntityModels;
using VoteService.Models.ViewModels;

namespace VoteService.Controllers
{
    [Produces("application/json")]
    [Route("api/Vote")]
    public class VoteController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IVoteService _voteService;
        public VoteController(IServiceProvider serviceProvider)
        {
            _mapper = serviceProvider.GetService<IMapper>();
            _voteService = serviceProvider.GetService<IVoteService>();
        }

        [HttpPost]
        public IActionResult Create([FromBody]VoteModel model)
        {
            try
            {
                var vote = _mapper.Map<Vote>(model);
                if (vote != null)
                {
                    return Ok(new DataResponse<VoteModel>(_mapper.Map<VoteModel>(_voteService.Create(vote))));
                }
                return BadRequest();
            }
            catch
            {
                return Ok(new BaseResponse("Can not create vote", ResponseStatus.InternalException));
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody]VoteUpdateViewModel model)
        {
            try
            {
                if (model.Id == id)
                {
                    var selectedVote = _voteService.All.SingleOrDefault(x => x.Id == id);
                    if (selectedVote == null)
                    {
                        return NotFound();
                    }
                    selectedVote.Score = model.Score;
                    return Ok(new DataResponse<VoteModel>(_mapper.Map<VoteModel>(_voteService.Update(selectedVote))));
                }
                return BadRequest();
            }
            catch
            {
                return Ok(new BaseResponse("Can not update vote", ResponseStatus.InternalException));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var voteToRemove = _voteService.All.SingleOrDefault(x => x.Id == id);
                if (voteToRemove == null)
                {
                    return NotFound();
                }
                if (_voteService.Delete(voteToRemove))
                {
                    return Ok(new DataResponse<VoteModel>(_mapper.Map<VoteModel>(voteToRemove)));
                }
                return BadRequest();
            }
            catch
            {
                return Ok(new BaseResponse("Can not delete vote", ResponseStatus.InternalException));
            }
        }
    }
}