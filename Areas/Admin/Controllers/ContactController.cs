using Microsoft.AspNetCore.Mvc;
using Portfolio.Models.ContactDtos;
using Portfolio.Repositories.ContactRepositories;

namespace Portfolio.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/Contact")]
public class ContactController : Controller
{
    private readonly IContactRepository _contactRepository;

    public ContactController(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var values = await _contactRepository.GetAllContactAsync();
        return View(values);
    }

    [HttpGet]
    [Route("CreateContact")]
    public IActionResult CreateContact()
    {
        return View();
    }

    [HttpPost]
    [Route("CreateContact")]
    public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
    {
        if (ModelState.IsValid)
        {
            await _contactRepository.CreateContactAsync(createContactDto);
            return RedirectToAction("Index", "Contact", new { area = "Admin" });
        }

        return View(createContactDto);
    }

    [Route("UpdateContact/{id}")]
    [HttpGet]
    public async Task<IActionResult> UpdateContact(int id)
    {
        var value = await _contactRepository.GetContactByIdAsync(id);
        return View(value);
    }

    [Route("UpdateContact/{id}")]
    [HttpPost]
    public async Task<IActionResult> UpdateContact(ContactDto contactDto)
    {
        if (ModelState.IsValid)
        {
            await _contactRepository.UpdateContactAsync(contactDto);
            return RedirectToAction("Index", "Contact", new { area = "Admin" });
        }

        return View(contactDto);
    }

    [Route("DeleteContact/{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
        await _contactRepository.DeleteContactAsync(id);
        return RedirectToAction("Index", "Contact", new { area = "Admin" });
    }
}
