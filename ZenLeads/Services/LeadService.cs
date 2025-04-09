using Microsoft.EntityFrameworkCore;
using ZenLeads.Data;
using ZenLeads.Models;

namespace ZenLeads.Services
{
    public class LeadService : ILeadService
    {
        private readonly ApplicationDbContext _context;

        public LeadService(ApplicationDbContext context)
        {
            _context = context;
            
            // Adicionar um lead inicial para testes se não existir nenhum
            if (!_context.Leads.Any())
            {
                _context.Leads.Add(new Lead
                {
                    Nome = "Cliente Teste",
                    Email = "teste@email.com",
                    Empresa = "Empresa Teste",
                    Telefone = "(11) 99999-9999",
                    Status = LeadStatus.EmAnalise
                });
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Lead>> GetLeadsAsync()
        {
            return await _context.Leads.ToListAsync();
        }

        public async Task<IEnumerable<Lead>> GetLeadsByStatusAsync(LeadStatus status)
        {
            return await _context.Leads.Where(l => l.Status == status).ToListAsync();
        }

        public async Task<Lead?> GetLeadByIdAsync(int id)
        {
            return await _context.Leads.FindAsync(id);
        }

        public async Task<Lead> AddLeadAsync(Lead lead)
        {
            _context.Leads.Add(lead);
            await _context.SaveChangesAsync();
            return lead;
        }

        public async Task<Lead?> UpdateLeadAsync(Lead lead)
        {
            var existingLead = await _context.Leads.FindAsync(lead.Id);
            if (existingLead == null)
                return null;

            existingLead.Nome = lead.Nome;
            existingLead.Email = lead.Email;
            existingLead.Empresa = lead.Empresa;
            existingLead.Telefone = lead.Telefone;
            existingLead.Status = lead.Status;

            await _context.SaveChangesAsync();
            return existingLead;
        }

        public async Task<bool> DeleteLeadAsync(int id)
        {
            var lead = await _context.Leads.FindAsync(id);
            if (lead == null)
                return false;

            _context.Leads.Remove(lead);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateLeadStatusAsync(int id, LeadStatus status)
        {
            Console.WriteLine($"Serviço: Atualizando lead ID {id} para status {status}");
            var lead = await _context.Leads.FindAsync(id);
            if (lead == null)
            {
                Console.WriteLine($"Serviço: Lead ID {id} não encontrado");
                return false;
            }

            Console.WriteLine($"Serviço: Lead encontrado - {lead.Nome}, status atual: {lead.Status}");
            lead.Status = status;
            
            try
            {
                await _context.SaveChangesAsync();
                Console.WriteLine($"Serviço: Lead atualizado com sucesso");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Serviço: Erro ao atualizar lead - {ex.Message}");
                return false;
            }
        }
    }
} 