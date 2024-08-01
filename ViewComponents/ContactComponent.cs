using Microsoft.AspNetCore.Mvc;
using Portfolio.Repositories.ContactRepositories;

namespace Portfolio.ViewComponents;

public class ContactComponent : ViewComponent
{
    private readonly IContactRepository _contactRepository;

    public ContactComponent(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var value = await _contactRepository.GetLastContactAsync();
        return View(value);
    }
}
