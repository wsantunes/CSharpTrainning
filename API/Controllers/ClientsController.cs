using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Numerics;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        public readonly ApplicationDbContext Context;
        public ClientsController(ApplicationDbContext context)
        {
            this.Context = context;
        }
        // fazendo a pesquisa por ID no Banco de Dados
        [HttpGet]
        public List<Client> GetClients() {
            return Context.Clients.OrderByDescending(c => c.Id).ToList();
        }
        [HttpGet("{id}")]
        public IActionResult GetClient(int id) {
            var client = Context.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }


        [HttpPost]
        public IActionResult CreateClient(ClientDto clientDto) {
            //submitted data is valid

            var otherClient = Context.Clients.FirstOrDefault(c=> c.Email == clientDto.Email);
            if (otherClient is not null) {
                ModelState.AddModelError("Email", "The Email Address is already used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            var client = new Client
            {
                FirstName = clientDto.FirstName,
                LastName = clientDto.LastName,
                Email = clientDto.Email,
                Phone = clientDto.Phone ?? "",
                Address = clientDto.Address ?? "",
                Status = clientDto.Status,
                CreatedAt = DateTime.Now,
            };
            Context.Clients.Add(client);
            Context.SaveChanges();

            return Ok(client);

        }

        [HttpPut("{id}")]
        public IActionResult EditClient(int id, ClientDto clientDto) 
        {
            var otherClient = Context.Clients.FirstOrDefault(c => c.Id != id && c.Email == clientDto.Email);
            if(otherClient != null)
            {
                ModelState.AddModelError("Email", "The Email Address is already used");
                var validade = new ValidationProblemDetails(ModelState);
                return BadRequest(validade);
            }

            var client = Context.Clients.Find(id);
            if(client is null) 
            {
               return NotFound();
            }

            client.FirstName = clientDto.FirstName;
            client.LastName = clientDto.LastName;
            client.Email = clientDto.Email;
            client.Phone = clientDto.Phone ?? "";
            client.Address = clientDto.Address ?? "";
            client.Status = clientDto.Status;

            Context.SaveChanges();

            return Ok(client);

        }

        //Inserir para Deletar o registro
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var client = Context.Clients.Find(id);
            if(client == null)
            {
                return NotFound();
            }
            Context.Clients.Remove(client);
            Context.SaveChanges();

            return Ok();
        }
        

    }
}