using Cint.DataAccess.Dtos;
using Cint.DataAccess.Repositories.Interface;
using Cint.Domain.Context;
using Cint.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cint.DataAccess.Repositories.Concrete
{
    public class ClientRepository: IClientRepository
    {
        private readonly CintContext _context;

        public ClientRepository(CintContext context)
        {
            _context = context;
        }

        public List<ClientDto> GetAllClients()
        {
            var client = _context.Clients.Select(c => new ClientDto
            {
                Id = c.Id,
                ClientName = c.ClientName,
                Gender = c.Gender,
                Email = c.Email,
                Phone = c.Phone
            }).ToList();

            return client;
        }

        public ClientDto GetClientById(int Id)
        {
            var client = _context.Clients.Where(cr => cr.Id == Id).Select(c => new ClientDto
            {
                Id = c.Id,
                ClientName = c.ClientName,
                Gender = c.Gender,
                Email = c.Email,
                Phone = c.Phone
            }).FirstOrDefault();

            return client;
        }

        public void CreateClient(ClientDto clientDto)
        {
            var client = new Client
            {
                ClientName = clientDto.ClientName,
                Gender = clientDto.Gender,
                Email = clientDto.Email,
                Phone = clientDto.Phone
            };

            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void UpdateClient(ClientDto clientDto)
        {
            var client = _context.Clients.Where(c => c.Id == clientDto.Id).FirstOrDefault();

            client.ClientName = clientDto.ClientName;
            client.Gender = clientDto.Gender;
            client.Email = clientDto.Email;
            client.Phone = clientDto.Phone;

            _context.SaveChanges();
        }

        public void DeleteClient(int Id)
        {
            var client = _context.Clients.Where(c => c.Id == Id).FirstOrDefault();

            _context.Clients.Remove(client);
            _context.SaveChanges();
        }
    }
}
