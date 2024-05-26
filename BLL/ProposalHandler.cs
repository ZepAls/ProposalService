using DAL;
using DTO;

namespace BLL
{
    public class ProposalHandler
    {
        private ProposalDatabaseHandler databaseHandler;
        public ProposalHandler()
        {
            databaseHandler = new ProposalDatabaseHandler();
        }

        public void CreateProposal(ProposalDTO proposal)
        {
            databaseHandler.CreateProposal(proposal);
        }

        public void UpdateProposal(ProposalDTO proposal)
        {
            databaseHandler.UpdateUser(proposal);
        }

        public void DeleteProposal(ProposalDTO proposal)
        {
            ProposalDTO toDelete = GetProposal(proposal.Id);
            databaseHandler.DeleteProposal(toDelete);
        }

        public IEnumerable<ProposalDTO> GetAllProposals()
        {
            return databaseHandler.GetAllProposals();
        }

        public ProposalDTO GetProposal(int ProposalId)
        {
            return databaseHandler.GetProposal(ProposalId);
        }
    }

}