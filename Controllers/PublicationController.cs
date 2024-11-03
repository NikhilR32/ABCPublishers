using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ABCPublishers.Models;

public class PublicationController : Controller
{
    private readonly PublicationService _publicationService;
    private Publication _publication;

    public PublicationController(PublicationService publicationService)
    {
        _publicationService = publicationService;
    }

    private async Task LoadPublicationAsync()
    {
        _publication = await _publicationService.LoadPublicationAsync();
    }

    public async Task<IActionResult> Section(string sectionId = "preface")
    {
        await LoadPublicationAsync();

        if (!_publication.Sections.TryGetValue(sectionId, out var section))
        {
            ViewBag.ErrorMessage = "The current Section has no chapters available. Please try again later.";
            return View("/Views/Publications/Error.cshtml");
        }

        ViewBag.CurrentSectionId = sectionId;
        return View("/Views/Publications/Section.cshtml", section);
    }
}