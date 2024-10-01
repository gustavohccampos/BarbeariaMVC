using BarbeariaMVC.Dto;
using BarbeariaMVC.Models;
using BarbeariaMVC.Services.Cliente;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarbeariaMVC.Controllers;

    public class ClienteController : Controller
    {
    private readonly IClienteInterface _clienteInterface;

    public ClienteController(IClienteInterface clienteInterface)
    {
        _clienteInterface = clienteInterface;
    }


    public IActionResult Cadastrar()
    {
        return View();
    }

    public async Task<IActionResult> Editar(int id)
    {
        var cliente = await _clienteInterface.GetClienteId(id);
        return View(cliente);
    }


    [HttpPost]
    public async Task<IActionResult> Cadastrar(ClienteDto clienteDto, IFormFile foto) {

        if (ModelState.IsValid)
        {
            var cliente = await _clienteInterface.PostCliente(clienteDto, foto);
            return RedirectToAction("Index","Cliente");
        }
        else
        {
            return View (clienteDto);
        }

    }


    [HttpPost]
    public async Task<IActionResult> Editar(ClienteModel clienteModel, IFormFile? foto)
    {
        if (!ModelState.IsValid)
        {
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    Console.WriteLine(error.ErrorMessage); // Ou use outro mecanismo de logging
                }
            }
            return View(clienteModel);
        }

        var cliente = await _clienteInterface.UpdateCliente(clienteModel, foto);
        return RedirectToAction("Index", "Cliente");
    }


    public async Task<IActionResult> Remover(int id)
    {
        var cliente = await _clienteInterface.DeleteCliente(id);
        return RedirectToAction("Index", "Cliente");
    }


    public async Task<IActionResult> Index(string? pesquisar)
    {
        if (pesquisar == null)
        {
            var clientes = await _clienteInterface.GetClientes();
            return View(clientes);
        }
        else
        {
            var clientes = await _clienteInterface.GetClientesFiltro(pesquisar);
            return View(clientes);
        }
    }




}

