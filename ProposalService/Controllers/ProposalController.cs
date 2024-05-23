using Microsoft.AspNetCore.Mvc;
using DTO;
using BLL;

namespace ProposalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProposalController : ControllerBase
    {
        // GET: api/<ProposalController>
        [HttpGet]
        public ActionResult Get()
        {
            ProposalHandler handler = new ProposalHandler();
            IEnumerable<ProposalDTO> proposallist = handler.GetAllProposals();
            if (proposallist.Count() != 0)
            {
                return Ok(proposallist);
            }
            return NotFound("There are no proposals found");
        }

        // GET api/<ProposalController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            ProposalHandler handler = new ProposalHandler();
            ProposalDTO returnProposal = handler.GetProposal(id);
            if (returnProposal != null)
            {
                return Ok(returnProposal);
            }
            return NotFound($"Proposal could not be found: There is no Proposal with id : {id}");
        }

        // POST api/<ProposalController>
        [HttpPost]
        public ActionResult Post(ProposalDTO proposal)
        {
            if (proposal.Id == 0)
            {
                ProposalHandler handler = new ProposalHandler();
                handler.CreateProposal(proposal);
                return Ok("Proposal created succesfully");
            }
            return BadRequest($"Proposal could not be created: Id was expected to be 0 but was {proposal.Id}");
        }

        // PUT api/<ProposalController>/5
        [HttpPut]
        public ActionResult Put(ProposalDTO proposal)
        {
            ProposalHandler handler = new ProposalHandler();
            if (handler.GetProposal(proposal.Id) != null)
            {
                handler.UpdateProposal(proposal);
                return Ok("Proposal updated succesfully");
            }
            return BadRequest($"Proposal could not be updated: There is no Proposal with id {proposal.Id}");

        }

        // DELETE api/<ProposalController>/5
        [HttpDelete]
        public ActionResult Delete(ProposalDTO proposal)
        {
            ProposalHandler handler = new ProposalHandler();
            if (handler.GetProposal(proposal.Id) != null)
            {
                handler.DeleteProposal(proposal);
                return Ok("Proposal Deleted succesfully");
            }
            return BadRequest($"Proposal could not be deleted: There is no Proposal with id {proposal.Id}");
        }
    }
}
