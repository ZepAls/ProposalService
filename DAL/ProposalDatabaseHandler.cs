using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProposalDatabaseHandler
    {
        DBContext context;
        public ProposalDatabaseHandler()
        {
            context = new DBContext();
        }

        public void CreateProposal(ProposalDTO proposal)
        {
            context.Proposals.Add(proposal);
            context.SaveChanges();
        }

        public void UpdateUser(ProposalDTO proposal)
        {
            ProposalDTO DbProposal = context.Proposals.Where(t => t.Id == proposal.Id).FirstOrDefault();
            if (DbProposal != null)
            {
                DbProposal.Id = proposal.Id;
                DbProposal.Character = proposal.Character;
                DbProposal.Accepted = proposal.Accepted;
                DbProposal.ParagraphName = proposal.ParagraphName;
                DbProposal.Text = proposal.Text;
                context.SaveChanges();
            }
        }

        public void DeleteProposal(ProposalDTO proposal)
        {
            context.Proposals.Remove(proposal);
            context.SaveChanges();
        }

        public IEnumerable<ProposalDTO> GetAllProposals()
        {
            return context.Proposals;
        }

        public ProposalDTO GetProposal(int ProposalId)
        {
            return context.Proposals.Where(t => t.Id == ProposalId).FirstOrDefault();
        }
    }
}
