using ZenLeads.Models;

namespace ZenLeads.Services
{
    public interface ILeadService
    {
        Task<IEnumerable<Lead>> GetLeadsAsync();
        Task<IEnumerable<Lead>> GetLeadsByStatusAsync(LeadStatus status);
        Task<Lead?> GetLeadByIdAsync(int id);
        Task<Lead> AddLeadAsync(Lead lead);
        Task<Lead?> UpdateLeadAsync(Lead lead);
        Task<bool> DeleteLeadAsync(int id);
        Task<bool> UpdateLeadStatusAsync(int id, LeadStatus status);
    }
} 